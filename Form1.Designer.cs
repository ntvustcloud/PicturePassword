namespace PicturePassword
{
    partial class frmContainer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pbxLoadImg = new PictureBox();
            btnCancel = new Button();
            lblTitle = new Label();
            lblInstruction = new Label();
            btnChoose = new Button();
            btnUseThisPicture = new Button();
            lblNum1 = new Label();
            lblNum2 = new Label();
            lblNum3 = new Label();
            btnFinish = new Button();
            btnStartOver = new Button();
            btnTryAgain = new Button();
            txtUsername = new TextBox();
            lblUsername = new Label();
            erpUsername = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pbxLoadImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)erpUsername).BeginInit();
            SuspendLayout();
            // 
            // pbxLoadImg
            // 
            pbxLoadImg.Image = Properties.Resources.flower;
            pbxLoadImg.Location = new Point(200, 0);
            pbxLoadImg.Name = "pbxLoadImg";
            pbxLoadImg.Size = new Size(735, 661);
            pbxLoadImg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxLoadImg.TabIndex = 0;
            pbxLoadImg.TabStop = false;
            pbxLoadImg.Click += pbxLoadImg_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(119, 630);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 25);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(6, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(189, 52);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Wellcome to Picture Password";
            // 
            // lblInstruction
            // 
            lblInstruction.Location = new Point(6, 61);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(189, 41);
            lblInstruction.TabIndex = 5;
            lblInstruction.Text = "Use the default picture or choose your own picture";
            // 
            // btnChoose
            // 
            btnChoose.FlatStyle = FlatStyle.Flat;
            btnChoose.Location = new Point(6, 175);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new Size(100, 25);
            btnChoose.TabIndex = 0;
            btnChoose.Text = "Choose Picture";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += btnChoose_Click_1;
            // 
            // btnUseThisPicture
            // 
            btnUseThisPicture.FlatStyle = FlatStyle.Flat;
            btnUseThisPicture.Location = new Point(6, 206);
            btnUseThisPicture.Name = "btnUseThisPicture";
            btnUseThisPicture.Size = new Size(100, 25);
            btnUseThisPicture.TabIndex = 1;
            btnUseThisPicture.Text = "Use This Picture";
            btnUseThisPicture.UseVisualStyleBackColor = true;
            btnUseThisPicture.Click += btnUseThisPicture_Click;
            // 
            // lblNum1
            // 
            lblNum1.AutoSize = true;
            lblNum1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblNum1.ForeColor = Color.DarkGray;
            lblNum1.Location = new Point(12, 140);
            lblNum1.Name = "lblNum1";
            lblNum1.Size = new Size(28, 32);
            lblNum1.TabIndex = 6;
            lblNum1.Text = "1";
            lblNum1.Visible = false;
            // 
            // lblNum2
            // 
            lblNum2.AutoSize = true;
            lblNum2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblNum2.ForeColor = Color.DarkGray;
            lblNum2.Location = new Point(57, 140);
            lblNum2.Name = "lblNum2";
            lblNum2.Size = new Size(28, 32);
            lblNum2.TabIndex = 7;
            lblNum2.Text = "2";
            lblNum2.Visible = false;
            // 
            // lblNum3
            // 
            lblNum3.AutoSize = true;
            lblNum3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblNum3.ForeColor = Color.DarkGray;
            lblNum3.Location = new Point(102, 140);
            lblNum3.Name = "lblNum3";
            lblNum3.Size = new Size(28, 32);
            lblNum3.TabIndex = 0;
            lblNum3.Text = "3";
            lblNum3.Visible = false;
            // 
            // btnFinish
            // 
            btnFinish.FlatStyle = FlatStyle.Flat;
            btnFinish.Location = new Point(119, 630);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(75, 25);
            btnFinish.TabIndex = 3;
            btnFinish.Text = "Finish";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Visible = false;
            btnFinish.Click += btnFinish_Click;
            // 
            // btnStartOver
            // 
            btnStartOver.FlatStyle = FlatStyle.Flat;
            btnStartOver.Location = new Point(38, 630);
            btnStartOver.Name = "btnStartOver";
            btnStartOver.Size = new Size(75, 25);
            btnStartOver.TabIndex = 3;
            btnStartOver.Text = "Start Over";
            btnStartOver.UseVisualStyleBackColor = true;
            btnStartOver.Visible = false;
            btnStartOver.Click += btnStartOver_Click;
            // 
            // btnTryAgain
            // 
            btnTryAgain.FlatStyle = FlatStyle.Flat;
            btnTryAgain.Location = new Point(6, 105);
            btnTryAgain.Name = "btnTryAgain";
            btnTryAgain.Size = new Size(75, 25);
            btnTryAgain.TabIndex = 3;
            btnTryAgain.Text = "Try Again";
            btnTryAgain.UseVisualStyleBackColor = true;
            btnTryAgain.Visible = false;
            btnTryAgain.Click += btnTryAgain_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(6, 148);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(172, 23);
            txtUsername.TabIndex = 8;
            txtUsername.Visible = false;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(6, 132);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 9;
            lblUsername.Text = "Username";
            lblUsername.Visible = false;
            // 
            // erpUsername
            // 
            erpUsername.ContainerControl = this;
            // 
            // frmContainer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(934, 661);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblNum3);
            Controls.Add(lblNum2);
            Controls.Add(lblNum1);
            Controls.Add(lblInstruction);
            Controls.Add(lblTitle);
            Controls.Add(btnUseThisPicture);
            Controls.Add(btnChoose);
            Controls.Add(btnTryAgain);
            Controls.Add(btnStartOver);
            Controls.Add(btnFinish);
            Controls.Add(btnCancel);
            Controls.Add(pbxLoadImg);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmContainer";
            Text = "Picture Password";
            ((System.ComponentModel.ISupportInitialize)pbxLoadImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)erpUsername).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxLoadImg;
        private Button btnCancel;
        private Label lblTitle;
        private Label lblInstruction;
        private Button btnChoose;
        private Button btnUseThisPicture;
        private Label lblNum1;
        private Label lblNum2;
        private Label lblNum3;
        private Button btnFinish;
        private Button btnStartOver;
        private Button btnTryAgain;
        private TextBox txtUsername;
        private Label lblUsername;
        private ErrorProvider erpUsername;
    }
}
