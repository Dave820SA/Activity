using SAPD.Frontend.SOP.Models;
using SAPDWeb.Business;
using SAPDWeb.Business.Interface;
using SAPDWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPD.Frontend.SOP.Controllers
{
    public class HomeController : Controller
    {
        //Create a instance of the interface Busniess class
        private readonly ISOPBusiness _isopbusiness;
        //TechnoTips Part 55 Time: 8.00 - Dependancy Injection
        public HomeController(ISOPBusiness isopbusiness)
        {
            _isopbusiness = isopbusiness;
        }

        public ActionResult Index()
        {
           
            ViewBag.SOPName = _isopbusiness.GetSOPName(820);

            //Techno Tips Part 55
            //Create a Domain model and use business layer method to fill it
            List<SOPDomainModel> listDomain = _isopbusiness.GetAllSOP();
            //Create an instance of a model in the curren project
            List<SOPModel> listSOPLocal = new List<SOPModel>();
            //Use AutoMapper to fill the local model from the Domain Model
            AutoMapper.Mapper.Map(listDomain, listSOPLocal);

            //Use the local model in the ViewBag
            ViewBag.SOPList = listSOPLocal;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}