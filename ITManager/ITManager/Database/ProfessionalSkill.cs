//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITManager.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProfessionalSkill
    {
        public int Id { get; set; }
        public Nullable<int> ProfessionalGroupId { get; set; }
        public string Name { get; set; }
    
        public virtual TechnicalGroup TechnicalGroup { get; set; }
        public virtual UserSkill UserSkill { get; set; }
    }
}
