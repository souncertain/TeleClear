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
                textBox2.Text = "";
                label2.Visible = textBox2.Visible = button2.Visible = true;
                if (label2.Text == "password:") textBox2.UseSystemPasswordChar = true;
                textBox2.Focus();
                return;
            }
            textBox3.Visible = label3.Visible = button3.Visible = listBox1.Visible = button4.Visible = true;
            listBox1.Items.Add($"Now we are connected as {_client.User}");
        }

        //Method to change the text (what we need to enter right now) in login 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Method to send code with a number of user
        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                button1.Enabled = false;
                _WhatWeNeedToLogin = textBox1.Text;
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
            label2.Visible = textBox2.Visible = button2.Visible = false;
            await Login(textBox2.Text);
        }

        //Main logic to clear channels, we take all user chats 
        //and find where the amount of unread messages more than
        //value which user enter
        private async void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if(_client.User == null)
            {
                MessageBox.Show("You must login!");
                return;
            }
            _stoped = false;
            var chats = await _client.Messages_GetAllChats();

            long accessHash = 0;
            int messageToLeave = Int32.Parse(textBox3.Text);
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
                Thread.Sleep(1000); //Need sleep because the TelegramApi
                                    //has a limit of the number of requests per second
            }
            listBox1.Items.Clear();
            listBox1.Items.Add($"Now we are connected as {_client.User}");
        }

        //Stop sending messages
        private void button4_Click(object sender, EventArgs e)
        {
            _stoped = true;
        }
    }
}
