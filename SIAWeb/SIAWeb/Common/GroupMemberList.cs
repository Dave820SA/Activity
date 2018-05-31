using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonnelBusinessLayer;
using SIAWeb.Models;

namespace SIAWeb.Common
{
    public class GroupMemberList
    {
        PersonnelContext db = new PersonnelContext();
        public List<GroupMembers> GetGroupMemberList(int id)
        {
            var myGropMembers = (from p in db.People
                                 join u in db.Users on p.AppEntityID equals u.AppEntityID
                                 join jt in db.JobTitles on u.JobTitleID equals jt.JobTitleID
                                 join gm in db.GroupMembers on u.AppEntityID equals gm.AppEntityID
                                 join ws in db.WorkStatus on u.WorkStatusID equals ws.WorkStatusID
                                 where gm.GroupTitleID == id && ws.Ranking <= 9
                                 select new GroupMembers
                                 {
                                     GroupTitleID = gm.GroupTitleID,
                                     GroupMemberID = gm.GroupMemberID,
                                     AppEntityID = p.AppEntityID,
                                     First = p.FirstName,
                                     Last = p.LastName,
                                     Badge = u.Badge,
                                     JobTitle = jt.Name,
                                     MemberInfo = gm.MemberInfo,
                                     Visible = gm.VisibleFlag

                                 });
            return myGropMembers.ToList();

        }

        public void AddGroupMember(int appEntity, int GroupID)
        {
            db.User_spGroupMemberAdd(appEntity, GroupID);
        }
    }
}