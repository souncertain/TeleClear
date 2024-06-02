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

namespace TeleClear2
{
    public partial class Form1 : Form
    {
        private static string _info = "";
        private static bool _stoped = false;
        private WTelegram.Client _client;

        public Form1()
        {
            InitializeComponent();
            WTelegram.Helpers.Log = (l, s) => Debug.WriteLine(s);

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client?.Dispose();
            Properties.Settings.Default.Save();
        }

        private async Task Login(string Info)
        {
            string what = await _client.Login(Info);
            if (what != null)
            {
                label2.Text = what + ':';
                textBox2.Text = "";
                label2.Visible = textBox2.Visible = button2.Visible = true;
                textBox2.Focus();
                return;
            }
            textBox3.Visible = label3.Visible = button3.Visible = listBox1.Visible = button4.Visible = true;
            listBox1.Items.Add($"Now we are connected as {_client.User}");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                _info = textBox1.Text;
                _client = new WTelegram.Client(22034282, "50fe24f54e972eb9cad59b92cad750e8");
                await Login(_info);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            label2.Visible = textBox2.Visible = button2.Visible = false;
            await Login(textBox2.Text);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if(_client.User == null)
            {
                MessageBox.Show("You must login!");
                return;
            }
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
                Thread.Sleep(1000);
            }
            listBox1.Items.Clear();
            listBox1.Items.Add($"Now we are connected as {_client.User}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _stoped = true;
        }
    }
}
