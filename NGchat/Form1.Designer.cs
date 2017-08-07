namespace NGchat
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_showMsg = new System.Windows.Forms.ListBox();
            this.tb_inputMsg = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.lb_users = new System.Windows.Forms.ListBox();
            this.lb_userTitle = new System.Windows.Forms.Label();
            this.lb_nameTitle = new System.Windows.Forms.Label();
            this.tb_loginName = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_loginOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_showMsg
            // 
            this.lb_showMsg.BackColor = System.Drawing.Color.White;
            this.lb_showMsg.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_showMsg.FormattingEnabled = true;
            this.lb_showMsg.HorizontalScrollbar = true;
            this.lb_showMsg.ItemHeight = 20;
            this.lb_showMsg.Location = new System.Drawing.Point(19, 54);
            this.lb_showMsg.Name = "lb_showMsg";
            this.lb_showMsg.Size = new System.Drawing.Size(420, 224);
            this.lb_showMsg.TabIndex = 0;
            // 
            // tb_inputMsg
            // 
            this.tb_inputMsg.BackColor = System.Drawing.Color.White;
            this.tb_inputMsg.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_inputMsg.Location = new System.Drawing.Point(20, 309);
            this.tb_inputMsg.Multiline = true;
            this.tb_inputMsg.Name = "tb_inputMsg";
            this.tb_inputMsg.Size = new System.Drawing.Size(419, 74);
            this.tb_inputMsg.TabIndex = 1;
            this.tb_inputMsg.TextChanged += new System.EventHandler(this.tb_inputMsg_TextChanged);
            // 
            // btn_send
            // 
            this.btn_send.Enabled = false;
            this.btn_send.Location = new System.Drawing.Point(364, 402);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 2;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // lb_users
            // 
            this.lb_users.BackColor = System.Drawing.Color.White;
            this.lb_users.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_users.FormattingEnabled = true;
            this.lb_users.HorizontalScrollbar = true;
            this.lb_users.ItemHeight = 20;
            this.lb_users.Location = new System.Drawing.Point(459, 55);
            this.lb_users.Name = "lb_users";
            this.lb_users.Size = new System.Drawing.Size(155, 364);
            this.lb_users.TabIndex = 5;
            this.lb_users.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lb_users_MouseClick);
            // 
            // lb_userTitle
            // 
            this.lb_userTitle.AutoSize = true;
            this.lb_userTitle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_userTitle.Location = new System.Drawing.Point(456, 20);
            this.lb_userTitle.Name = "lb_userTitle";
            this.lb_userTitle.Size = new System.Drawing.Size(80, 17);
            this.lb_userTitle.TabIndex = 6;
            this.lb_userTitle.Text = "其他在线用户";
            // 
            // lb_nameTitle
            // 
            this.lb_nameTitle.AutoSize = true;
            this.lb_nameTitle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_nameTitle.Location = new System.Drawing.Point(17, 20);
            this.lb_nameTitle.Name = "lb_nameTitle";
            this.lb_nameTitle.Size = new System.Drawing.Size(56, 17);
            this.lb_nameTitle.TabIndex = 7;
            this.lb_nameTitle.Text = "用户名：";
            // 
            // tb_loginName
            // 
            this.tb_loginName.BackColor = System.Drawing.Color.White;
            this.tb_loginName.Location = new System.Drawing.Point(79, 19);
            this.tb_loginName.Name = "tb_loginName";
            this.tb_loginName.Size = new System.Drawing.Size(164, 21);
            this.tb_loginName.TabIndex = 8;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(270, 18);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 9;
            this.btn_login.Text = "登录";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_loginOut
            // 
            this.btn_loginOut.Enabled = false;
            this.btn_loginOut.Location = new System.Drawing.Point(364, 18);
            this.btn_loginOut.Name = "btn_loginOut";
            this.btn_loginOut.Size = new System.Drawing.Size(75, 23);
            this.btn_loginOut.TabIndex = 10;
            this.btn_loginOut.Text = "退出";
            this.btn_loginOut.UseVisualStyleBackColor = true;
            this.btn_loginOut.Click += new System.EventHandler(this.btn_loginOut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(636, 442);
            this.Controls.Add(this.btn_loginOut);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.tb_loginName);
            this.Controls.Add(this.lb_nameTitle);
            this.Controls.Add(this.lb_userTitle);
            this.Controls.Add(this.lb_users);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.tb_inputMsg);
            this.Controls.Add(this.lb_showMsg);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "年糕聊天室";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_showMsg;
        private System.Windows.Forms.TextBox tb_inputMsg;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.ListBox lb_users;
        private System.Windows.Forms.Label lb_userTitle;
        private System.Windows.Forms.Label lb_nameTitle;
        private System.Windows.Forms.TextBox tb_loginName;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_loginOut;
    }
}

