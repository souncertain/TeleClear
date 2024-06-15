using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTelegram;
using TL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Threading;
using configApi;

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

        //Login Task, we take the information that we need to login and send this with TelegramAPI
        private async Task Login(string Info)
        {
            string what = await _client.Login(Info);
            if (what != null)
            {
                label2.Text = what + ':';
                codeAndPasswordTextBox.Text = "";
                label2.Visible = codeAndPasswordTextBox.Visible = buttonToEnterCodeAndPassword.Visible = true;
                if (label2.Text == "password:") codeAndPasswordTextBox.UseSystemPasswordChar = true;
                codeAndPasswordTextBox.Focus();
                return;
            }
            autoScroll.Visible = unreadMessagesTextBox.Visible = label3.Visible = leaveChannelsButton.Visible = listBox1.Visible = stopButton.Visible = true;
            listBox1.Items.Add($"Now we are connected as {_client.User}");
        }

        //Method to send code with a number of user
        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                buttonToSendCode.Enabled = false;
                _WhatWeNeedToLogin = phoneTextBox.Text;
                _client = new WTelegram.Client(config.appId, config.hash);
                await Login(_WhatWeNeedToLogin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Method to enter code from telegram and password
        private async void button2_Click_1(object sender, EventArgs e)
        {
            label2.Visible = codeAndPasswordTextBox.Visible = buttonToEnterCodeAndPassword.Visible = false;
            await Login(codeAndPasswordTextBox.Text);
        }

        //Main logic to clear channels, we take all user chats 
        //and find where the amount of unread messages more than
        //value which user enter
        private async void button3_Click(object sender, EventArgs e)
        {
            List<string> nameChannels = new List<string>();
            int countOfChannels = 0;

            listBox1.Items.Clear();
            if(_client.User == null)
            {
                MessageBox.Show("You must login!");
                return;
            }
            _stoped = false;
            var chats = await _client.Messages_GetAllChats();

            long accessHash = 0;
            int messageToLeave = Int32.Parse(unreadMessagesTextBox.Text);
            foreach (var chat in chats.chats.Values)
            {
                if (_stoped) break;
                if(chat == null || !chat.IsActive) continue;
                int unreadMessages = 0;
                if (chat.IsChannel)
                {
                    try
                    {
                        TL.Channel channel = chats.chats.Values.ToList().First(x => x.ID == chat.ID) as TL.Channel;
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
                                    //has a limit of the number of requests per second\
                if(autoScroll.Checked)
                {
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    listBox1.SelectedIndex = -1;
                }
            }
            listBox1.Items.Clear();
            listBox1.Items.Add($"We are checked {countOfChannels} channels and leave from:\n");
            foreach(string chat in nameChannels)
            {
                listBox1.Items.Add(chat + '\n');
            }
        }

        //Stop sending messages
        private void button4_Click(object sender, EventArgs e)
        {
            _stoped = true;
        }
    }
}
