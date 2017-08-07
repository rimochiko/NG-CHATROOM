namespace NGchatServer
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
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lb_info = new System.Windows.Forms.ListBox();
            this.tb_sendInfo = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.lb_users = new System.Windows.Forms.ListBox();
            this.lb_userTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_start.Location = new System.Drawing.Point(30, 186);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(96, 28);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "开启服务器";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.Location = new System.Drawing.Point(132, 186);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(104, 28);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "停止服务";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lb_info
            // 
            this.lb_info.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_info.BackColor = System.Drawing.Color.White;
            this.lb_info.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_info.FormattingEnabled = true;
            this.lb_info.HorizontalScrollbar = true;
            this.lb_info.ItemHeight = 20;
            this.lb_info.Location = new System.Drawing.Point(30, 21);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(314, 144);
            this.lb_info.TabIndex = 3;
            // 
            // tb_sendInfo
            // 
            this.tb_sendInfo.BackColor = System.Drawing.Color.White;
            this.tb_sendInfo.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_sendInfo.Location = new System.Drawing.Point(30, 232);
            this.tb_sendInfo.Multiline = true;
            this.tb_sendInfo.Name = "tb_sendInfo";
            this.tb_sendInfo.Size = new System.Drawing.Size(314, 50);
            this.tb_sendInfo.TabIndex = 4;
            // 
            // btn_send
            // 
            this.btn_send.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_send.Location = new System.Drawing.Point(242, 186);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(102, 28);
            this.btn_send.TabIndex = 5;
            this.btn_send.Text = "发送通知";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // lb_users
            // 
            this.lb_users.BackColor = System.Drawing.Color.White;
            this.lb_users.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_users.ForeColor = System.Drawing.Color.Black;
            this.lb_users.FormattingEnabled = true;
            this.lb_users.HorizontalScrollbar = true;
            this.lb_users.ItemHeight = 20;
            this.lb_users.Location = new System.Drawing.Point(367, 38);
            this.lb_users.Name = "lb_users";
            this.lb_users.Size = new System.Drawing.Size(125, 244);
            this.lb_users.TabIndex = 6;
            // 
            // lb_userTitle
            // 
            this.lb_userTitle.AutoSize = true;
            this.lb_userTitle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_userTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_userTitle.Location = new System.Drawing.Point(367, 20);
            this.lb_userTitle.Name = "lb_userTitle";
            this.lb_userTitle.Size = new System.Drawing.Size(56, 17);
            this.lb_userTitle.TabIndex = 7;
            this.lb_userTitle.Text = "在线用户";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(521, 294);
            this.Controls.Add(this.lb_userTitle);
            this.Controls.Add(this.lb_users);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.tb_sendInfo);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_start);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "年糕聊天室 - 服务器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.ListBox lb_info;
        private System.Windows.Forms.TextBox tb_sendInfo;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.ListBox lb_users;
        private System.Windows.Forms.Label lb_userTitle;
    }
}

