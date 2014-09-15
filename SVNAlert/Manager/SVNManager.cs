using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSvn;
using SharpSvn.Security;
using SVNAlert.Manager.Entity;

namespace SVNAlert.Manager
{
    public sealed class SVNManager
    {

        private static volatile SVNManager instance;
        private static object syncRoot = new Object();

        public bool IsWorking { get { return isWorking; } }
        private bool isPrivateWork;

        private SvnClient svnClient;
        private SettingManager settingManager = SettingManager.Instance;
        private bool isWorking;
        private List<TrackingTargetEntity> privateTrackingTargets;

        public static SVNManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SVNManager();
                    }
                }

                return instance;
            }
        }

        private SVNManager() 
        {
            this.isWorking = false;
            this.isPrivateWork = false;

            ResetSVNClient();

        }

        public void ResetSVNClient()
        {
            ResetSVNClientUsingAuth(settingManager.svnUserName,settingManager.svnPassword);
        }

        public void ResetSVNClientUsingAuth(String username, String password)
        {
            //create svnClient
            svnClient = new SvnClient();
            svnClient.Authentication.Clear();
            svnClient.Authentication.DefaultCredentials = new System.Net.NetworkCredential(username, password);

            svnClient.Authentication.SslServerTrustHandlers += delegate(object sender, SvnSslServerTrustEventArgs e)
            {
                e.AcceptedFailures = e.Failures;
                e.Save = true; // Save acceptance to authentication store
            };
        }

        public Dictionary<TrackingTargetEntity, DateTime> GetLastModifiedDateTime()
        {
            return GetLastModifiedDateTimeOfList(settingManager.listOfTrackingTarget);
        }

        public Dictionary<TrackingTargetEntity, DateTime> GetLastModifiedDateTimeOfList(List<TrackingTargetEntity> trackingTargets)
        {
            if (this.isWorking)
                return null;

            this.isWorking = true;
            this.isPrivateWork = true;

            Dictionary<TrackingTargetEntity, DateTime> ret = new Dictionary<TrackingTargetEntity, DateTime>();

            CaptureTrackingTargetSnapshot(trackingTargets);

            foreach (TrackingTargetEntity entity in this.privateTrackingTargets)
            {
                DateTime updateTime = GetLastModifiedDateTimeOfEntity(entity);
                if (updateTime!=DateTime.MinValue)
                    ret.Add(entity, updateTime);
            }

            this.isPrivateWork = false;
            this.isWorking = false;

            return ret;
        }

        public DateTime GetLastModifiedDateTimeOfEntity(TrackingTargetEntity entity)
        {
            if ((this.isWorking) && (!this.isPrivateWork))
                return DateTime.MinValue;

            if (!this.isPrivateWork)
                this.isWorking = true;
            
            DateTime ret;

            SvnInfoEventArgs infoEventArgs;
            SvnUriTarget target;

            try
            {
                target = new SvnUriTarget(entity.path);
                svnClient.GetInfo(target, out infoEventArgs);
                ret = infoEventArgs.LastChangeTime;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
                ret = DateTime.MinValue;
            }

            if (!this.isPrivateWork)
                this.isWorking = false;
            return ret;

        }

        private void CaptureTrackingTargetSnapshot(List<TrackingTargetEntity> trackingTargets)
        {
            this.privateTrackingTargets = new List<TrackingTargetEntity>();
            foreach (TrackingTargetEntity entity in trackingTargets)
            {
                this.privateTrackingTargets.Add(entity.Clone());
            }
        }

    }
}
