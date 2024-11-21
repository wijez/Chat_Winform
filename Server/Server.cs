using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Server
{
    public partial class Server : Form
    {
        private TcpListener tcpListener;
        private NetworkStream networkStream;
        private List<TcpClient> connectedClients= new List<TcpClient>();
        private List<ClientInfo> connectedInfoTCP = new List<ClientInfo>();
        private string tempImagePath;
        private bool isImageSent = false;


        public Server()
        {
            InitializeComponent();
        }

        private void StartServer()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 12345);
                tcpListener.Start();
                MessageBox.Show("Server started. Waiting for clients...");
                Task.Run(() => AcceptClientsAsync());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connect : {ex.Message}");
            }
        }

        private async Task AcceptClientsAsync()
        {
            while (true)
            {
                try
                {
                    TcpClient client = await tcpListener.AcceptTcpClientAsync();
                    var clientInfomation = new ClientInfo
                    {
                        Client = client,
                        ClientName = client.Client.RemoteEndPoint.ToString()
                    };
                    lock (connectedClients)
                    {
                        connectedClients.Add(client);
                        connectedInfoTCP.Add(clientInfomation);
                    }

                    string clientInfo = client.Client.RemoteEndPoint.ToString();
                    if (listBox1.InvokeRequired)
                    {
                        listBox1.Invoke(new Action(() => listBox1.Items.Add(clientInfo)));
                    }
                    else
                    {
                        listBox1.Items.Add(clientInfo);
                    }

                    MessageBox.Show("Client connected.");
                    _ = Task.Run(() => HandleClient(client));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error accepting client: {ex.Message}");
                }
            }
        }

        //private async Task AcceptClientsAsynciNFO()
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            TcpClient client = await tcpListener.AcceptTcpClientAsync();
        //            var clientInfo = new ClientInfo
        //            {
        //                Client = client,
        //                ClientName = client.Client.RemoteEndPoint.ToString()
        //            };

        //            lock (connectedClients)
        //            {
        //                connectedClients.Add(clientInfo);
        //            }

        //            // Cập nhật listBox1
        //            listBox1.Invoke(new Action(() =>
        //            {
        //                _ = listBox1.Items.Add(clientInfo.ClientName);
        //            }));

        //            _ = Task.Run(() => HandleClient(client));
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error accepting client: {ex.Message}");
        //        }
        //    }
        //}


        private void ConfigureFlowLayoutPanel()
        {
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;

            flowLayoutPanel1.AutoScroll = true;

            flowLayoutPanel1.WrapContents = true;

            flowLayoutPanel1.Dock = DockStyle.Fill;
        }

        private void DisplayMessage(string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");

            Button btnDelete = new Button
            {
                Text = "X",
                Dock = DockStyle.Right,
                Width = 30,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Red,
                ForeColor = Color.White
            };

            Panel messagePanel = new Panel
            {
                Width = flowLayoutPanel1.ClientSize.Width - 20,
                Height = 50,
                Margin = new Padding(5)
            };

            Label lblTimestamp = new Label
            {
                Text = timestamp,
                Dock = DockStyle.Right,
                Width = 60,
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = Color.Gray
            };

            Label lblMessage = new Label
            {
                Text = message,
                Dock = DockStyle.Fill,
                Padding = new Padding(15),
                TextAlign = ContentAlignment.MiddleLeft,
                BorderStyle = BorderStyle.FixedSingle
            };

            if (message.StartsWith("Me:"))
            {
                lblMessage.BackColor = Color.LightBlue;

            }
            else if (message.StartsWith("Server:"))
            {
                lblMessage.BackColor = Color.LightGreen;
            }
            else if (message.StartsWith("Client:"))
            {
                lblMessage.BackColor = Color.AliceBlue;
            }

            btnDelete.Click += (sender, e) =>
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tin nhắn này?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    flowLayoutPanel1.Controls.Remove(messagePanel);
                    messagePanel.Dispose();
                }
            };

            messagePanel.Controls.Add(btnDelete);
            messagePanel.Controls.Add(lblTimestamp);
            messagePanel.Controls.Add(lblMessage);


            messagePanel.Controls.Add(lblTimestamp);
            messagePanel.Controls.Add(lblMessage);

            flowLayoutPanel1.Controls.Add(messagePanel);
            flowLayoutPanel1.ScrollControlIntoView(messagePanel);

        }

        private void DisplayImage(string imagePath)
        {
            try
            {
                isImageSent = true;
                int maxWidth = 300;
                int maxHeight = 300;

                Image originalImage = Image.FromFile(tempImagePath);

                double scaleFactor = Math.Min((double)maxWidth / originalImage.Width, (double)maxHeight / originalImage.Height);

                int newWidth = (int)(originalImage.Width * scaleFactor);
                int newHeight = (int)(originalImage.Height * scaleFactor);

                Image resizedImage = new Bitmap(originalImage, newWidth, newHeight);

                PictureBox pictureBox = new PictureBox
                {
                    Image = resizedImage,
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    Margin = new Padding(5)
                };

                string timestamp = DateTime.Now.ToString("HH:mm:ss");

                Button btnDelete = new Button
                {
                    Text = "X",
                    Dock = DockStyle.Right,
                    Width = 30,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Red,
                    ForeColor = Color.White
                };

                Label lblTimestamp = new Label
                {
                    Text = timestamp,
                    Dock = DockStyle.Right,
                    Width = 60,
                    TextAlign = ContentAlignment.MiddleRight,
                    ForeColor = Color.Gray
                };


                flowLayoutPanel1.Controls.Add(pictureBox);
                flowLayoutPanel1.ScrollControlIntoView(pictureBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying image: {ex.Message}");
            }
        }

        private void AddDeleteButtonForMessage(Control messageControl)
        {
            Button btnDelete = new Button();
            btnDelete.Text = "Xóa";
            btnDelete.Click += (sender, e) =>
            {
                flowLayoutPanel1.Controls.Remove(messageControl);
            };

            flowLayoutPanel1.Controls.Add(btnDelete);
        }

        private void DisplayMessageWithDelete(string message)
        {
            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.AutoSize = true;
            lblMessage.Margin = new Padding(5);

            flowLayoutPanel1.Controls.Add(lblMessage);
            AddDeleteButtonForMessage(lblMessage);
        }


        private async Task HandleClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    if (flowLayoutPanel1.InvokeRequired)
                    {
                        flowLayoutPanel1.Invoke(new Action(() => DisplayMessage($"Client: {message}")));
                    }
                    else
                    {
                        DisplayMessage($"Client: {message}");
                    }

                    await BroadcastMessage($"Server broadcast: {message}", client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error accepting client: {ex.Message}");
            }

        }

        private async Task HandleImageMessage(string message, TcpClient client)
        {
            try
            {
                string base64Image = message.Substring(6);
                byte[] imageBytes = Convert.FromBase64String(base64Image);
                string tempImagePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.jpg");
                File.WriteAllBytes(tempImagePath, imageBytes);

                if (flowLayoutPanel1.InvokeRequired)
                {
                    flowLayoutPanel1.Invoke(new Action(() => DisplayImage(tempImagePath)));
                }
                else
                {
                    DisplayImage(tempImagePath);
                }

                await BroadcastMessage(message, client);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing image: {ex.Message}");
            }
        }

        private async Task BroadcastMessage(string message, TcpClient? excludeClient = null)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            if (connectedClients == null || connectedClients.Count == 0)
            {
                Console.WriteLine("No clients are connected.");
                return;
            }

            lock (connectedClients)
            {
                foreach (var client in connectedClients)
                {
                    if (client != excludeClient && client.Connected)
                    {
                        try
                        {
                            NetworkStream stream = client.GetStream();
                            stream.Write(messageBytes, 0, messageBytes.Length);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error broadcasting to client: {ex.Message}");
                        }
                    }
                }
            }
        }


        private void SendMessage(string message)
        {
            if (networkStream != null)
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                networkStream.Write(messageBytes, 0, messageBytes.Length);
            }
        }
        private async void StartListeningForMessages()
        {
            while (true)
            {
                await ReceiveMessage();
            }
        }

        private async Task ReceiveMessage()
        {
            if (networkStream != null)
            {
                byte[] buffer = new byte[1024];
                int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);

                if (bytesRead > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() => DisplayMessage(message)));
                    }
                    else
                    {
                        DisplayMessage(message);
                    }
                }
            }
        }

        private void btnImageServer_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                SendImage(imagePath);
            }
        }

        private async void SendImage(string imagePath)
        {
            try
            {
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                string base64Image = Convert.ToBase64String(imageBytes);
                string message = $"IMAGE:{base64Image}";

                await BroadcastMessage(message);

                DisplayImage(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending image: {ex.Message}");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (isImageSent)
            {
                return;
            }

            string message = richTextBox1.Text;

            if (!string.IsNullOrEmpty(message))
            {
                DisplayMessage($"Server: {message}");
                await BroadcastMessage($"Server: {message}");
                richTextBox1.Clear();
            }

        }

        private async Task SendMessageToSelectedClientsAsync(string message)
        {
            try
            {
                var selectedClients = listBox1.SelectedItems;

                foreach (var selectedClientName in selectedClients)
                {
                    var clientInfomation = connectedInfoTCP.FirstOrDefault(c => c.ClientName == selectedClientName.ToString());

                    if (clientInfomation != null)
                    {
                        await SendMessageToClient(clientInfomation.Client, message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private async Task SendMessageToClient(TcpClient client, string message)
        {
            try
            {
                if (client.Connected)
                {
                    NetworkStream stream = client.GetStream();

                    byte[] data = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(data, 0, data.Length);
                }
                else
                {
                    MessageBox.Show("Client is disconnected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message to client: {ex.Message}");
            }
        }

        private void RemoveDisconnectedClient(ClientInfo clientInfo)
        {
            lock (connectedClients)
            {
                connectedClients.Remove(clientInfo);
            }

            listBox1.Invoke(new Action(() =>
            {
                listBox1.Items.Remove(clientInfo.ClientName);
            }));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String message = richTextBox1.Text;
            if (!string.IsNullOrWhiteSpace(message))
            {
                _ = SendMessageToSelectedClientsAsync(message);
            }
        }
    }
}
