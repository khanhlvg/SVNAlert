using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SVNAlert.Manager.Entity
{
    [XmlRoot(ElementName = "TrackingTargetEntity")]
    public class TrackingTargetEntity
    {
        public String nickName;
        public String path;
        public bool isEnabled;

        public TrackingTargetEntity(String path, String nickName, bool isEnabled)
        {
            this.path = path;
            this.nickName = nickName;
            this.isEnabled = isEnabled;

            if ((nickName == null) || ("".Equals(nickName)))
                this.nickName = GetFileName(path);

        }

        public TrackingTargetEntity(String path, String nickName)
            : this(path, nickName, true)
        {
        }

        public TrackingTargetEntity(String path)
            : this(path, "", true)
        {
            this.nickName = GetFileName(path);
        }

        public TrackingTargetEntity() { }

        private string GetFileName(string hrefLink)
        {
            if (!hrefLink.EndsWith("/"))
                hrefLink = hrefLink + "/";

            string[] parts = hrefLink.Split('/');
            string fileName = "";

            if (parts.Length > 0)
                fileName = parts[parts.Length - 2];
            else
                fileName = hrefLink;

            return fileName;
        }

        public TrackingTargetEntity Clone()
        {
            TrackingTargetEntity copy = new TrackingTargetEntity(this.path, this.nickName, this.isEnabled);
            return copy;
        }

        public override int GetHashCode()
        {
            int ret = 0;
            ret = (ret * 397) ^ nickName.GetHashCode();
            ret = (ret * 397) ^ path.GetHashCode();
            ret = (ret * 397) ^ isEnabled.GetHashCode();

            return ret;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;

            TrackingTargetEntity cobj = (TrackingTargetEntity) obj;

            return this.path.Equals(cobj.path) && (this.isEnabled == cobj.isEnabled) && this.nickName.Equals(cobj.nickName);
        }

    }
}
