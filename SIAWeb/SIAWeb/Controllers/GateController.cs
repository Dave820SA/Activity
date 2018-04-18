using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIAWeb.Models;
using System.Text;

namespace SIAWeb.Controllers
{
    public class GateController : Controller
    {
        private List<GateItems> _status;
        private Boolean _gatestatus;
        private string _questionNbr;
        private DateTime _attempt;
        private StringBuilder _sb;


       public ActionResult Index()
        {
           //get the app users ID
           string appID = (string)System.Web.HttpContext.Current.Session["AppEntityID"];
           if (string.IsNullOrEmpty(appID) || appID == "0")
           {
               return RedirectToAction("index", "NonUser");
           }
           //Load the gate information
           loadGateInfo(appID);
           _sb = new StringBuilder();
           
           if (_gatestatus == false )
           {
               int nbr;
               if (_questionNbr == null)
               {
                   nbr = questionNbr(0);
               }
               else
               {
                    nbr = questionNbr(_questionNbr.Length);
               }

               _sb.Append("Last attempt was ");
               _sb.Append(_attempt);
               _sb.Append("<br/><br/>");
               _sb.Append(getQuestion(nbr));


               ViewBag.InfoToUser = _sb.ToString();
           }

           return PartialView("_GateQ", ViewBag.InfoToUser);
           //return View();
        }

       private void loadGateInfo(string appID)
       {
           GateStatus gStatus = new GateStatus();
           _status = gStatus.GetGateStatus(Int32.Parse(appID));

           foreach (var item in _status)
           {
               _gatestatus = item.Status;
               _questionNbr = item.QuestionNbrs;
               _attempt = item.Attempt;
           }       
       }

       private int questionNbr(int nbr)
       {
           switch (nbr)
           {
               case 1:
                   return 2;
               case 2:
                   return 3;
               case 3:
                   return 4;
               case 4:
                   return 5;
               default:
                   return 1;
           }
       }

       private StringBuilder  getQuestion(int qNbr)
       {
           var questions = GateKey.GetQuestions();
           StringBuilder _sb = new StringBuilder();
           var result = questions.Where(p => p.QuestionNumber == qNbr);
           foreach (var item in result)
           {
               _sb.Append("Q# ");
               _sb.Append(item.QuestionNumber.ToString());
               _sb.Append("&nbsp;&nbsp;");
               _sb.Append(item.Question.ToString());

           }

           return _sb;
       }


    }
}
