using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IECAWeb.Models
{
    public class AuditNotes
    {
        //public int OfficerID { get; set; }
        public int NoteID { get; set; }
        public int NoteTypeID { get; set; }
        public string NoteType { get; set; }
        public int AuditHistID { get; set; }
        public int AuditQuestNbrID { get; set; }
        public string AuditQuestionNbr { get; set; }
        public string AuditQuestion { get; set; }
        public string AuditNote { get; set; }
        public int NoteByID { get; set; }
        public string Supervisor { get; set; }
        //public string NoteBy { get; set; }
        public DateTime? NoteDate { get; set; }
        public Boolean? Followup { get; set; }
    }
}