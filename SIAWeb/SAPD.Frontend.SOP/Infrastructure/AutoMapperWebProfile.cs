using SAPD.Frontend.SOP.Models;
using SAPDWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPD.Frontend.SOP.Infrastructure
{
    public class AutoMapperWebProfile : AutoMapper.Profile
    {

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a => { a.AddProfile<AutoMapperWebProfile>(); });
        }


        public AutoMapperWebProfile()
        {
            //CreateMap<DomainDocHistory, DocHistory>();

            //CreateMap<DocHistory, DomainDocHistory>();

            ////From Techno Tips Part 53, Time 5:00
            ////Map an int from the Domain model to a string in the view model
            ////Can be encripted also, look at the video starting at 6:30
            //CreateMap<DomainSOP, SOPModel>()
            //    .ForMember(dest=> dest.ExtraValue,opt=> opt.MapFrom(src=>src.ExtraValue.ToString()));

            //CreateMap<SOPModel, DomainSOP>();


            CreateMap<SOPDomainModel, SOPs>();
            CreateMap<SOPs, SOPDomainModel>();


        }
    }
}