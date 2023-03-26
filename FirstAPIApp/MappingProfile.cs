﻿using AutoMapper;
using FirstAPIApp.DTOs;
using FirstAPIApp.DTOs.CreateUpdateObjects;

namespace FirstAPIApp
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<AnnouncementDTO, CreateUpdateAnnouncement>().ReverseMap();
        }
        
    }
}
