//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Polypoints.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Question
    {
        public Question()
        {
            this.QuestionResponses = new HashSet<QuestionRespons>();
        }
    
        public int QuestionID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string QuestionText { get; set; }
        public Nullable<int> QuestionType { get; set; }
        public Nullable<int> ParentID { get; set; }
        public byte[] QuestionImage { get; set; }
        public Nullable<int> ParentResponseID { get; set; }
    
        public virtual ICollection<QuestionRespons> QuestionResponses { get; set; }
        public virtual QuestionType QuestionType1 { get; set; }
    }
}
