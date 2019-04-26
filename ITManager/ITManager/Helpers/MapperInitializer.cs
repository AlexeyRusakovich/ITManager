using AutoMapper;
using ITManager.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Helpers
{
    public static class MapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg=>
            {
                cfg.CreateMap<Position, Models.UserPageModel.Position>();
                cfg.CreateMap<ProfessionalSummary, Models.UserPageModel.ProfessionalSummary>();
                cfg.CreateMap<UserSkill, Models.UserPageModel.UserSkill>();
                cfg.CreateMap<UserProject, Models.UserPageModel.Project>()
                    .ForMember(m => m.RelatedProject, o => o.Ignore());
                cfg.CreateMap<Education, Models.UserPageModel.Education>();
                cfg.CreateMap<Sertificate, Models.UserPageModel.Sertificate>();
                cfg.CreateMap<Language, Models.UserPageModel.Language>();
                cfg.CreateMap<ProfessionalSkill, Models.UserPageModel.ProfessionalSkill>()
                    .ForMember(vm => vm.Id, m => m.MapFrom(u => u.Id))
                    .ForMember(vm => vm.Name, m => m.MapFrom(u => u.Name ));
            });
        }
    }
}
