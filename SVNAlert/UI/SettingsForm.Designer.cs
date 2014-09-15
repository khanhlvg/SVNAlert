namespace SVNAlert.UI
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.trackingTab = new System.Windows.Forms.TabPage();
            this.trackingDataGrid = new System.Windows.Forms.DataGridView();
            this.isTargetCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nicknameTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authenticationTab = new System.Windows.Forms.TabPage();
            this.passwordText = new System.Windows.Forms.MaskedTextBox();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.testConnBtn = new System.Windows.Forms.Button();
            this.svnTestWorker = new System.ComponentModel.BackgroundWorker();
            this.tabControl.SuspendLayout();
            this.trackingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackingDataGrid)).BeginInit();
            this.authenticationTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.trackingTab);
            this.tabControl.Controls.Add(this.authenticationTab);
            this.tabControl.Location = new System.Drawing.Point(12, 41);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(900, 402);
            this.tabControl.TabIndex = 1;
            // 
            // trackingTab
            // 
            this.trackingTab.Controls.Add(this.trackingDataGrid);
            this.trackingTab.Location = new System.Drawing.Point(4, 22);
            this.trackingTab.Name = "trackingTab";
            this.trackingTab.Size = new System.Drawing.Size(892, 376);
            this.trackingTab.TabIndex = 2;
            this.trackingTab.Text = "トラッキング対象";
            this.trackingTab.UseVisualStyleBackColor = true;
            // 
            // trackingDataGrid
            // 
            this.trackingDataGrid.AllowUserToResizeRows = false;
            this.trackingDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trackingDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isTargetCheckBox,
            this.nicknameTextBox,
            this.pathTextBox});
            this.trackingDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackingDataGrid.Location = new System.Drawing.Point(0, 0);
            this.trackingDataGrid.Name = "trackingDataGrid";
            this.trackingDataGrid.Size = new System.Drawing.Size(892, 376);
            this.trackingDataGrid.TabIndex = 0;
            this.trackingDataGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.trackingDataGrid_RowsAdded);
            // 
            // isTargetCheckBox
            // 
            this.isTargetCheckBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.isTargetCheckBox.HeaderText = "対象";
            this.isTargetCheckBox.Name = "isTargetCheckBox";
            this.isTargetCheckBox.Width = 50;
            // 
            // nicknameTextBox
            // 
            this.nicknameTextBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nicknameTextBox.HeaderText = "あだ名";
            this.nicknameTextBox.MinimumWidth = 60;
            this.nicknameTextBox.Name = "nicknameTextBox";
            this.nicknameTextBox.Width = 63;
            // 
            // pathTextBox
            // 
            this.pathTextBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pathTextBox.HeaderText = "パス";
            this.pathTextBox.Name = "pathTextBox";
            // 
            // authenticationTab
            // 
            this.authenticationTab.Controls.Add(this.passwordText);
            this.authenticationTab.Controls.Add(this.usernameText);
            this.authenticationTab.Controls.Add(this.label5);
            this.authenticationTab.Controls.Add(this.label4);
            this.authenticationTab.Location = new System.Drawing.Point(4, 22);
            this.authenticationTab.Name = "authenticationTab";
            this.authenticationTab.Padding = new System.Windows.Forms.Padding(3);
            this.authenticationTab.Size = new System.Drawing.Size(892, 376);
            this.authenticationTab.TabIndex = 1;
            this.authenticationTab.Text = "認証情報";
            this.authenticationTab.UseVisualStyleBackColor = true;
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(105, 49);
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '彡';
            this.passwordText.Size = new System.Drawing.Size(239, 20);
            this.passwordText.TabIndex = 3;
            // 
            // usernameText
            // 
            this.usernameText.Location = new System.Drawing.Point(105, 14);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(239, 20);
            this.usernameText.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "パスワード";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "ユーザー名";
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(752, 12);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "保存";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(833, 12);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "キャンセル";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // testConnBtn
            // 
            this.testConnBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.testConnBtn.Location = new System.Drawing.Point(671, 12);
            this.testConnBtn.Name = "testConnBtn";
            this.testConnBtn.Size = new System.Drawing.Size(75, 23);
            this.testConnBtn.TabIndex = 4;
            this.testConnBtn.Text = "通信テスト";
            this.testConnBtn.UseVisualStyleBackColor = true;
            this.testConnBtn.Click += new System.EventHandler(this.testConnBtn_Click);
            // 
            // svnTestWorker
            // 
            this.svnTestWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.svnTestWorker_DoWork);
            this.svnTestWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.svnTestWorker_RunWorkerCompleted);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 455);
            this.Controls.Add(this.testConnBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "設定";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabControl.ResumeLayout(false);
            this.trackingTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackingDataGrid)).EndInit();
            this.authenticationTab.ResumeLayout(false);
            this.authenticationTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage authenticationTab;
        private System.Windows.Forms.MaskedTextBox passwordText;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage trackingTab;
        private System.Windows.Forms.DataGridView trackingDataGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isTargetCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn nicknameTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathTextBox;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button testConnBtn;
        private System.ComponentModel.BackgroundWorker svnTestWorker;
    }
}