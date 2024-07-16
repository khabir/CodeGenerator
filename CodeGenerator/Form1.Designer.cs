namespace CodeGenerator
{
    partial class Form1
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
            sourceFileDialog = new OpenFileDialog();
            destinationFolderPathDialog = new FolderBrowserDialog();
            btnSelectSource = new Button();
            txtSourcePath = new TextBox();
            txtModels = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtDestinationPath = new TextBox();
            btnSelectDestination = new Button();
            btnGenerateCode = new Button();
            lnkDestinationFolder = new LinkLabel();
            lblGeneratedFolder = new Label();
            SuspendLayout();
            // 
            // sourceFileDialog
            // 
            sourceFileDialog.FileName = "sourceFileDialog";
            // 
            // btnSelectSource
            // 
            btnSelectSource.Location = new Point(547, 60);
            btnSelectSource.Name = "btnSelectSource";
            btnSelectSource.Size = new Size(154, 29);
            btnSelectSource.TabIndex = 0;
            btnSelectSource.Text = "Select Source File";
            btnSelectSource.UseVisualStyleBackColor = true;
            btnSelectSource.Click += btnSelectSource_Click;
            // 
            // txtSourcePath
            // 
            txtSourcePath.Location = new Point(191, 62);
            txtSourcePath.Name = "txtSourcePath";
            txtSourcePath.Size = new Size(335, 27);
            txtSourcePath.TabIndex = 1;
            // 
            // txtModels
            // 
            txtModels.Location = new Point(191, 142);
            txtModels.Name = "txtModels";
            txtModels.Size = new Size(335, 135);
            txtModels.TabIndex = 2;
            txtModels.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 69);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 3;
            label1.Text = "Selected File";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 146);
            label2.Name = "label2";
            label2.Size = new Size(140, 20);
            label2.TabIndex = 4;
            label2.Text = "Models to Generate";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 110);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 7;
            label3.Text = "Desination Path";
            // 
            // txtDestinationPath
            // 
            txtDestinationPath.Location = new Point(192, 103);
            txtDestinationPath.Name = "txtDestinationPath";
            txtDestinationPath.Size = new Size(335, 27);
            txtDestinationPath.TabIndex = 6;
            // 
            // btnSelectDestination
            // 
            btnSelectDestination.Location = new Point(548, 101);
            btnSelectDestination.Name = "btnSelectDestination";
            btnSelectDestination.Size = new Size(154, 29);
            btnSelectDestination.TabIndex = 5;
            btnSelectDestination.Text = "Select Destination";
            btnSelectDestination.UseVisualStyleBackColor = true;
            btnSelectDestination.Click += btnSelectDestination_Click;
            // 
            // btnGenerateCode
            // 
            btnGenerateCode.BackColor = Color.Green;
            btnGenerateCode.ForeColor = Color.White;
            btnGenerateCode.ImageAlign = ContentAlignment.MiddleRight;
            btnGenerateCode.Location = new Point(193, 304);
            btnGenerateCode.Name = "btnGenerateCode";
            btnGenerateCode.Size = new Size(333, 50);
            btnGenerateCode.TabIndex = 8;
            btnGenerateCode.Text = "Generate Code";
            btnGenerateCode.UseVisualStyleBackColor = false;
            btnGenerateCode.Click += btnGenerateCode_Click;
            // 
            // lnkDestinationFolder
            // 
            lnkDestinationFolder.AutoSize = true;
            lnkDestinationFolder.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lnkDestinationFolder.Location = new Point(45, 426);
            lnkDestinationFolder.Name = "lnkDestinationFolder";
            lnkDestinationFolder.Size = new Size(260, 35);
            lnkDestinationFolder.TabIndex = 9;
            lnkDestinationFolder.TabStop = true;
            lnkDestinationFolder.Text = "lnkDestinationFolder";
            lnkDestinationFolder.Visible = false;
            lnkDestinationFolder.LinkClicked += lnkDestinationFolder_LinkClicked;
            // 
            // lblGeneratedFolder
            // 
            lblGeneratedFolder.AutoSize = true;
            lblGeneratedFolder.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblGeneratedFolder.Location = new Point(45, 391);
            lblGeneratedFolder.Name = "lblGeneratedFolder";
            lblGeneratedFolder.Size = new Size(219, 35);
            lblGeneratedFolder.TabIndex = 10;
            lblGeneratedFolder.Text = "Generated Folder";
            lblGeneratedFolder.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 496);
            Controls.Add(lblGeneratedFolder);
            Controls.Add(lnkDestinationFolder);
            Controls.Add(btnGenerateCode);
            Controls.Add(label3);
            Controls.Add(txtDestinationPath);
            Controls.Add(btnSelectDestination);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtModels);
            Controls.Add(txtSourcePath);
            Controls.Add(btnSelectSource);
            Name = "Form1";
            Text = "Code Generator";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog sourceFileDialog;
        private FolderBrowserDialog destinationFolderPathDialog;
        private Button btnSelectSource;
        private TextBox txtSourcePath;
        private RichTextBox txtModels;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtDestinationPath;
        private Button btnSelectDestination;
        private Button btnGenerateCode;
        private LinkLabel lnkDestinationFolder;
        private Label lblGeneratedFolder;
    }
}
