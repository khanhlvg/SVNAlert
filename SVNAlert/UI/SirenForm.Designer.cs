namespace SVNAlert.UI
{
    partial class SirenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SirenForm));
            this.sirenPicture = new System.Windows.Forms.PictureBox();
            this.updateInfoListBox = new System.Windows.Forms.ListBox();
            this.typeGroupBox = new System.Windows.Forms.GroupBox();
            this.viewDatePicker = new System.Windows.Forms.DateTimePicker();
            this.typeSelect = new System.Windows.Forms.RadioButton();
            this.typeToday = new System.Windows.Forms.RadioButton();
            this.typeLastest = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.sirenPicture)).BeginInit();
            this.typeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sirenPicture
            // 
            this.sirenPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sirenPicture.Image = global::SVNAlert.Properties.Resources.SirenGif;
            this.sirenPicture.InitialImage = null;
            this.sirenPicture.Location = new System.Drawing.Point(213, 12);
            this.sirenPicture.Name = "sirenPicture";
            this.sirenPicture.Size = new System.Drawing.Size(500, 270);
            this.sirenPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.sirenPicture.TabIndex = 0;
            this.sirenPicture.TabStop = false;
            // 
            // updateInfoListBox
            // 
            this.updateInfoListBox.FormattingEnabled = true;
            this.updateInfoListBox.Location = new System.Drawing.Point(13, 363);
            this.updateInfoListBox.Name = "updateInfoListBox";
            this.updateInfoListBox.Size = new System.Drawing.Size(902, 173);
            this.updateInfoListBox.TabIndex = 1;
            // 
            // typeGroupBox
            // 
            this.typeGroupBox.Controls.Add(this.viewDatePicker);
            this.typeGroupBox.Controls.Add(this.typeSelect);
            this.typeGroupBox.Controls.Add(this.typeToday);
            this.typeGroupBox.Controls.Add(this.typeLastest);
            this.typeGroupBox.Location = new System.Drawing.Point(450, 309);
            this.typeGroupBox.Name = "typeGroupBox";
            this.typeGroupBox.Size = new System.Drawing.Size(465, 48);
            this.typeGroupBox.TabIndex = 2;
            this.typeGroupBox.TabStop = false;
            this.typeGroupBox.Text = "表示対象";
            // 
            // viewDatePicker
            // 
            this.viewDatePicker.Location = new System.Drawing.Point(259, 16);
            this.viewDatePicker.MaxDate = new System.DateTime(2014, 9, 13, 0, 0, 0, 0);
            this.viewDatePicker.Name = "viewDatePicker";
            this.viewDatePicker.Size = new System.Drawing.Size(200, 20);
            this.viewDatePicker.TabIndex = 3;
            this.viewDatePicker.Value = new System.DateTime(2014, 9, 13, 0, 0, 0, 0);
            // 
            // typeSelect
            // 
            this.typeSelect.AutoSize = true;
            this.typeSelect.Location = new System.Drawing.Point(159, 19);
            this.typeSelect.Name = "typeSelect";
            this.typeSelect.Size = new System.Drawing.Size(97, 17);
            this.typeSelect.TabIndex = 2;
            this.typeSelect.Text = "指定日付以降";
            this.typeSelect.UseVisualStyleBackColor = true;
            this.typeSelect.CheckedChanged += new System.EventHandler(this.typeRadtioButton_CheckedChanged);
            // 
            // typeToday
            // 
            this.typeToday.AutoSize = true;
            this.typeToday.Location = new System.Drawing.Point(83, 19);
            this.typeToday.Name = "typeToday";
            this.typeToday.Size = new System.Drawing.Size(70, 17);
            this.typeToday.TabIndex = 1;
            this.typeToday.Text = "本日のみ";
            this.typeToday.UseVisualStyleBackColor = true;
            this.typeToday.CheckedChanged += new System.EventHandler(this.typeRadtioButton_CheckedChanged);
            // 
            // typeLastest
            // 
            this.typeLastest.AutoSize = true;
            this.typeLastest.Checked = true;
            this.typeLastest.Location = new System.Drawing.Point(7, 19);
            this.typeLastest.Name = "typeLastest";
            this.typeLastest.Size = new System.Drawing.Size(70, 17);
            this.typeLastest.TabIndex = 0;
            this.typeLastest.TabStop = true;
            this.typeLastest.Text = "最新のみ";
            this.typeLastest.UseVisualStyleBackColor = true;
            this.typeLastest.CheckedChanged += new System.EventHandler(this.typeRadtioButton_CheckedChanged);
            // 
            // SirenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 551);
            this.Controls.Add(this.typeGroupBox);
            this.Controls.Add(this.updateInfoListBox);
            this.Controls.Add(this.sirenPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SirenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SVNの更新発生！！！！！";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SirenForm_FormClosed);
            this.Load += new System.EventHandler(this.Siren_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sirenPicture)).EndInit();
            this.typeGroupBox.ResumeLayout(false);
            this.typeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sirenPicture;
        private System.Windows.Forms.ListBox updateInfoListBox;
        private System.Windows.Forms.GroupBox typeGroupBox;
        private System.Windows.Forms.RadioButton typeLastest;
        private System.Windows.Forms.RadioButton typeSelect;
        private System.Windows.Forms.RadioButton typeToday;
        private System.Windows.Forms.DateTimePicker viewDatePicker;
    }
}

