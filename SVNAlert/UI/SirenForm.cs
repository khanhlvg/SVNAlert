using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Media;
using SVNAlert.Manager;
using SVNAlert.Manager.Entity;
using WMPLib;
using System.IO;

namespace SVNAlert.UI
{
    public partial class SirenForm : Form
    {

        private SettingManager settingManager = SettingManager.Instance;
        private UpdateInfoManager updateInfoManager = UpdateInfoManager.Instance;

        private WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        public SirenForm()
        {
            InitializeComponent();  
        }

        private void typeRadtioButton_CheckedChanged(object sender, EventArgs e)
        {
            SettingManager.AlertType alertType = new SettingManager.AlertType();
           
            if (typeLastest.Checked)
                alertType = SettingManager.AlertType.LatestOnly;
            if (typeToday.Checked)
                alertType = SettingManager.AlertType.TodayOnly;
            if (typeSelect.Checked)
                alertType = SettingManager.AlertType.SelectDate;

            settingManager.alertType = alertType;
            settingManager.alertAfterDate = viewDatePicker.Value;

            settingManager.SaveToXML();

            UpdateDisplayList();
        }

        private void Siren_Load(object sender, EventArgs e)
        {
            this.viewDatePicker.MaxDate = DateTime.Today;
            
            //play Siren sound
            wplayer.URL = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "Resources" + Path.DirectorySeparatorChar + "Siren.mp3";
            wplayer.controls.play();

            UpdateDisplayList();
        }

        private void UpdateDisplayList()
        {
            this.updateInfoListBox.Items.Clear();

            switch (settingManager.alertType)
            {
                case SettingManager.AlertType.LatestOnly:
                    foreach (UpdateInfoEntity entity in updateInfoManager.updateInfoList)
                    {
                        if (!entity.isShownInSiren)
                        {
                            this.updateInfoListBox.Items.Add(entity.ToString());
                            //entity.isShownInSiren = true;
                        }
                    }
                    break;
                case SettingManager.AlertType.TodayOnly:
                    foreach (UpdateInfoEntity entity in updateInfoManager.updateInfoList)
                    {
                        if ((!entity.isShownInSiren) || (entity.lastUpdate.Date.Equals(DateTime.Today)))
                        {
                            this.updateInfoListBox.Items.Add(entity.ToString());
                            //entity.isShownInSiren = true;
                        }
                    }
                    break;
                case SettingManager.AlertType.SelectDate:
                    foreach (UpdateInfoEntity entity in updateInfoManager.updateInfoList)
                    {
                        if ((!entity.isShownInSiren) || (entity.lastUpdate >= viewDatePicker.Value))
                        {
                            this.updateInfoListBox.Items.Add(entity.ToString());
                            //entity.isShownInSiren = true;
                        }
                    }
                    break;
                default : 
                    break;
            }
        }

        private void SirenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (UpdateInfoEntity entity in updateInfoManager.updateInfoList)
            {
                entity.isShownInSiren = true;
            }

            this.wplayer.controls.stop();

            updateInfoManager.SaveToXML();
        }
    }
}
