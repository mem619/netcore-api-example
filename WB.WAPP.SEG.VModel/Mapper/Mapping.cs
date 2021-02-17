using AutoMapper;
using WB.WAPP.SEG.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WB.WAPP.SEG.VModel.Mapper
{
    class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<VSample, Sample>()
                .ReverseMap();
            CreateMap<VParameter, Parameter>()
                .ReverseMap();
        }
    }
}
