using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ITManager.Models.UserPageModel
{
    
    public partial class User : INotifyPropertyChanged
    {
        public User()
        {
            this.Educations = new HashSet<Education>();
            this.Languages = new HashSet<Language>();
            this.ProfessionalSummaries = new HashSet<ProfessionalSummary>();
            this.Projects = new HashSet<Project>();
            this.Queries = new HashSet<Query>();
            this.Sertificates = new HashSet<Sertificate>();
            this.UserRoles = new HashSet<UserRole>();
            this.UserSkills = new HashSet<UserSkill>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public System.DateTime Birthday { get; set; }
        public int PositionId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsInitial { get; set; }
        public string DefaultPassword { get; set; }
    
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<ProfessionalSummary> ProfessionalSummaries { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Query> Queries { get; set; }
        public virtual ICollection<Sertificate> Sertificates { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
