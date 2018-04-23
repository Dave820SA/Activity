using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIAWeb.Models;
using PersonnelBusinessLayer;

namespace SIAWeb.Common
{
    public class WebsiteAccess
    {
        PersonnelContext db = new PersonnelContext();

        public List<UserAccess> GetPersonBasicInfo(int appEntityID)
        {
            var myUserAccess = (from p in db.People
                                join u in db.Users on p.AppEntityID equals u.AppEntityID
                                where p.AppEntityID == appEntityID
                                select new UserAccess
                                {
                                    AppEntityID = p.AppEntityID,
                                    First = p.FirstName,
                                    Last = p.LastName,
                                    PIN = u.PIN,
                                    SAP = u.SAP,
                                    Badge = u.Badge,

                                    UserWebSites = (from us in db.Users
                                                    join ws in db.WebSiteUsers on us.AppEntityID equals ws.AppEntityID
                                                    where ws.AppEntityID == appEntityID
                                                    select new UserWebSite
                                                    {
                                                        WebSiteUserID = ws.WebSiteUserID,
                                                        WebLinkID = ws.WebLinkID,
                                                        AppEntityID = ws.AppEntityID,
                                                        EnteredByID = ws.EnteredByID,
                                                        WebSite = ws.SIA_WebLinks.Name,
                                                        ModifiedDate = ws.ModifiedDate
                                                    }),
                                    WebSiteFeatures = (from us in db.Users
                                                        join sf in db.AppFeatureAccesses on us.AppEntityID equals sf.AppEntityID
                                                        where sf.AppEntityID == appEntityID
                                                        select new FeatureAccess
                                                        {
                                                            AppEnityID = sf.AppEntityID,
                                                            WebLinkID = sf.WebLinkID,
                                                            AppFeatureID = sf.AppFeatureID,
                                                            AllowFeatureFlag = sf.AllowFeatureFlag,
                                                            UnlockQ = sf.UnlockQ,
                                                            UnlockAttempt = (sf.UnlockAttempt ?? DateTime.Now),
                                                            UnlockedBy = (sf.UnlockedBy ?? 0),
                                                            UnlockDate = (sf.UnlockedDate ?? DateTime.Now)
                                                        })

                                });

            return myUserAccess.ToList();

        }
    }
}