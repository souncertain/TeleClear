using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TL;
using System.Threading;
using System.Drawing;

//Created by souncertain

namespace TeleClear2
{
    public partial class Form1 : Form
    {
        //variable stores info that the user enters
        private static string _WhatWeNeedToLogin = "";
        //variable stores condithion to stop leave channels
        private static bool _stoped = false;
        //Telegram Client
        private WTelegram.Client _client;
        private int _apiId;
        private string _apiHash;

        public Form1()
        {
            InitializeComponent();
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
            if(showPassword.Checked)
            {
                codeAndPasswordTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                codeAndPasswordTextBox.UseSystemPasswordChar = true;
            }
        }

        //Login Task, we take the information that we need to login and send this with TelegramAPI
        private async Task Login(string Information)
        {
            string what = await _client.Login(Information);
            if (what != null)
            {
                label2.Text = what + ':';
                codeAndPasswordTextBox.Text = "";
                label2.Visible = codeAndPasswordTextBox.Visible = buttonToEnterCodeAndPassword.Visible = true;
                if (label2.Text == "password:")
                {
                    codeAndPasswordTextBox.UseSystemPasswordChar = true;
                    showPassword.Visible = true;
                }
                codeAndPasswordTextBox.Focus();
                return;
            }
            buttonToLeaveAccount.Visible = autoScroll.Visible = unreadMessagesTextBox.Visible = label3.Visible = leaveChannelsButton.Visible = listBox1.Visible = stopButton.Visible = true;
            listBox1.Items.Add($"Now we are connected as {_client.User}");
        }
        
        //Method to send code with a number of user
        private async void buttonSendCode_Click(object sender, EventArgs e)
        {
            try
            {
                if(apiIdTextBox.Text == "" || apiHashTextBox.Text == "")
                {
                    throw new Exception("Enter a data.");
                }
                if(!Int32.TryParse(apiIdTextBox.Text, out _apiId))
                {
                    throw new Exception("Enter a valid data.");
                }
                else
                {

                }
                _apiHash = apiHashTextBox.Text;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                buttonToSendCode.Enabled = true;
            }
            try
            {
                
                buttonToSendCode.Enabled = false;
                _WhatWeNeedToLogin = phoneTextBox.Text;
                if(_WhatWeNeedToLogin == "")
                {
                    throw new Exception("Enter the phone number!");
                }
                _client = new WTelegram.Client(_apiId, _apiHash, null);
                await Login(_WhatWeNeedToLogin);
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
                showPassword.Visible = label2.Visible = codeAndPasswordTextBox.Visible = buttonToEnterCodeAndPassword.Visible = false;
                string information = codeAndPasswordTextBox.Text;
                if (information == "")
                {
                    if(label2.Text == "verificationCode")
                    {
                        throw new Exception("Enter the verification code!");
                    }
                    else
                    {
                        throw new Exception("Enter the password!");
                    }
                }
                await Login(information);
            }
            catch (Exception ex)
            {
                label2.Visible = codeAndPasswordTextBox.Visible = buttonToEnterCodeAndPassword.Visible = true;
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
            int messageToLeave;

            if (_client.User == null)
            {
                MessageBox.Show("You must login!");
                return;
            }
            try
            {
                messageToLeave = Int32.Parse(unreadMessagesTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Enter a number!");
                return;
            }
            if (messageToLeave < 0)
            {
                MessageBox.Show("Amount of unread channels cant be negative!");
                return;
            }
            listBox1.Items.Clear();
            _stoped = false;
            var chats = await _client.Messages_GetAllChats();

            long accessHash = 0;
            foreach (var chat in chats.chats.Values)
            {
                if (_stoped) break;
                if(chat == null || !chat.IsActive) continue;
                int unreadMessages = 0;
                if (chat.IsChannel)
                {
                    try
                    {
                        Channel channel = chats.chats.Values.ToList().First(x => x.ID == chat.ID) as TL.Channel;
                        if (channel != null && channel.IsActive)
                        {
                            accessHash = channel.access_hash;
                            Messages_ChatFull fullChannel = await _client.Channels_GetFullChannel(channel);
                            if (fullChannel != null)
                            {
                                ChannelFull channelFull = fullChannel.full_chat as ChannelFull;
                                if (channelFull != null)
                                {
                                    unreadMessages = channelFull.unread_count;
                                    if (unreadMessages > messageToLeave)
                                    {
                                        nameChannels.Add(chat.Title);
                                        await _client.Channels_LeaveChannel(new InputChannel(chat.ID, accessHash));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                else
                {
                    try
                    {
                        var FullChat = await _client.GetFullChat(chat);
                        if (FullChat != null)
                        {
                            ChannelFull chatFull = FullChat.full_chat as ChannelFull;
                            if (chatFull != null)
                            {
                                unreadMessages = chatFull.unread_count;
                                if (unreadMessages > messageToLeave)
                                {
                                    TL.Channel channel = chat as TL.Channel;
                                    if (channel != null && channel.IsActive)
                                    {
                                        try
                                        {
                                            nameChannels.Add(chat.Title);
                                            await _client.Channels_LeaveChannel(new InputChannel(channel.ID, channel.access_hash));
                                        }
                                        catch (Exception)
                                        {
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
                listBox1.Items.Add($"Checked {chat.Title}, going to next");
                countOfChannels++;
                Thread.Sleep(1000); //Need sleep because the TelegramApi
                                    //has a limit of the number of requests per second
                if(autoScroll.Checked)
                {
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    listBox1.SelectedIndex = -1;
                }
            }
            listBox1.Items.Clear();
            if (countOfChannels == 0)
            {
                listBox1.Items.Add("We aren't leaved from any channel.");
            }
            else
            { 
                listBox1.Items.Add($"We are checked {countOfChannels} channels and leave from:\n");
                foreach (string chat in nameChannels)
                {
                    listBox1.Items.Add(chat + '\n');
                }
            }
        }

        //Stop sending messages
        private void buttonStopLeaveChannels_Click(object sender, EventArgs e)
        {
            _stoped = true;
        }

        //Leave from your account
        private void buttonToLeaveAccount_Click(object sender, EventArgs e)
        {
            _client?.Dispose();
            buttonToLeaveAccount.Visible = autoScroll.Visible = unreadMessagesTextBox.Visible = label3.Visible = leaveChannelsButton.Visible = listBox1.Visible = stopButton.Visible = false;
            listBox1.Items.Clear();
            buttonToSendCode.Enabled = true;

        }
    }
}
