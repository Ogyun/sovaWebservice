using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceLayer.Models;

namespace WebServiceLayer.Profiles
{
    public class MarkingProfile:Profile
    {
        public MarkingProfile()
        {
            CreateMap<MarkedQuestion, MarkedQuestionDto>();
            CreateMap<MarkingForCreation, Marking>();

        }
    }
}