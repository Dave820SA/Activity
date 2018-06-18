using System.Collections.Generic;
using System.Linq;
using PersonnelBusinessLayer;

namespace IECAWeb.Models
{

    public class GetGroupMembers
    {
        PersonnelContext gpm = new PersonnelContext();

        public List<GroupMembers> GetGroupMemberInfo(int groupID)
        {

            var myMemberInfo = (from p in gpm.People
                                join u in gpm.Users on p.AppEntityID equals u.AppEntityID
                                join jt in gpm.JobTitles on u.JobTitleID equals jt.JobTitleID
                                join gm in gpm.GroupMembers on u.AppEntityID equals gm.AppEntityID
                                join gt in gpm.GroupTitles on gm.GroupTitleID equals gt.GroupTitleID
                                join o in gpm.Office_Office on u.OfficeID equals o.OfficeID
                                join ws in gpm.WorkStatus on u.WorkStatusID equals ws.WorkStatusID

                                where gm.GroupTitleID == groupID && ws.Ranking <= 9 && gm.VisibleFlag == true
                                select new GroupMembers
                                {
                                    GroupMemberID = gm.GroupMemberID,
                                    //GroupName = gt.Name,
                                    //GroupInfo = gt.GroupInfo,
                                    MemberInfo = gm.MemberInfo,
                                    AppEntityID = p.AppEntityID,
                                    First = p.FirstName,
                                    Last = p.LastName,
                                    Badge = u.Badge,
                                    SAP = u.SAP,
                                    OfficeID = o.OfficeID,
                                    OfficeCode = o.Code,
                                    Office = o.Name,
                                    WorkStatus = ws.Name,
                                    JobTitle = jt.Name,
                                    RankCode = jt.NameCode,
                                    PicURL = (from pi in gpm.vPictures
                                              where pi.AppEntityID == p.AppEntityID
                                              orderby pi.DateTimeStamp descending
                                              select pi.ImagePath).FirstOrDefault(),

                                    Emails = (from ep in gpm.People
                                              join e in gpm.P_EmailAddress on ep.AppEntityID equals e.AppEntityID
                                              join et in gpm.p_EmailAddressType on e.EmailAddressTypeID equals et.EmailAddressTypeID
                                              where ep.AppEntityID == p.AppEntityID && e.EmailAddressTypeID == 1
                                              select new EmailAddress
                                              {
                                                  AddressType = et.Name,
                                                  userEmailAddress = e.EmailAddress
                                              }),
                                    PhoneNumbers = (from pp in gpm.People
                                                    join ph in gpm.PersonPhones on pp.AppEntityID equals ph.AppEntityID
                                                    join phType in gpm.PhoneNumberTypes on ph.PhoneNumberTypeID equals phType.PhoneNumberTypeID
                                                    where ph.AppEntityID == p.AppEntityID && (phType.PhoneNumberTypeID == 1 || phType.PhoneNumberTypeID == 2)
                                                    select new PhoneNumber
                                                    {
                                                        PhoneType = phType.Name,
                                                        PhoneNbr = ph.PhoneNumber
                                                    }),

                                });

            return myMemberInfo.ToList();

        }
    }
}
