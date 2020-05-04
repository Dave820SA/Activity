using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPDWeb.Business.Interface
{
    public interface IDocHistoryBusiness
    {
        string GetDocHistory(int docId);
    }
}
