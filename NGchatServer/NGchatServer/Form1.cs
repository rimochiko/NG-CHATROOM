using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace NGchatServer
{
    public partial class Form1 : Form
    {
        //初始化窗体
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            setRestStatus();
        }

        Thread threadWatch = null;
        Socket socketWatch = null;
        Socket socConnection = null;
        bool isntStop = true;

        //创建字典收录所有客户端
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();

        //开启服务
        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                //开启监听端口
                socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint endpoint = new IPEndPoint(ipaddress, 7788);

                //Socket绑定端口且开始监听连接
                socketWatch.Bind(endpoint);
                socketWatch.Listen(20);

                //创建监听线程
                threadWatch = new Thread(watchConnecting);
                threadWatch.IsBackground = true;
                threadWatch.Start();

                lb_info.Items.Add("聊天室服务已经开启啦");
                setWorkStatus();
                isntStop = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
        }


        //创建监听函数
        public void watchConnecting()
        {
            try
            {
                while (isntStop)
                {
                    socConnection = socketWatch.Accept();
                    //创建通信线程
                    ParameterizedThreadStart pts = new ParameterizedThreadStart(serverRecMsg);
                    Thread thr = new Thread(pts);
                    thr.IsBackground = true;
                    thr.Start(socConnection);
                }
            }
            catch
            {
            }
        }

        //服务器接收信息
        public void serverRecMsg(object socketClientPara)
        {
            try
            {
                Socket socketServer = socketClientPara as Socket;
                while (isntStop)
                {
                    //创建一个对象保存获得消息
                    byte[] arrServerRecMsg = new byte[1024 * 1024];
                    int length = socketServer.Receive(arrServerRecMsg);
                    string strMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, length);
                    string typeMsg = strMsg.Split('*')[0];
                    string info = strMsg.Substring(2);
                    string user = "";

                    switch (typeMsg)
                    {
                        //其他用户上线的通知
                        case "1":
                            serverRecList(socketServer);
                            serverRecNewLogin(socketServer, info);
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
                            exitChat(socketServer);
                            break;

                        //收到群聊请求消息
                        case "4":
                            user = strMsg.Split('*')[1];
                            info = info.Substring(user.Length + 1);

                            foreach (var item in dicSocket)
                            {
                                string sendMsg = "4*" + user + "说：" + info;
                                byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendMsg);
                                item.Value.Send(arrSendMsg);
                            }
                            lb_info.Items.Add(user + "说：" + info);
                            lb_info.SelectedIndex = lb_info.Items.Count - 1;
                            break;

                        //收到单聊请求消息
                        case "5":
                            user = strMsg.Split('*')[1];
                            string other = strMsg.Split('*')[2];
                            info = info.Substring(user.Length + +other.Length + 2);

                            foreach (var item in dicSocket)
                            {
                                if (item.Key == other)
                                {
                                    string sendMsg = "5*" + user + " 对你说：" + info;
                                    byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendMsg);
                                    item.Value.Send(arrSendMsg);
                                    break;
                                }

                            }
                            break;
                    }
                }
            }
            catch
            {
            }
        }

        //获取用户信息
        public void serverRecNewLogin(object socketClientPara, string info)
        {
            try
            {
                IPAddress clientIP;
                int clientPort;

                //获取客户端IP
                clientIP = (socConnection.RemoteEndPoint as IPEndPoint).Address;
                //获取客户端端口
                clientPort = (socConnection.RemoteEndPoint as IPEndPoint).Port;

                string sendMsg = "1*" + info + "|" + clientIP + "|" + clientPort;
                byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendMsg);

                //发送所有在线用户新用户的上线通知
                foreach (var item in dicSocket)
                {
                    item.Value.Send(arrSendMsg);
                }

                lb_users.Items.Add(info + "|" + clientIP + "|" + clientPort);
                dicSocket.Add(info + "|" + clientIP + "|" + clientPort, socConnection);
                lb_info.Items.Add(info + "上线啦！");
                lb_info.SelectedIndex = lb_info.Items.Count - 1;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }

        //获取在线用户
        public void serverRecList(object socketClientPara)
        {
            try
            {
                Socket socketServer = socketClientPara as Socket;
                //如果有在线用户则发送
                if (dicSocket.Count != 0)
                {
                    string info = "2*";
                    foreach (var item in dicSocket)
                    {
                        info = info + item.Key + "&";
                    }

                    //向新登陆用户通知已登陆的用户清单
                    byte[] arrSendMsg = Encoding.UTF8.GetBytes(info);
                    socketServer.Send(arrSendMsg);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //管理员发送消息
        private void btn_send_Click(object sender, EventArgs e)
        {
            string sendMsg = "6*" + tb_sendInfo.Text.Trim();
            byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendMsg);

            try
            {
                if (lb_users.SelectedIndex == -1)
                {
                    foreach (var item in dicSocket)
                    {
                        item.Value.Send(arrSendMsg);
                    }
                }
                else
                {
                    string selectClient = lb_users.SelectedItem.ToString();
                    dicSocket[selectClient].Send(arrSendMsg);

                }
                lb_info.Items.Add("管理员：" + tb_sendInfo.Text.Trim());
                lb_info.SelectedIndex = lb_info.Items.Count - 1;
                tb_sendInfo.Text = "";

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //用户退出登陆
        public void exitChat(object socketClientPara)
        {
            try
            {
                Socket socketServer = socketClientPara as Socket;
                string info = "";

                //允许退出用户的退出
                byte[] arrSendMsg = Encoding.UTF8.GetBytes("8*");
                socketServer.Send(arrSendMsg);

                foreach (var item in dicSocket)
                {
                    if (item.Value == socketServer)
                    {
                        info = item.Key;
                        break;
                    }
                }

                dicSocket.Remove(info);
                lb_users.Items.Remove(info);
                string sendMsg = "3*" + info;

                //向所有用户通知这个用户退出
                arrSendMsg = Encoding.UTF8.GetBytes(sendMsg);
                lb_info.Items.Add(info + "已经退出了登录");
                lb_info.SelectedIndex = lb_info.Items.Count - 1;

                foreach (var item in dicSocket)
                {
                    item.Value.Send(arrSendMsg);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //管理员关闭服务器
        private void btn_close_Click(object sender, EventArgs e)
        {
            try
            {
                string sendMsg = "7*";
                byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendMsg);
                foreach (var item in dicSocket)
                {
                    item.Value.Send(arrSendMsg);
                }

                if (socketWatch == null)
                    return;

                setRestStatus();
                isntStop = false;
                socketWatch.Close();
                threadWatch.Abort();

                foreach (var item in dicSocket)
                {
                    item.Value.Close();
                    lb_users.Items.Clear();
                }
                dicSocket.Clear();
                socketWatch = null;

                lb_info.Items.Add("服务器已关闭服务");
                lb_info.SelectedIndex = lb_info.Items.Count - 1;
            }
            catch
            {
            }
        }

        public void setRestStatus() 
        {
            btn_send.Enabled = false;
            tb_sendInfo.Enabled = false;
            btn_close.Enabled = false;
        }

        public void setWorkStatus() 
        {
            btn_send.Enabled = true;
            tb_sendInfo.Enabled = true;
            btn_start.Enabled = false;
            btn_close.Enabled = true; 
        }

        private void lb_users_MouseClick(object sender, MouseEventArgs e)
        {
            var index = lb_users.IndexFromPoint(e.X, e.Y);
            lb_users.SelectedIndex = index;
        }
    }
}
