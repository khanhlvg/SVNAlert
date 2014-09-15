using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVNAlert.Manager.Entity;
using System.IO;
using System.Windows.Forms;

namespace SVNAlert.Manager
{
    public class UpdateInfoManager
    {
        private static UpdateInfoManager instance;

        private string updateInfoXMLPath = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "updateInfo.xml";

        public List<UpdateInfoEntity> updateInfoList;

        private UpdateInfoManager() { }

        public static UpdateInfoManager Instance
        {
            get 
                {
                if (instance == null)
                {
                    instance = new UpdateInfoManager();
                    instance.LoadFromXML();
                }
                    return instance;
                }
            }

        public UpdateInfoEntity GetUpdateInfoEntityFromTarget(TrackingTargetEntity entity)
        {
            foreach (UpdateInfoEntity updateEntity in updateInfoList)
            {
                if (updateEntity.trackingTarget.Equals(entity))
                    return updateEntity;
            }
            return null;
        }

        public bool IsContainingNewUpdate()
        {
            foreach (UpdateInfoEntity entity in updateInfoList)
            {
                if (!entity.isShownInSiren)
                    return true;
            }
            return false;
        }

        private void LoadFromXML()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(Application.ExecutablePath);
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<UpdateInfoEntity>));
                file = new System.IO.StreamReader(updateInfoXMLPath);
                this.updateInfoList = (List<UpdateInfoEntity>)reader.Deserialize(file);
            }
            catch (Exception)
            {
                updateInfoList = new List<UpdateInfoEntity>();
            }
            finally
            {
                file.Close();
            }
        }

        public void SaveToXML()
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<UpdateInfoEntity>));

            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(updateInfoXMLPath);
                writer.Serialize(file, this.updateInfoList);
                file.Close();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
            }
        }
    }

    
}
