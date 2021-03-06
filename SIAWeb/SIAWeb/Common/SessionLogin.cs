﻿using System.Linq;
using System.Web;
using UserBusinessLayer;

namespace SIAWeb.Common
{
    public class SessionLogin
    {
        private void SessionUser(string userPin)
        {
            UserLayerEntities user = new UserLayerEntities();

            var myUser = from u in user.spWebSiteUserInfo(userPin, 1)
                         select u;
            //myUser = myUser.ToList();

            var theUser = myUser.ToList();

            if (theUser.Count > 0)
            {
              foreach (var u in theUser)
                {
                    HttpContext.Current.Session.Add("AppEntityID", u.AppEntityID.ToString());
                    HttpContext.Current.Session.Add("userPin", u.PIN.ToString());
                    HttpContext.Current.Session.Add("userName", u.UserName.ToString());
                    HttpContext.Current.Session.Add("WebRole", u.WebRole.ToString());
                    HttpContext.Current.Session.Add("GateStatus", u.GateStatus.ToString());
                }
            }
            else
            {
                HttpContext.Current.Session.Add("AppEntityID", "0");
                HttpContext.Current.Session.Add("userPin", "unkPin");
                HttpContext.Current.Session.Add("userName", "Unknown User");
                HttpContext.Current.Session.Add("WebRole", "unkRole");
                HttpContext.Current.Session.Add("GateStatus", "0");
            }
            
        }

        public void getUserPin(string userPin)
        {
            string result;
            if (userPin.Length == 12)
            {
                result = userPin.Substring(userPin.Length - 7, 7);
            }
            else
            {
                result = userPin.Substring(userPin.Length - 6, 6);
            }

            SessionUser(result);

            //return result;
        }
    }
}