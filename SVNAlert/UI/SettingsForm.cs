using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SVNAlert.Manager;
using SVNAlert.Manager.Entity;

namespace SVNAlert.UI
{
    public partial class SettingsForm : Form
    {
        private enum ConnectionTestResult
        {
            Sucessful,
            Failure,
            Busy
        }

        private SettingManager settingManager = SettingManager.Instance;
        private SVNManager svnManager = SVNManager.Instance;
        private LoadingForm loadForm;
        private ConnectionTestResult testResult;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // setup Authentication Tab
            usernameText.Text = settingManager.svnUserName;
            passwordText.Text = settingManager.svnPassword;

            // setup Tracking Target Tab
            foreach (TrackingTargetEntity entity in settingManager.listOfTrackingTarget)
            {
                trackingDataGrid.Rows.Add(entity.isEnabled, entity.nickName, entity.path);
            }

            // set blank row checkbox to TRUE
            trackingDataGrid.Rows[trackingDataGrid.RowCount - 1].Cells[0].Value = true;
        }

        private void saveSettingsToManager()
        {
            // save Authentication Tab
            settingManager.svnUserName = usernameText.Text;
            settingManager.svnPassword = passwordText.Text;
            SVNManager.Instance.ResetSVNClient();

            // save Tracking Target Tab
            settingManager.listOfTrackingTarget = GetTrackingTargetListFromForm();
        }

        private List<TrackingTargetEntity> GetTrackingTargetListFromForm()
        {
            List<TrackingTargetEntity> ret = new List<TrackingTargetEntity>();

            foreach (DataGridViewRow row in trackingDataGrid.Rows)
            {
                if (row.Cells[2].Value == null)
                    continue;

                if (row.Cells[2].Value.Equals(""))
                    continue;

                if (row.Cells[0].Value == null)
                    row.Cells[0].Value = false;

                TrackingTargetEntity entity = new TrackingTargetEntity((string)row.Cells[2].Value, (string)row.Cells[1].Value, (bool)row.Cells[0].Value);
                ret.Add(entity);
            }

            return ret;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            saveSettingsToManager();
            settingManager.SaveToXML();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void svnTestWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            if (svnManager.IsWorking)
            {
                this.testResult = ConnectionTestResult.Busy;
                return;
            }

            // temporary using current Authentication to test
            SVNManager.Instance.ResetSVNClientUsingAuth(usernameText.Text, passwordText.Text);

            List<TrackingTargetEntity> testTargetList = GetTrackingTargetListFromForm();
            Dictionary<TrackingTargetEntity,DateTime> updateTimeDict = svnManager.GetLastModifiedDateTimeOfList(testTargetList);

            if (updateTimeDict.Count == testTargetList.Count)
                this.testResult = ConnectionTestResult.Sucessful;
            else
                this.testResult = ConnectionTestResult.Failure;

            // reset client to default setting
            SVNManager.Instance.ResetSVNClient();
        }

        private void testConnBtn_Click(object sender, EventArgs e)
        {
            loadForm = new LoadingForm("通信テスト中・・・");
            this.svnTestWorker.RunWorkerAsync();
            loadForm.ShowDialog(this);
        }

        private void svnTestWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadForm.Close();
            loadForm.Dispose();

            switch (this.testResult)
            {
                case ConnectionTestResult.Sucessful:
                    MessageBox.Show("SVN接続は成功しました。", "さいれんくん");
                    break;
                case ConnectionTestResult.Failure:
                    MessageBox.Show("SVN接続は失敗しました。", "さいれんくん");
                    break;
                case ConnectionTestResult.Busy:
                    MessageBox.Show("SVNクライアントは現在使用中。もうしばらく経ってから再度試してください。", "さいれんくん");
                    break;
            }
        }

        private void trackingDataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.trackingDataGrid.Rows[e.RowIndex].Cells[0].Value = true;
        }

    }
}
