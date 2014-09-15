using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using SVNAlert.Manager;
using SVNAlert.Manager.Entity;

namespace SVNAlert.UI
{
    class SystemTrayIcon : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private MenuItem checkStatusButton;
        private Timer svnTimer;
        private System.ComponentModel.IContainer components;
        private System.ComponentModel.BackgroundWorker svnWorker;
        private SVNManager svnManager = SVNManager.Instance;
        private SettingManager settingManager = SettingManager.Instance;
        private UpdateInfoManager updateInfoManager = UpdateInfoManager.Instance;
        private List<TrackingTargetEntity> errorEntityList = new List<TrackingTargetEntity>();

        private SettingsForm settingForm;

        public SystemTrayIcon()
        {
            InitializeComponent();

            // Create tray menu
            trayMenu = new ContextMenu();
            trayMenu_SetToNormal();
 
            // Create tray icon
            trayIcon      = new NotifyIcon();
            trayIcon.Text = "さいれんくん";
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SirenForm));
            trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
 
            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible     = true;
        }
 
        protected override void OnLoad(EventArgs e)
        {
            Visible       = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.
 
            base.OnLoad(e);
        }
 
        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowSettingForm(object sender, EventArgs e)
        {
            if (this.settingForm == null)
            {
                this.settingForm = new SettingsForm();
            }

            try
            {
                this.settingForm.Show();
                this.settingForm.Focus();
            }
            catch (ObjectDisposedException)
            {
                this.settingForm = new SettingsForm();
                this.settingForm.Show();
            }

        }

        private void UpdateSVNStatus(object sender, EventArgs e)
        {
            if (svnManager.IsWorking)
            {
                MessageBox.Show("SVNクライアントは使用中の為、もうしばらくお待ちくださいぃぃ～～～","さいれんくん");
                return;
            }

            String alertMessage;
            if (!CheckSettingsReadyAndAlert(out alertMessage))
                MessageBox.Show(alertMessage, "さいれんくん");

            DoUpdateSVNStatus();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                trayIcon.Dispose();
            }
 
            base.Dispose(isDisposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.svnTimer = new System.Windows.Forms.Timer(this.components);
            this.svnWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // svnTimer
            // 
            this.svnTimer.Enabled = true;
            this.svnTimer.Interval = 300000;
            this.svnTimer.Tick += new System.EventHandler(this.svnTimer_Tick);
            // 
            // svnWorker
            // 
            this.svnWorker.WorkerReportsProgress = true;
            this.svnWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.svnWorker_DoWork);
            this.svnWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.svnWorker_ProgressChanged);
            this.svnWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.svnWorker_RunWorkerCompleted);
            // 
            // SystemTrayIcon
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "SystemTrayIcon";
            this.ResumeLayout(false);

        }

        private bool CheckSettingsReadyAndAlert(out String errorMessage)
        {
            if (settingManager.svnUserName.Equals("") || settingManager.svnPassword.Equals(""))
            {
                errorMessage = "SVNの認証情報は設定されていません。設定画面から設定を行ってください。";
                return false;
            }

            if (settingManager.listOfTrackingTarget.Count == 0)
            {
                errorMessage = "トラッキング対象のSVNパスは設定されていません。設定画面から設定を行ってください。";
                return false;
            }

            errorMessage = "";
            return true;
        }

        private void DoUpdateSVNStatus()
        {
            if (svnManager.IsWorking)
                return;

            trayMenu_SetToWorking();
            this.svnWorker.RunWorkerAsync();

        }
        
        private void svnWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            List<TrackingTargetEntity> targetList = settingManager.listOfTrackingTarget;
            //Dictionary<TrackingTargetEntity, DateTime> updateTimeDict = svnManager.GetLastModifiedDateTimeOfList(targetList);

            int count = 0;
            svnWorker.ReportProgress(count);

            this.errorEntityList.Clear();

            foreach (TrackingTargetEntity targetEntity in targetList)
            {
                // skip disable item
                if (!targetEntity.isEnabled)
                    continue;

                // skip this item if connection error occurs
                DateTime lastUpdate = svnManager.GetLastModifiedDateTimeOfEntity(targetEntity);
                if (lastUpdate.Equals(DateTime.MinValue))
                {
                    this.errorEntityList.Add(targetEntity);
                    continue;
                }

                UpdateInfoEntity updateInfoEntity = updateInfoManager.GetUpdateInfoEntityFromTarget(targetEntity);
                if (updateInfoEntity == null)
                {
                    updateInfoEntity = new UpdateInfoEntity(targetEntity, lastUpdate);
                    updateInfoManager.updateInfoList.Add(updateInfoEntity);
                }
                else
                {
                    if (!updateInfoEntity.lastUpdate.Equals(lastUpdate))
                    {
                        updateInfoEntity.isShownInSiren = false;
                        updateInfoEntity.lastUpdate = lastUpdate;
                    }
                    
                }

                count++;
                svnWorker.ReportProgress(count);
            }
            updateInfoManager.SaveToXML();
        }

        private void svnWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            trayMenu_SetToNormal();

            if (this.errorEntityList.Count > 0)
            {
                StringBuilder errorMessage = new StringBuilder("下記のファイルには接続エラーが発生しました！！\n");
                foreach (TrackingTargetEntity target in this.errorEntityList)
                {
                    errorMessage.Append("■").Append(target.nickName).Append("：").Append(target.path).Append("\n");
                }
                MessageBox.Show(errorMessage.ToString(), "さいれんくん");
            }

            if (updateInfoManager.IsContainingNewUpdate())
            {
                SirenForm siren = new SirenForm();
                siren.Show();
            }
        }

        private void svnWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            checkStatusButton.Text = "問い合わせ中・・・（"+ e.ProgressPercentage.ToString() + "/" + 
                settingManager.listOfTrackingTarget.Count.ToString() + "件）" ;
        }

        private void trayMenu_SetToNormal()
        {
            trayMenu.MenuItems.Clear();
            checkStatusButton = new MenuItem("SVNへ問い合わせ", UpdateSVNStatus);
            trayMenu.MenuItems.Add(checkStatusButton);
            trayMenu.MenuItems.Add("設定", ShowSettingForm);
            trayMenu.MenuItems.Add("終了", OnExit);
        }

        private void trayMenu_SetToWorking()
        {
            trayMenu.MenuItems.Clear();
            checkStatusButton.Enabled = false;
            checkStatusButton.Text = "問い合わせ中・・・";
            trayMenu.MenuItems.Add(checkStatusButton);
        }

        private void svnTimer_Tick(object sender, EventArgs e)
        {
            DoUpdateSVNStatus();
        }

        
        
    }
}
