
namespace SpongewareInjector
{
    partial class MainForm
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
            this.TitleText = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.SubtitleLabel = new System.Windows.Forms.Label();
            this.LoadButton = new System.Windows.Forms.Button();
            this.UnloadButton = new System.Windows.Forms.Button();
            this.DevCheckBox = new System.Windows.Forms.CheckBox();
            this.SelectButton = new System.Windows.Forms.Button();
            this.GitLinkLabel = new System.Windows.Forms.LinkLabel();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleText
            // 
            this.TitleText.AutoSize = true;
            this.TitleText.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleText.Location = new System.Drawing.Point(0, 0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(188, 40);
            this.TitleText.TabIndex = 0;
            this.TitleText.Text = "Spongeware";
            // 
            // Status
            // 
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusText});
            this.Status.Location = new System.Drawing.Point(0, 139);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(234, 22);
            this.Status.SizingGrip = false;
            this.Status.TabIndex = 1;
            this.Status.Text = "statusStrip1";
            // 
            // StatusText
            // 
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(107, 17);
            this.StatusText.Text = "Status: Not loaded.";
            // 
            // SubtitleLabel
            // 
            this.SubtitleLabel.AutoSize = true;
            this.SubtitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SubtitleLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SubtitleLabel.Location = new System.Drawing.Point(4, 40);
            this.SubtitleLabel.Name = "SubtitleLabel";
            this.SubtitleLabel.Size = new System.Drawing.Size(141, 15);
            this.SubtitleLabel.TabIndex = 2;
            this.SubtitleLabel.Text = "premium meme software";
            // 
            // LoadButton
            // 
            this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LoadButton.Location = new System.Drawing.Point(12, 67);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(100, 23);
            this.LoadButton.TabIndex = 4;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // UnloadButton
            // 
            this.UnloadButton.Enabled = false;
            this.UnloadButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UnloadButton.Location = new System.Drawing.Point(122, 67);
            this.UnloadButton.Name = "UnloadButton";
            this.UnloadButton.Size = new System.Drawing.Size(100, 23);
            this.UnloadButton.TabIndex = 5;
            this.UnloadButton.Text = "Unload";
            this.UnloadButton.UseVisualStyleBackColor = true;
            this.UnloadButton.Click += new System.EventHandler(this.UnloadButton_Click);
            // 
            // DevCheckBox
            // 
            this.DevCheckBox.AutoSize = true;
            this.DevCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DevCheckBox.Location = new System.Drawing.Point(12, 104);
            this.DevCheckBox.Name = "DevCheckBox";
            this.DevCheckBox.Size = new System.Drawing.Size(113, 20);
            this.DevCheckBox.TabIndex = 6;
            this.DevCheckBox.Text = "I\'m a developer";
            this.DevCheckBox.UseVisualStyleBackColor = true;
            this.DevCheckBox.CheckedChanged += new System.EventHandler(this.DevCheckBox_CheckedChanged);
            // 
            // SelectButton
            // 
            this.SelectButton.Enabled = false;
            this.SelectButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SelectButton.Location = new System.Drawing.Point(122, 102);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(100, 23);
            this.SelectButton.TabIndex = 7;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // GitLinkLabel
            // 
            this.GitLinkLabel.AutoSize = true;
            this.GitLinkLabel.Location = new System.Drawing.Point(189, 142);
            this.GitLinkLabel.Name = "GitLinkLabel";
            this.GitLinkLabel.Size = new System.Drawing.Size(45, 15);
            this.GitLinkLabel.TabIndex = 8;
            this.GitLinkLabel.TabStop = true;
            this.GitLinkLabel.Text = "GitHub";
            this.GitLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitLinkLabel_LinkClicked);
            // 
            // FileDialog
            // 
            this.FileDialog.DefaultExt = "dll";
            this.FileDialog.Filter = "DLL files|*.dll";
            this.FileDialog.Title = "Select a Developer DLL";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 161);
            this.Controls.Add(this.GitLinkLabel);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.DevCheckBox);
            this.Controls.Add(this.UnloadButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SubtitleLabel);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.TitleText);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Spongeware Loader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.Label SubtitleLabel;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button UnloadButton;
        private System.Windows.Forms.CheckBox DevCheckBox;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.LinkLabel GitLinkLabel;
        private System.Windows.Forms.OpenFileDialog FileDialog;
    }
}

