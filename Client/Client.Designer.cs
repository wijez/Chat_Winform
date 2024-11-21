namespace Client
{
    partial class Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            lblInfo = new Label();
            pnlList = new Panel();
            listBox1 = new ListBox();
            flowLayoutPanel1 = new Panel();
            pnlEmoji = new Panel();
            pnlInput = new Panel();
            button1 = new Button();
            rtbInput = new RichTextBox();
            btnEmoji = new Button();
            btnFile = new Button();
            btnImage = new Button();
            radioButton1 = new RadioButton();
            pnlList.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlInput.SuspendLayout();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.BackColor = Color.FromArgb(255, 255, 128);
            lblInfo.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblInfo.ForeColor = SystemColors.ActiveCaption;
            lblInfo.Image = (Image)resources.GetObject("lblInfo.Image");
            lblInfo.ImageAlign = ContentAlignment.MiddleLeft;
            lblInfo.Location = new Point(0, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Padding = new Padding(10);
            lblInfo.Size = new Size(153, 68);
            lblInfo.TabIndex = 3;
            lblInfo.Text = "Message";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlList
            // 
            pnlList.Controls.Add(listBox1);
            pnlList.Location = new Point(0, 71);
            pnlList.Name = "pnlList";
            pnlList.Size = new Size(153, 381);
            pnlList.TabIndex = 4;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 364);
            listBox1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AllowDrop = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(pnlEmoji);
            flowLayoutPanel1.Controls.Add(pnlInput);
            flowLayoutPanel1.Location = new Point(159, 71);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(641, 381);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // pnlEmoji
            // 
            pnlEmoji.BackColor = Color.FromArgb(255, 255, 128);
            pnlEmoji.Location = new Point(67, 146);
            pnlEmoji.Name = "pnlEmoji";
            pnlEmoji.Size = new Size(251, 148);
            pnlEmoji.TabIndex = 6;
            // 
            // pnlInput
            // 
            pnlInput.Controls.Add(button1);
            pnlInput.Controls.Add(rtbInput);
            pnlInput.Controls.Add(btnEmoji);
            pnlInput.Controls.Add(btnFile);
            pnlInput.Controls.Add(btnImage);
            pnlInput.Location = new Point(3, 300);
            pnlInput.Name = "pnlInput";
            pnlInput.Size = new Size(635, 81);
            pnlInput.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(397, 29);
            button1.Name = "button1";
            button1.Size = new Size(75, 38);
            button1.TabIndex = 4;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // rtbInput
            // 
            rtbInput.BorderStyle = BorderStyle.FixedSingle;
            rtbInput.Location = new Point(8, 29);
            rtbInput.Name = "rtbInput";
            rtbInput.Size = new Size(362, 38);
            rtbInput.TabIndex = 3;
            rtbInput.Text = "";
            // 
            // btnEmoji
            // 
            btnEmoji.Image = (Image)resources.GetObject("btnEmoji.Image");
            btnEmoji.Location = new Point(80, 3);
            btnEmoji.Name = "btnEmoji";
            btnEmoji.Size = new Size(30, 23);
            btnEmoji.TabIndex = 2;
            btnEmoji.UseVisualStyleBackColor = true;
            // 
            // btnFile
            // 
            btnFile.Image = (Image)resources.GetObject("btnFile.Image");
            btnFile.Location = new Point(44, 4);
            btnFile.Name = "btnFile";
            btnFile.Size = new Size(30, 23);
            btnFile.TabIndex = 1;
            btnFile.UseVisualStyleBackColor = true;
            // 
            // btnImage
            // 
            btnImage.Image = (Image)resources.GetObject("btnImage.Image");
            btnImage.Location = new Point(8, 4);
            btnImage.Name = "btnImage";
            btnImage.Size = new Size(30, 23);
            btnImage.TabIndex = 0;
            btnImage.UseVisualStyleBackColor = true;
            btnImage.Click += btnImage_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(162, 46);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(70, 19);
            radioButton1.TabIndex = 7;
            radioButton1.TabStop = true;
            radioButton1.Text = "Connect";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(800, 450);
            Controls.Add(radioButton1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(pnlList);
            Controls.Add(lblInfo);
            MaximumSize = new Size(816, 489);
            Name = "Client";
            Text = "Client";
            pnlList.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            pnlInput.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblInfo;
        private Panel pnlList;
        private Panel flowLayoutPanel1;
        private Panel pnlEmoji;
        private Panel pnlInput;
        private Button btnEmoji;
        private Button btnFile;
        private Button btnImage;
        private Button button1;
        private RichTextBox rtbInput;
        private ListBox listBox1;
        private RadioButton radioButton1;
    }
}