using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;
using TL;

//Created by souncertain

namespace TeleClear2
{
    public partial class MainForm : Form
    {
        //variable stores info that the user enters
        private static string _pendingLoginInput = "";
        //variable stores condithion to stop leave channels
        private static bool _stopRequested = false;
        //Telegram Client
        private WTelegram.Client _client;
        private int _apiId;
        private string _apiHash;

        public MainForm(IConfigurationRoot config)
        {
            InitializeComponent();
            Int32.TryParse(config.GetSection("Telegram:ApiId").Value, out _apiId);
            _apiHash = config.GetSection("Telegram:ApiHash").Value;
        }

        //Save settings and frees up the client memory
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client?.Dispose();
            Properties.Settings.Default.Save();
        }

        //CheckBox to show or hide password
        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            codeAndPasswordTextBox.UseSystemPasswordChar = !showPassword.Checked;
        }

        //Login Task, we take the information that we need to login and send this with TelegramAPI
        private async Task Login(string Information)
        {
            string nextStep = await _client.Login(Information);
            if (nextStep != null)
            {
                CurrentStepLabel.Text = nextStep + ':';
                codeAndPasswordTextBox.Text = "";
                CurrentStepLabel.Visible = codeAndPasswordTextBox.Visible = buttonToEnterCodeAndPassword.Visible = true;
                if (CurrentStepLabel.Text == "password:")
                {
                    codeAndPasswordTextBox.UseSystemPasswordChar = true;
                    showPassword.Visible = true;
                }
                codeAndPasswordTextBox.Focus();
                return;
            }
            buttonToLeaveAccount.Visible = autoScroll.Visible = unreadMessagesTextBox.Visible = EnterAmountLabel.Visible = leaveChannelsButton.Visible = channelsListBox.Visible = stopButton.Visible = true;
            channelsListBox.Items.Add($"Now we are connected as {_client.User}");
        }
        
        //Method to send code with a number of user
        private async void buttonSendCode_Click(object sender, EventArgs e)
        {
            try
            { 
                buttonToSendCode.Enabled = false;
                _pendingLoginInput = phoneTextBox.Text;
                if(string.IsNullOrWhiteSpace(_pendingLoginInput))
                {
                    throw new Exception("Enter the phone number!");
                }
                _client = new WTelegram.Client(_apiId, _apiHash, null);
                await Login(_pendingLoginInput);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                buttonToSendCode.Enabled = true;
            }
        }

        //Method to enter code from telegram and password
        private async void buttonEnterCodeAndPassword_Click(object sender, EventArgs e)
        {
            try
            {
                showPassword.Visible = CurrentStepLabel.Visible = codeAndPasswordTextBox.Visible = buttonToEnterCodeAndPassword.Visible = false;
                string userInput = codeAndPasswordTextBox.Text;
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    if (CurrentStepLabel.Text.Contains("verification"))
                    {
                        throw new Exception("Enter the verification code!");
                    }
                    else
                    {
                        throw new Exception("Enter the password!");
                    }
                }
                await Login(userInput);
            }
            catch (Exception ex)
            {
                CurrentStepLabel.Visible = codeAndPasswordTextBox.Visible = buttonToEnterCodeAndPassword.Visible = true;
                MessageBox.Show(ex.Message);
            }
        }

        //Main logic to clear channels, we take all user chats 
        //and find where the amount of unread messages more than
        //value which user enter
        private async void buttonLeaveChannels_Click(object sender, EventArgs e)
        {
            List<string> nameChannels = new List<string>();
            int countOfChannels = 0;

            if (_client.User == null)
            {
                MessageBox.Show("You must login!");
                return;
            }
            if(!Int32.TryParse(unreadMessagesTextBox.Text, out int messageToLeave))
            {
                MessageBox.Show("Enter a number!");
                return;
            }
            if (messageToLeave < 0)
            {
                MessageBox.Show("Amount of unread channels cant be negative!");
                return;
            }
            channelsListBox.Items.Clear();
            _stopRequested = false;
            var chats = await _client.Messages_GetAllChats();

            var chatsBase = chats.chats.Values.Where(chat => chat?.IsActive == true).ToList();
            foreach (var chat in chatsBase)
            {
                bool isLeft = false;
                if (_stopRequested) break;
                int unreadMessages = await GetUnreadCountAsync(chat);
                
                if(unreadMessages > messageToLeave && chat.IsChannel)
                {
                    try
                    {
                        if(chat is Channel channel)
                        {
                            await _client.Channels_LeaveChannel(new InputChannel(channel.id, channel.access_hash));
                            nameChannels.Add(channel.title);
                            isLeft = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        channelsListBox.Items.Add($"Error leaving {chat.Title}: {ex.Message}");
                    }
                }

                if (isLeft)
                {
                    channelsListBox.Items.Add($"Checked and left from {chat.Title}, going to next");
                }
                else
                {
                    channelsListBox.Items.Add($"Checked and not left from {chat.Title}, going to next");
                }
                countOfChannels++;
                if(autoScroll.Checked)
                {
                    channelsListBox.SelectedIndex = channelsListBox.Items.Count - 1;
                    channelsListBox.SelectedIndex = -1;
                }
                await Task.Delay(1000); //Need delay because the TelegramApi
                                        //has a limit of the number of requests per second
            }
            channelsListBox.Items.Clear();
            if (countOfChannels == 0)
            {
                channelsListBox.Items.Add("We aren't leaved from any channel.");
            }
            else
            { 
                channelsListBox.Items.Add($"We are checked {countOfChannels} channels and leave from:\n");
                foreach (string chat in nameChannels)
                {
                    channelsListBox.Items.Add(chat + '\n');
                }
            }
        }
        //Function to get the number of unread messages in chat
        private async Task<int> GetUnreadCountAsync(ChatBase chat)
        {
            try
            {
                if (chat is Channel channel)
                {
                    var fullChannel = await _client.Channels_GetFullChannel(channel);
                    if (fullChannel.full_chat is ChannelFull chFull)
                        return chFull.unread_count;
                }
                else
                {
                    var fullChat = await _client.GetFullChat(chat);
                    if (fullChat?.full_chat is ChannelFull chFull)
                        return chFull.unread_count;
                }
            }
            catch
            {

            }
            return 0;
        }

        //Stop sending messages
        private void buttonStopLeaveChannels_Click(object sender, EventArgs e)
        {
            _stopRequested = true;
        }

        //Leave from your account
        private void buttonToLeaveAccount_Click(object sender, EventArgs e)
        {
            _client?.Dispose();
            buttonToLeaveAccount.Visible = autoScroll.Visible = unreadMessagesTextBox.Visible = 
                EnterAmountLabel.Visible = leaveChannelsButton.Visible = channelsListBox.Visible = stopButton.Visible = false;
            channelsListBox.Items.Clear();
            buttonToSendCode.Enabled = true;

        }
    }
}
