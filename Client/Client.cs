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
using System.IO;


namespace Client
{
    public partial class Client : Form
    {
        private Dictionary<Guid, Panel> messagePanels = new Dictionary<Guid, Panel>();
        private TcpClient tcpClient;
        private NetworkStream networkStream;

        public Client()
        {
            InitializeComponent();
            ConfigureFlowLayoutPanel();
        }

        private void ConnectToServer()
        {
            try
            {
                tcpClient = new TcpClient("127.0.0.1", 12345);
                networkStream = tcpClient.GetStream();
                Task.Run(() => ReceiveMessage());
                MessageBox.Show($"TcpClient Connected: {tcpClient.Connected}");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
            }
        }


        private async Task ReceiveMessage()
        {
            try
            {
                byte[] buffer = new byte[1024 * 1024 * 5]; // Tăng buffer lên 5MB
                int bytesRead;

                while ((bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    if (bytesRead == 0)
                    {
                        DisplayMessage("Connection closed by server.");
                        break;
                    }

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Xử lý ảnh
                    if (message.StartsWith("IMAGE:"))
                    {
                        try
                        {
                            string base64Image = message.Substring(6);

                            if (string.IsNullOrWhiteSpace(base64Image) || !IsBase64String(base64Image))
                            {
                                throw new InvalidOperationException("Invalid Base64 data.");
                            }

                            byte[] imageBytes = Convert.FromBase64String(base64Image);

                            string tempImagePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.jpg");
                            File.WriteAllBytes(tempImagePath, imageBytes);

                            if (InvokeRequired)
                            {
                                Invoke(new Action(() => DisplayImage(tempImagePath)));
                            }
                            else
                            {
                                DisplayImage(tempImagePath);
                            }
                        }
                        catch (Exception imgEx)
                        {
                            Console.WriteLine($"Error processing image: {imgEx.Message}");
                        }
                    }
                    else if (message.StartsWith("FILE:"))
                    {
                        try
                        {
                            string[] fileParts = message.Split(new[] { ':' }, 3);
                            if (fileParts.Length < 3)
                            {
                                throw new FormatException("Invalid file format.");
                            }

                            string fileName = fileParts[1];
                            string base64File = fileParts[2];

                            if (string.IsNullOrWhiteSpace(base64File) || !IsBase64String(base64File))
                            {
                                throw new InvalidOperationException("Invalid Base64 data.");
                            }

                            byte[] fileBytes = Convert.FromBase64String(base64File);

                            string saveDirectory = Path.Combine(Application.StartupPath, "ReceivedFiles");
                            Directory.CreateDirectory(saveDirectory);
                            string filePath = Path.Combine(saveDirectory, fileName);

                            File.WriteAllBytes(filePath, fileBytes);

                            DisplayMessage($"Received file: {fileName}");
                        }
                        catch (Exception fileEx)
                        {
                            Console.WriteLine($"Error processing file: {fileEx.Message}");
                        }
                    }
                    else if (message.StartsWith("EMOJI:"))
                    {
                        string emoji = message.Substring(6);
                        DisplayMessage($"Server: {emoji}");
                    }
                    else
                    {
                        if (InvokeRequired)
                        {
                            Invoke(new Action(() => DisplayMessage(message)));
                        }
                        else
                        {
                            DisplayMessage(message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error receiving message: {ex.Message}");
            }
        }

        private bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out _);
        }


        private void DisplayImage(string tempImagePath)
        {
            try
            {
                using Image originalImage = Image.FromFile(tempImagePath);

                int maxWidth = 300;
                int maxHeight = 300;
                double scaleFactor = Math.Min((double)maxWidth / originalImage.Width, (double)maxHeight / originalImage.Height);

                int newWidth = (int)(originalImage.Width * scaleFactor);
                int newHeight = (int)(originalImage.Height * scaleFactor);

                using Image resizedImage = new Bitmap(originalImage, newWidth, newHeight);

                PictureBox pictureBox = new PictureBox
                {
                    Image = (Image)resizedImage.Clone(), // Clone to retain ownership after disposal
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    Margin = new Padding(5)
                };

                flowLayoutPanel1.Controls.Add(pictureBox);
                flowLayoutPanel1.ScrollControlIntoView(pictureBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying image: {ex.Message}");
            }
        }

        private void ConfigureFlowLayoutPanel()
        {

            flowLayoutPanel1.AutoScroll = true;

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
            else if (message.StartsWith("Server:") || message.StartsWith("Client:"))
            {
                lblMessage.BackColor = Color.LightGreen;
            }

            btnDelete.Click += (sender, e) =>
            {
                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tin nhắn này?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Xóa toàn bộ panel chứa tin nhắn
                    flowLayoutPanel1.Controls.Remove(messagePanel);
                    messagePanel.Dispose();
                }
            };

            // Thêm các điều khiển vào panel
            messagePanel.Controls.Add(btnDelete);
            messagePanel.Controls.Add(lblTimestamp);
            messagePanel.Controls.Add(lblMessage);

            flowLayoutPanel1.Controls.Add(messagePanel);
            flowLayoutPanel1.ScrollControlIntoView(messagePanel);


        }


        private void SendMessage(string message)
        {
            try
            {
                if (networkStream == null || !tcpClient.Connected)
                {
                    MessageBox.Show("Not connected to the server.");
                    return;
                }

                if (string.IsNullOrEmpty(message))
                {
                    MessageBox.Show("Message is empty.");
                    return;
                }

                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                networkStream.Write(messageBytes, 0, messageBytes.Length);

                DisplayMessage($"Me: {message}");
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"IO Error: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                try
                {
                    SendImage(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending image: {ex.Message}");
                }
            }
        }

        private void SendTextMessage(string text)
        {
            if (networkStream != null && !string.IsNullOrEmpty(text))
            {
                try
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(text);
                    networkStream.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending text message: {ex.Message}");
                }
            }
        }


        private void SendImage(string imagePath)
        {
            try
            {
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                string base64Image = Convert.ToBase64String(imageBytes);
                string message = $"IMAGE:{base64Image}";

                SendMessage(message);
                DisplayImage(imagePath);
                DisplayMessage($"Me: Sent an image");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending image: {ex.Message}");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string message = rtbInput.Text;
           
                SendMessage(message);
                rtbInput.Clear();
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                ConnectToServer();
            }
            else
            {
                DisconnectFromServer();
            }
        }

        private void DisconnectFromServer()
        {
            try
            {
                networkStream?.Close();
                tcpClient?.Close();
                MessageBox.Show("Disconnected from server.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error disconnecting from server: {ex.Message}");
            }
        }

    }
}
