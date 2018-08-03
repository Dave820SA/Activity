using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IECAWeb.Models;

namespace IECAWeb.Common
{
    public class GetGeneralNotes
    {
        AuditEntities pc = new AuditEntities();

        public List<AuditNotes> AuditNotes(int auditID)
        {
            var myNotes = (from an in pc.Sup_AuditNotes
                           join nt in pc.NoteTypes on an.NoteTypeID equals nt.AuditNoteTypeID
                           join aq in pc.Audit_Question on an.AuditQuestionID equals aq.AuditQuestionID
                           join a in pc.Auditors on an.NoteByID equals a.AppEntityID
                           where an.AuditHistID == auditID
                           select new AuditNotes
                           {
                               NoteID = an.NoteID,
                               NoteTypeID = an.NoteTypeID,
                               NoteType = nt.AuditNoteType,
                               AuditHistID = an.AuditHistID,
                               AuditQuestNbrID = an.AuditQuestionID ?? 0,
                               AuditQuestionNbr = aq.QuestionNbr,
                               AuditQuestion = aq.Question,
                               AuditNote = an.AuditNotes,
                               NoteByID = an.NoteByID,
                               Supervisor = a.ApproveBy,
                               NoteDate = an.NoteDate,
                               Followup = an.FollowupFlag

                           });
            return myNotes.ToList();
                           
        }
    }
}