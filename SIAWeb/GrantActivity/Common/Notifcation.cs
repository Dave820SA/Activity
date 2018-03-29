using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
using GrantActivity.Models;
using GrantBusinessLayer;

namespace GrantActivity.Common
{
    public class Notifcation
    {
        GrantEntities db = new GrantEntities();

        public void NewActivity()
        {   
            MailMessage mail = new MailMessage();

            string listOfEmail = notifyWho((string)System.Web.HttpContext.Current.Session["AppEntityID"]);

            mail.To.Add(listOfEmail);
            mail.From = new MailAddress("SAPDtraffic.grantadministration@sanantonio.gov", "GrantActivity Admin");
            mail.Subject = "New Items";

            string body = "<h1>Grant Administrative Activity </h1>";
            body += "<p>Auto Notification!</p>";

            var item = getOpenItems((string)System.Web.HttpContext.Current.Session["AppEntityID"]);

            int iCount = item.Count();

            body += "<p>You have <span style=\"color: #0066FF\">" + iCount + "</span> open administrative items to approve.</p>";

            body += "<table>";
            
            foreach (var i in item)
            {
                body += "<tr><td><span style=\"color: #0066FF\">Officer:</span> " + i.Officer + "&nbsp;&nbsp; </td><td>   <span style=\"color: #0066FF\">Event Date:</span> " + i.EnteredDate + "</td></tr>";
            };
            
            body += "</table>";
            
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("mail.sanantonio.gov"); 
            smtp.Send(mail);
        }



        public void MoreInformation(int dailyID)
        {
            MailMessage mail = new MailMessage();

            var moreInfoitem = getMoreInfoItem(dailyID);
            //string listOfEmail;

            string body = "<h1>Grant Administrative Activity </h1>";
            body += "<p>Auto Notification!</p>";
            body += "<table>";
            //body += "The Grant Administrator is requesting you provide more information on the item you entered: "
            foreach (var i in moreInfoitem)
            {
                body += "<p>" + i.AdminNotes + "</p>";
                body += "<tr><td><span style=\"color: #0066FF\">Start Date:</span> " + i.DailyStart + "&nbsp;&nbsp; </td><td>   <span style=\"color: #0066FF\">End Date:</span> " + i.DailyEnd + "</td></tr>";

                 foreach (var c in i.Categories )
                    {
                        body += "<p><span style=\"color: #0066FF\">" + c.EventCategory  + "</span></p>";
                    }

                foreach (var e in i.Emails )
                    {        
                       //mail.To.Add(e.EmailAddress);
                       mail.To.Add("douglas.davidson@sanantonio.gov");
                    }
            }

            body += "</table>";

            

            mail.From = new MailAddress("SAPDtraffic.grantadministration@sanantonio.gov", "GrantActivity Admin");
            mail.Subject = "Need More Information";

            
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("mail.sanantonio.gov");
            smtp.Send(mail);
        }

        private string notifyWho(string appEntity)
        {
            switch (appEntity)
            {
                case "752":
                    return "Tonja.Brandt@sanantonio.gov";

                default:
                    return "Brent.Smith@sanantonio.gov";
                    //return "douglas.davidson@sanantonio.gov";
            }

        }


        private List<OpenAdminItem> getOpenItems(string appEntity)
        {
            switch (appEntity)
            {
                case "752"://If Brent is the user return all open admin items except his
                   var myOpenItem = (from o in db.Grant_Daily
                                     where o.ApprovedFlag == false && o.AppEntityID != 752
                             select new OpenAdminItem
                             {
                                 AdminDailyID = o.AdminDailyID,
                                 AppEntityID = o.AppEntityID,
                                 Officer = o.Person.FirstName + " " + o.Person.LastName,
                                 EnteredDate = o.DailyStart,
                             });

                   return myOpenItem.ToList();

                default://the default is to return all open admin items
                   myOpenItem = (from o in db.Grant_Daily
                                     where o.ApprovedFlag == false 
                                     select new OpenAdminItem
                                     {
                                         AdminDailyID = o.AdminDailyID,
                                         AppEntityID = o.AppEntityID,
                                         Officer = o.Person.FirstName + " " + o.Person.LastName,
                                         EnteredDate = o.DailyStart,
                                     });

                   return myOpenItem.ToList();
            }
            
        }

        //
        private List<Daily> getMoreInfoItem(int id)
        {
            var myNeededMoreInfo = (from d in db.Grant_Daily

                                    join p in db.People on d.AppEntityID equals p.AppEntityID


                                    orderby d.EnteredDate
                                    where d.AdminDailyID == id
                                    select new Daily
                                    {
                                        AdminDailyID = d.AdminDailyID,
                                        AppEntity = d.AppEntityID,
                                        GrantTypeID = d.GrantTypeID,
                                        DailyStart = d.DailyStart,
                                        DailyEnd = d.DailyEnd,
                                        EnteredDate = d.EnteredDate,
                                        ApproveFlag = d.ApprovedFlag ?? false,
                                        MoreInfoFlag = d.MoreInformationFlag ?? true,
                                        AdminNotes = d.AdminNotes,
                                        ApproveByID = d.ApprovedByID ?? 0,
                                        ApproveDate = d.ApprovedDate ?? DateTime.Now,
                                        

                                        Activities = (from ds in db.Grant_Daily
                                            join ah in db.Grant_Activity on ds.AdminDailyID equals ah.DailyID
                                            where ds.AdminDailyID == id
                                            select new Activity
                                            {
                                                DailyID = ah.DailyID,
                                                CategoryID = ah.CategoryID,
                                                Notes = ah.Notes,
                                                EnteredDate = ah.EnteredDate ?? DateTime.Now,

                                            }),

                                            Categories =  (from a in db.Grant_Activity
                                            join c in db.Grant_Category on a.CategoryID equals c.CategoryID
                                            where a.DailyID == id
                                            select new Category
                                            {
                                                CategoryID = c.CategoryID,
                                                EventCategory = c.Name
                                            }), 
        
                                             Emails = (from w in db.Emails
                                            join ph in db.People on w.AppEntityID equals ph.AppEntityID
                                            where w.EmailAddressTypeID == 1 && ph.AppEntityID == 1

                                            select new EmployeeEmail
                                            {
                                                EmailAddresID = w.EmailAddressID,
                                                EmailAddress = w.EmailAddress
                                            })
                                                      
                                    });


            return myNeededMoreInfo.ToList();
        }

    
    }
}