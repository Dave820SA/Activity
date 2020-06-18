using SAPDWeb.Business.Interface;
using SAPDWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPDWeb.Business
{

    //My Concreate Class
    public class SOPBusiness : ISOPBusiness
    {
        public SOPBusiness(int i)
        {

        }


        public List<SOPDomainModel> GetAllSOP()
        {
            List<SOPDomainModel> list = new List<SOPDomainModel>();

            list.Add(new SOPDomainModel
            {
                SOPId = 1,
                Name = "Big Daddy's SOP",
                BureauId = 2,
                ModifiedDate = DateTime.Now
            });

            list.Add(new SOPDomainModel
            {
                SOPId = 2,
                Name = "Patrol",
                BureauId = 3,
                ModifiedDate = DateTime.Now
            });

            list.Add(new SOPDomainModel
            {
                SOPId = 3,
                Name = "Traffic",
                BureauId = 4,
                ModifiedDate = DateTime.Now
            });

            return list;
        }

        public string GetSOPName(int sopId)
        {
            return "Big Daddy " + " " + sopId;
        }

        //public List<SOPDTO> GetCurrentSOPs()
        //{

        //}
    }
}
