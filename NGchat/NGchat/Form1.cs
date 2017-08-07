using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace NGchat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            setRestStatus();
        }


        //判断聊天窗口是否有改动信息
        bool isModify = false;

        Socket socketClient = null;
        Thread threadClient = null;

        //用于安全结束线程的标记
        bool isntStop = true;

        //点击登录按钮
        private void btn_login_Click(object sender, EventArgs e)
        {
            //获取用户名
            string userName = tb_loginName.Text.Trim();
            isntStop = true;

            //判断用户名是否输入正确

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("请填写用户名");
                return;
            }

            if (userName.Contains('*') || userName.Contains("管理员"))
            {
                MessageBox.Show("请不要在用户名填写不符合规定字符词语");
                return;
            }

            try
            {
                //建立客户端的Socket
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //建立服务器的IP连接地址
                IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
                EndPoint point = new IPEndPoint(ipaddress, 7788);

                //客户端连接服务器
                socketClient.Connect(point);

                //开启监听来自服务器的信息的线程
                threadClient = new Thread(RecMsg);
                threadClient.IsBackground = true;
                threadClient.Start();

                setWorkStatus();

                //给服务器发送用户名信息
                byte[] arrClientSendMsg = Encoding.UTF8.GetBytes("1*" + userName);
                socketClient.Send(arrClientSendMsg);

                lb_showMsg.Items.Add("【年糕聊天室】欢迎用户" + userName + "登陆聊天室");
            }
            catch
            {
                MessageBox.Show("与服务器连接失败");
            }

        }


        //监听来自服务器的消息
        private void RecMsg()
        {
            try
            {
                while (isntStop)
                {
                    //创建一个字节对象来储存服务器的信息
                    byte[] arrRecMsg = new byte[1024 * 1024];
                    int length = socketClient.Receive(arrRecMsg);
                    string strMsg = Encoding.UTF8.GetString(arrRecMsg, 0, length);

                    string typeMsg = strMsg.Split('*')[0];
                    string info = strMsg.Substring(2);

                    switch (typeMsg)
                    {
                        //其他用户上线的通知
                        case "1":
                            lb_users.Items.Add(info);
                            lb_showMsg.Items.Add("用户" + info.Split('|')[0] + "上线啦！");
                            lb_showMsg.SelectedIndex = lb_showMsg.Items.Count - 1;
                            break;

                        //获取用户在线列表
                        case "2":
                            string[] list = info.Split('&');
                            for (int i = 0; i < list.Length - 1; i++)
                            {
                                lb_users.Items.Add(list[i]);
                            }
                            break;

                        //其他用户退出的通知
                        case "3":
                            lb_users.Items.Remove(info);
                            lb_showMsg.Items.Add(info.Split('|')[0] + "退出了登录");
                            lb_showMsg.SelectedIndex = lb_showMsg.Items.Count - 1;
                            break;

                        //收到群聊的消息
                        case "4":
                            lb_showMsg.Items.Add(info);
                            lb_showMsg.SelectedIndex = lb_showMsg.Items.Count - 1;
                            break;

                        //收到单聊的消息
                        case "5":
                            info = strMsg.Split('*')[1];
                            lb_showMsg.Items.Add(info);
                            lb_showMsg.SelectedIndex = lb_showMsg.Items.Count - 1;
                            break;

                        //收到管理员的广播
                        case "6":
                            lb_showMsg.Items.Add("管理员:" + info);
                            lb_showMsg.SelectedIndex = lb_showMsg.Items.Count - 1;
                            break;

                        //收到服务器被关闭的通知
                        case "7":
                            lb_showMsg.Items.Add("聊天服务器已被关闭，谢谢您的使用。");
                            lb_showMsg.SelectedIndex = lb_showMsg.Items.Count - 1;
                            safeClose();
                            isntStop = false;
                            break;
                        //收到服务器确认用户退出的通知
                        case "8":
                            safeClose();
                            isntStop = false;
                            break;
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }

        //点击发送信息按钮
        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                if (lb_users.SelectedIndex == -1)
                {
                    //如果是向所有人发送消息
                    string sendMsg = "4*" + tb_loginName.Text + "*" + tb_inputMsg.Text.Trim();
                    byte[] arrClientSendMsg = Encoding.UTF8.GetBytes(sendMsg);
                    socketClient.Send(arrClientSendMsg);
                }
                else
                {
                    //如果是指定向某个用户发送消息
                    string user = lb_users.SelectedItem.ToString();
                    string sendMsg = "5*" + tb_loginName.Text + "*" + user + "*" + tb_inputMsg.Text.Trim();
                    byte[] arrClientSendMsg = Encoding.UTF8.GetBytes(sendMsg);
                    socketClient.Send(arrClientSendMsg);
                    lb_showMsg.Items.Add("你对 " + user.Split('|')[0] + " 说：" + tb_inputMsg.Text.Trim());
                    lb_showMsg.SelectedIndex = lb_showMsg.Items.Count - 1;
                }
                tb_inputMsg.Text = "";

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //安全关闭socket
        public void safeClose()
        {
            try
            {
                if (socketClient == null)
                    return;

                if (!socketClient.Connected)
                    return;

                socketClient.Shutdown(SocketShutdown.Both);
                socketClient.Close();
            }
            catch
            {
            }

            lb_showMsg.Items.Add("您已退出了聊天室");
            lb_showMsg.Items.Add("---------以上为历史聊天记录-----------");
            lb_users.Items.Clear();
            setRestStatus();

        }

        //退出登陆
        private void btn_loginOut_Click(object sender, EventArgs e)
        {
            byte[] arrClientSendMsg = Encoding.UTF8.GetBytes("3*");
            socketClient.Send(arrClientSendMsg);
        }

        //关闭窗体
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (isModify && socketClient != null)
                {
                    if (MessageBox.Show("输入区已经改动但未发送，您还要继续关闭吗", "确认关闭", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        byte[] arrClientSendMsg = Encoding.UTF8.GetBytes("3*");
                        socketClient.Send(arrClientSendMsg);
                        return;
                    }
                    e.Cancel = true;
                }

                if (socketClient != null && socketClient.Connected)
                {
                    byte[] arrClientSendMsg = Encoding.UTF8.GetBytes("3*");
                    socketClient.Send(arrClientSendMsg);
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }


        }

        //服务未开启时控件的可用性
        public void setRestStatus()
        {
            tb_loginName.Enabled = true;
            tb_inputMsg.Enabled = false;
            btn_send.Enabled = false;
            btn_login.Enabled = true;
            btn_loginOut.Enabled = false;

        }

        //服务开启时控件的可用性
        public void setWorkStatus()
        {
            tb_loginName.Enabled = false;
            btn_loginOut.Enabled = true;
            btn_send.Enabled = true;
            btn_login.Enabled = false;
            tb_inputMsg.Enabled = true;
        }

        //如果聊天窗口存在未发送的消息
        private void tb_inputMsg_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_inputMsg.Text.Trim()))
            {
                isModify = true;
            }
            else
            {
                isModify = false;
            }
        }

        //当点击用户列表空白处，取消选择单聊对象
        private void lb_users_MouseClick(object sender, MouseEventArgs e)
        {
            var index = lb_users.IndexFromPoint(e.X, e.Y);
            lb_users.SelectedIndex = index;
        }
    }
}
