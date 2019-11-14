using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceLayer.Models;

namespace WebServiceLayer.Profiles
{
    public class NoteProfile:Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteDto>();
        }
    }
}
