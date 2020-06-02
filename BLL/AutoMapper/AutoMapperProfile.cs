﻿using System;
using System.Collections.Generic;
 using System.Linq;
 using System.Text;
using AutoMapper;
 using BLL.Interfaces;
 using BLL.Models;
 using DAL.Entities;

namespace BLL.AutoMapper
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Computer, ComputerModel>()
                .ForMember(c => c.Parts, opt 
                    => opt.MapFrom(c => c.Parts.Select(cp => cp.Part)));
            CreateMap<ComputerModel, Computer>()
                .ForMember(c => c.Parts, opt 
                    => opt.MapFrom(c => c.Parts.Select(p => new ComputerParts {PartId = p.Id})));
            CreateMap<OrderModel, Order>().ForMember(o => o.PartsForReplacement, opt
                => opt.MapFrom(o => o.PartsForReplacement.Select(p => new OrderParts {PartId = p.Id})));
            CreateMap<Order, OrderModel>()
                .ForMember(o => o.PartsForReplacement, opt 
                    => opt.MapFrom(o => o.PartsForReplacement.Select(cp => cp.Part)));
            CreateMap<OwnerModel, Owner>().ReverseMap();
            CreateMap<PartModel, Part>().ReverseMap();
            CreateMap<UserRegistrationModel, User>()
                .ForMember(u => u.UserName,
                    opt => opt.MapFrom(x => x.Email));
        }
    }
}
