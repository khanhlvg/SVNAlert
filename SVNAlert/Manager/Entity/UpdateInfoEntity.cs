using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SVNAlert.Manager.Entity
{

    [XmlRoot(ElementName = "UpdateInfoEntity")]
    public class UpdateInfoEntity
    {
        public UpdateInfoEntity() { }

        public UpdateInfoEntity(TrackingTargetEntity entity, DateTime lastUpdate)
        {
            this.trackingTarget = entity.Clone();
            this.lastUpdate = lastUpdate;
            this.isShownInSiren = false;
        }

        public TrackingTargetEntity trackingTarget;
        public DateTime lastUpdate;
        public bool isShownInSiren;

        public override string ToString()
        {
            return "【" + trackingTarget.nickName + "】最近更新時刻　＝　" + lastUpdate.ToString();
        }
    }
}
