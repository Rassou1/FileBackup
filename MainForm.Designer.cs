namespace A5_FileBackupCS
{
    partial class MainForm
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
            lstSource = new ListBox();
            lstTarget = new ListBox();
            btnStart = new Button();
            btnAsync = new Button();
            dialog = new FolderBrowserDialog();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // lstSource
            // 
            lstSource.Font = new Font("Courier New", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lstSource.FormattingEnabled = true;
            lstSource.ItemHeight = 22;
            lstSource.Location = new Point(30, 62);
            lstSource.Margin = new Padding(2);
            lstSource.Name = "lstSource";
            lstSource.Size = new Size(873, 488);
            lstSource.TabIndex = 0;
            // 
            // lstTarget
            // 
            lstTarget.Font = new Font("Courier New", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lstTarget.FormattingEnabled = true;
            lstTarget.ItemHeight = 22;
            lstTarget.Location = new Point(924, 62);
            lstTarget.Margin = new Padding(2);
            lstTarget.Name = "lstTarget";
            lstTarget.Size = new Size(653, 488);
            lstTarget.TabIndex = 1;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.Location = new Point(78, 586);
            btnStart.Margin = new Padding(2);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(364, 60);
            btnStart.TabIndex = 2;
            btnStart.Text = "Run ThreadPool";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnAsync
            // 
            btnAsync.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnAsync.Location = new Point(498, 586);
            btnAsync.Margin = new Padding(2);
            btnAsync.Name = "btnAsync";
            btnAsync.Size = new Size(364, 60);
            btnAsync.TabIndex = 3;
            btnAsync.Text = "Run Async";
            btnAsync.UseVisualStyleBackColor = true;
            btnAsync.Click += btnAsync_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(30, 22);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(166, 30);
            label1.TabIndex = 4;
            label1.Text = "Files to back-up";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(929, 22);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(165, 30);
            label2.TabIndex = 4;
            label2.Text = "Files backed-up";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1607, 671);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAsync);
            Controls.Add(btnStart);
            Controls.Add(lstTarget);
            Controls.Add(lstSource);
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "File Processor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstSource;
        private ListBox lstTarget;
        private Button btnStart;
        private Button btnAsync;
        private FolderBrowserDialog dialog;
        private Label label1;
        private Label label2;
    }
}
