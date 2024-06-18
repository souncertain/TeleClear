namespace TeleClear2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonToSendCode = new System.Windows.Forms.Button();
            this.buttonToEnterCodeAndPassword = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.leaveChannelsButton = new System.Windows.Forms.Button();
            this.unreadMessagesTextBox = new System.Windows.Forms.TextBox();
            this.codeAndPasswordTextBox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.autoScroll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.phoneTextBox.Location = new System.Drawing.Point(45, 72);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(158, 26);
            this.phoneTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(40, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter a phone number to send code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(249, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "verificationCode";
            this.label2.Visible = false;
            // 
            // buttonToSendCode
            // 
            this.buttonToSendCode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonToSendCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonToSendCode.Location = new System.Drawing.Point(45, 119);
            this.buttonToSendCode.Name = "buttonToSendCode";
            this.buttonToSendCode.Size = new System.Drawing.Size(158, 39);
            this.buttonToSendCode.TabIndex = 5;
            this.buttonToSendCode.Text = "SendCode";
            this.buttonToSendCode.UseVisualStyleBackColor = false;
            this.buttonToSendCode.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonToEnterCodeAndPassword
            // 
            this.buttonToEnterCodeAndPassword.AutoSize = true;
            this.buttonToEnterCodeAndPassword.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonToEnterCodeAndPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonToEnterCodeAndPassword.Location = new System.Drawing.Point(466, 119);
            this.buttonToEnterCodeAndPassword.Name = "buttonToEnterCodeAndPassword";
            this.buttonToEnterCodeAndPassword.Size = new System.Drawing.Size(158, 39);
            this.buttonToEnterCodeAndPassword.TabIndex = 6;
            this.buttonToEnterCodeAndPassword.Text = "Confirm";
            this.buttonToEnterCodeAndPassword.UseVisualStyleBackColor = false;
            this.buttonToEnterCodeAndPassword.Visible = false;
            this.buttonToEnterCodeAndPassword.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(40, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(584, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enter the amount of unread messages into a channels";
            this.label3.Visible = false;
            // 
            // leaveChannelsButton
            // 
            this.leaveChannelsButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.leaveChannelsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.leaveChannelsButton.Location = new System.Drawing.Point(45, 258);
            this.leaveChannelsButton.Name = "leaveChannelsButton";
            this.leaveChannelsButton.Size = new System.Drawing.Size(203, 39);
            this.leaveChannelsButton.TabIndex = 9;
            this.leaveChannelsButton.Text = "LeaveChannels";
            this.leaveChannelsButton.UseVisualStyleBackColor = false;
            this.leaveChannelsButton.Visible = false;
            this.leaveChannelsButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // unreadMessagesTextBox
            // 
            this.unreadMessagesTextBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.unreadMessagesTextBox.Location = new System.Drawing.Point(45, 214);
            this.unreadMessagesTextBox.Name = "unreadMessagesTextBox";
            this.unreadMessagesTextBox.Size = new System.Drawing.Size(158, 26);
            this.unreadMessagesTextBox.TabIndex = 10;
            this.unreadMessagesTextBox.Visible = false;
            // 
            // codeAndPasswordTextBox
            // 
            this.codeAndPasswordTextBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.codeAndPasswordTextBox.Location = new System.Drawing.Point(466, 72);
            this.codeAndPasswordTextBox.Name = "codeAndPasswordTextBox";
            this.codeAndPasswordTextBox.Size = new System.Drawing.Size(158, 26);
            this.codeAndPasswordTextBox.TabIndex = 11;
            this.codeAndPasswordTextBox.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(316, 214);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(454, 204);
            this.listBox1.TabIndex = 12;
            this.listBox1.Visible = false;
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.stopButton.Location = new System.Drawing.Point(45, 327);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(203, 39);
            this.stopButton.TabIndex = 13;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Visible = false;
            this.stopButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // autoScroll
            // 
            this.autoScroll.AutoSize = true;
            this.autoScroll.Checked = true;
            this.autoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScroll.Location = new System.Drawing.Point(45, 383);
            this.autoScroll.Name = "autoScroll";
            this.autoScroll.Size = new System.Drawing.Size(108, 24);
            this.autoScroll.TabIndex = 14;
            this.autoScroll.Text = "AutoScroll";
            this.autoScroll.UseVisualStyleBackColor = true;
            this.autoScroll.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.autoScroll);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.codeAndPasswordTextBox);
            this.Controls.Add(this.unreadMessagesTextBox);
            this.Controls.Add(this.leaveChannelsButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonToEnterCodeAndPassword);
            this.Controls.Add(this.buttonToSendCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.phoneTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "TeleClear";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonToSendCode;
        private System.Windows.Forms.Button buttonToEnterCodeAndPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button leaveChannelsButton;
        private System.Windows.Forms.TextBox unreadMessagesTextBox;
        private System.Windows.Forms.TextBox codeAndPasswordTextBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.CheckBox autoScroll;
    }
}

