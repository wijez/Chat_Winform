namespace Server
{
    partial class Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
            label1 = new Label();
            pnlListClient = new Panel();
            listBox1 = new ListBox();
            pnlMainServer = new Panel();
            button2 = new Button();
            pnlEmojiServer = new Panel();
            pnlInputServer = new Panel();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            btnEmojiServer = new Button();
            btnFileServer = new Button();
            btnImageServer = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pnlListClient.SuspendLayout();
            pnlMainServer.SuspendLayout();
            pnlInputServer.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(255, 255, 128);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(10);
            label1.Size = new Size(154, 74);
            label1.TabIndex = 3;
            label1.Text = "Server";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // pnlListClient
            // 
            pnlListClient.AutoScroll = true;
            pnlListClient.BackColor = SystemColors.Window;
            pnlListClient.Controls.Add(listBox1);
            pnlListClient.Dock = DockStyle.Left;
            pnlListClient.Location = new Point(0, 74);
            pnlListClient.Name = "pnlListClient";
            pnlListClient.Size = new Size(153, 376);
            pnlListClient.TabIndex = 4;
            pnlListClient.Paint += pnlListClient_Paint;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(3, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(145, 379);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // pnlMainServer
            // 
            pnlMainServer.AutoScroll = true;
            pnlMainServer.BackColor = SystemColors.Window;
            pnlMainServer.Controls.Add(button2);
            pnlMainServer.Controls.Add(pnlEmojiServer);
            pnlMainServer.Controls.Add(pnlInputServer);
            pnlMainServer.Dock = DockStyle.Right;
            pnlMainServer.Location = new Point(154, 0);
            pnlMainServer.Name = "pnlMainServer";
            pnlMainServer.Size = new Size(646, 450);
            pnlMainServer.TabIndex = 5;
            pnlMainServer.Paint += pnlMainServer_Paint;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ScrollBar;
            button2.Location = new Point(590, 14);
            button2.Name = "button2";
            button2.Size = new Size(53, 23);
            button2.TabIndex = 6;
            button2.Text = "accept";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pnlEmojiServer
            // 
            pnlEmojiServer.AutoScroll = true;
            pnlEmojiServer.BackColor = SystemColors.ScrollBar;
            pnlEmojiServer.Location = new Point(62, 121);
            pnlEmojiServer.Name = "pnlEmojiServer";
            pnlEmojiServer.Size = new Size(240, 169);
            pnlEmojiServer.TabIndex = 6;
            pnlEmojiServer.Paint += pnlEmojiServer_Paint;
            // 
            // pnlInputServer
            // 
            pnlInputServer.AutoScroll = true;
            pnlInputServer.Controls.Add(richTextBox1);
            pnlInputServer.Controls.Add(button1);
            pnlInputServer.Controls.Add(btnEmojiServer);
            pnlInputServer.Controls.Add(btnFileServer);
            pnlInputServer.Controls.Add(btnImageServer);
            pnlInputServer.Dock = DockStyle.Bottom;
            pnlInputServer.Location = new Point(0, 370);
            pnlInputServer.Name = "pnlInputServer";
            pnlInputServer.Size = new Size(646, 80);
            pnlInputServer.TabIndex = 5;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(14, 32);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(445, 44);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(479, 32);
            button1.Name = "button1";
            button1.Size = new Size(105, 44);
            button1.TabIndex = 3;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnEmojiServer
            // 
            btnEmojiServer.Image = (Image)resources.GetObject("btnEmojiServer.Image");
            btnEmojiServer.Location = new Point(81, 3);
            btnEmojiServer.Name = "btnEmojiServer";
            btnEmojiServer.Size = new Size(32, 23);
            btnEmojiServer.TabIndex = 2;
            btnEmojiServer.UseVisualStyleBackColor = true;
            btnEmojiServer.Click += btnEmojiServer_Click;
            // 
            // btnFileServer
            // 
            btnFileServer.Image = (Image)resources.GetObject("btnFileServer.Image");
            btnFileServer.Location = new Point(43, 3);
            btnFileServer.Name = "btnFileServer";
            btnFileServer.Size = new Size(32, 23);
            btnFileServer.TabIndex = 1;
            btnFileServer.UseVisualStyleBackColor = true;
            btnFileServer.Click += btnFileServer_Click;
            // 
            // btnImageServer
            // 
            btnImageServer.Image = (Image)resources.GetObject("btnImageServer.Image");
            btnImageServer.Location = new Point(5, 3);
            btnImageServer.Name = "btnImageServer";
            btnImageServer.Size = new Size(32, 23);
            btnImageServer.TabIndex = 0;
            btnImageServer.UseVisualStyleBackColor = true;
            btnImageServer.Click += btnImageServer_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = SystemColors.Window;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(154, 74);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(646, 293);
            flowLayoutPanel1.TabIndex = 7;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlListClient);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(pnlMainServer);
            MaximumSize = new Size(816, 489);
            Name = "Server";
            Text = "Server";
            pnlListClient.ResumeLayout(false);
            pnlMainServer.ResumeLayout(false);
            pnlInputServer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel pnlListClient;
        private Panel pnlMainServer;
        private Panel pnlEmojiServer;
        private Panel pnlInputServer;
        private RichTextBox richTextBox1;
        private Button button1;
        private Button btnEmojiServer;
        private Button btnFileServer;
        private Button btnImageServer;
        private ListBox listBox1;
        private Button button2;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}