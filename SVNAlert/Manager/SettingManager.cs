using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVNAlert.Manager.Entity;

namespace SVNAlert.Manager
{
    public class SettingManager
    {
        public enum AlertType
        {
            LatestOnly,
            TodayOnly,
            SelectDate
        }

        //constants
        string settingXMLPath = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "settings.xml";

        private static SettingManager instance;

        //setting parameters
        public AlertType alertType;
        public DateTime alertAfterDate;
        public String svnUserName;
        public String svnPassword;
        public List<TrackingTargetEntity> listOfTrackingTarget;

        private SettingManager() {
            this.alertType = AlertType.LatestOnly;
            this.alertAfterDate = DateTime.MinValue;
            this.svnUserName = "";
            this.svnPassword = "";
            this.listOfTrackingTarget = new List<TrackingTargetEntity>();
        }

        public static SettingManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SettingManager();
                    instance.loadFromXML();
                }
                return instance;
            }
        }

        public void SaveToXML()
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(SettingManager));

            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(settingXMLPath);
                writer.Serialize(file, this);
                file.Close();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
            }
        }

        public void loadFromXML()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Application.ExecutablePath);
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(SettingManager));
                file = new System.IO.StreamReader(settingXMLPath);
                instance = (SettingManager)reader.Deserialize(file);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
            }
            finally
            {
                file.Close();
            }
        }
    }
}
