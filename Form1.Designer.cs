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
            this.showPassword = new System.Windows.Forms.CheckBox();
            this.buttonToLeaveAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.phoneTextBox.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneTextBox.Location = new System.Drawing.Point(70, 94);
            this.phoneTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(244, 34);
            this.phoneTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter a phone number to send code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(387, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "verificationCode";
            this.label2.Visible = false;
            // 
            // buttonToSendCode
            // 
            this.buttonToSendCode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonToSendCode.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToSendCode.Location = new System.Drawing.Point(70, 150);
            this.buttonToSendCode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonToSendCode.Name = "buttonToSendCode";
            this.buttonToSendCode.Size = new System.Drawing.Size(246, 51);
            this.buttonToSendCode.TabIndex = 5;
            this.buttonToSendCode.Text = "SendCode";
            this.buttonToSendCode.UseVisualStyleBackColor = false;
            this.buttonToSendCode.Click += new System.EventHandler(this.buttonSendCode_Click);
            // 
            // buttonToEnterCodeAndPassword
            // 
            this.buttonToEnterCodeAndPassword.AutoSize = true;
            this.buttonToEnterCodeAndPassword.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonToEnterCodeAndPassword.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToEnterCodeAndPassword.Location = new System.Drawing.Point(725, 155);
            this.buttonToEnterCodeAndPassword.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonToEnterCodeAndPassword.Name = "buttonToEnterCodeAndPassword";
            this.buttonToEnterCodeAndPassword.Size = new System.Drawing.Size(246, 51);
            this.buttonToEnterCodeAndPassword.TabIndex = 6;
            this.buttonToEnterCodeAndPassword.Text = "Confirm";
            this.buttonToEnterCodeAndPassword.UseVisualStyleBackColor = false;
            this.buttonToEnterCodeAndPassword.Visible = false;
            this.buttonToEnterCodeAndPassword.Click += new System.EventHandler(this.buttonEnterCodeAndPassword_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 224);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(611, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enter the amount of unread messages into a channels";
            this.label3.Visible = false;
            // 
            // leaveChannelsButton
            // 
            this.leaveChannelsButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.leaveChannelsButton.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaveChannelsButton.Location = new System.Drawing.Point(70, 349);
            this.leaveChannelsButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.leaveChannelsButton.Name = "leaveChannelsButton";
            this.leaveChannelsButton.Size = new System.Drawing.Size(316, 51);
            this.leaveChannelsButton.TabIndex = 9;
            this.leaveChannelsButton.Text = "LeaveChannels";
            this.leaveChannelsButton.UseVisualStyleBackColor = false;
            this.leaveChannelsButton.Visible = false;
            this.leaveChannelsButton.Click += new System.EventHandler(this.buttonLeaveChannels_Click);
            // 
            // unreadMessagesTextBox
            // 
            this.unreadMessagesTextBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.unreadMessagesTextBox.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unreadMessagesTextBox.Location = new System.Drawing.Point(70, 279);
            this.unreadMessagesTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.unreadMessagesTextBox.Name = "unreadMessagesTextBox";
            this.unreadMessagesTextBox.Size = new System.Drawing.Size(244, 34);
            this.unreadMessagesTextBox.TabIndex = 10;
            this.unreadMessagesTextBox.Visible = false;
            // 
            // codeAndPasswordTextBox
            // 
            this.codeAndPasswordTextBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.codeAndPasswordTextBox.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeAndPasswordTextBox.Location = new System.Drawing.Point(725, 94);
            this.codeAndPasswordTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.codeAndPasswordTextBox.Name = "codeAndPasswordTextBox";
            this.codeAndPasswordTextBox.Size = new System.Drawing.Size(244, 34);
            this.codeAndPasswordTextBox.TabIndex = 11;
            this.codeAndPasswordTextBox.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listBox1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 26;
            this.listBox1.Location = new System.Drawing.Point(481, 279);
            this.listBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(663, 264);
            this.listBox1.TabIndex = 12;
            this.listBox1.Visible = false;
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.stopButton.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.Location = new System.Drawing.Point(70, 425);
            this.stopButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(316, 51);
            this.stopButton.TabIndex = 13;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Visible = false;
            this.stopButton.Click += new System.EventHandler(this.buttonStopLeaveChannels_Click);
            // 
            // autoScroll
            // 
            this.autoScroll.AutoSize = true;
            this.autoScroll.Checked = true;
            this.autoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScroll.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoScroll.Location = new System.Drawing.Point(70, 498);
            this.autoScroll.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.autoScroll.Name = "autoScroll";
            this.autoScroll.Size = new System.Drawing.Size(149, 30);
            this.autoScroll.TabIndex = 14;
            this.autoScroll.Text = "AutoScroll";
            this.autoScroll.UseVisualStyleBackColor = true;
            this.autoScroll.Visible = false;
            // 
            // showPassword
            // 
            this.showPassword.AutoSize = true;
            this.showPassword.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPassword.Location = new System.Drawing.Point(999, 94);
            this.showPassword.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(98, 30);
            this.showPassword.TabIndex = 15;
            this.showPassword.Text = "Show";
            this.showPassword.UseVisualStyleBackColor = true;
            this.showPassword.Visible = false;
            this.showPassword.CheckedChanged += new System.EventHandler(this.showPassword_CheckedChanged);
            // 
            // buttonToLeaveAccount
            // 
            this.buttonToLeaveAccount.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonToLeaveAccount.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToLeaveAccount.Location = new System.Drawing.Point(392, 150);
            this.buttonToLeaveAccount.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonToLeaveAccount.Name = "buttonToLeaveAccount";
            this.buttonToLeaveAccount.Size = new System.Drawing.Size(246, 51);
            this.buttonToLeaveAccount.TabIndex = 16;
            this.buttonToLeaveAccount.Text = "LeaveAccount";
            this.buttonToLeaveAccount.UseVisualStyleBackColor = false;
            this.buttonToLeaveAccount.Visible = false;
            this.buttonToLeaveAccount.Click += new System.EventHandler(this.buttonToLeaveAccount_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1180, 566);
            this.Controls.Add(this.buttonToLeaveAccount);
            this.Controls.Add(this.showPassword);
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
            this.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
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
        private System.Windows.Forms.CheckBox showPassword;
        private System.Windows.Forms.Button buttonToLeaveAccount;
    }
}

