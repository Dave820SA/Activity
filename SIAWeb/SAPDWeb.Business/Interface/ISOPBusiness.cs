using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPDWeb.Domain;

namespace SAPDWeb.Business.Interface
{
   public interface ISOPBusiness
    {
        string GetSOPName(int sopId);

        List<SOPDomainModel> GetAllSOP();
    }
}
