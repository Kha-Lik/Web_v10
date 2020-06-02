﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
 using BLL.Interfaces;
 using BLL.Models;
 using DAL.Entities;
 using DAL.Interfaces;
 using Microsoft.EntityFrameworkCore;

 namespace BLL.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public OwnerService(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }


        public async Task<IEnumerable<OwnerModel>> GetAll()
        {
            var owners = await _unit.OwnerRepository.GetAll().Include(o => o.Computers).ToListAsync();
            return _mapper.Map<IEnumerable<OwnerModel>>(owners);
        }

        public async Task<IEnumerable<OwnerModel>> GetByFullName(string fullName)
        {
            var firstName = fullName.Split(' ')[1];
            var lastName = fullName.Split(' ')[0];
            var secondName = fullName.Split(' ')[2];
            var owners = await _unit.OwnerRepository.GetAll().Where(o => o.FirstName.Equals(firstName) 
                                       && o.LastName.Equals(lastName) && o.SecondName.Equals(secondName)).ToListAsync();
            return _mapper.Map<IEnumerable<OwnerModel>>(owners);
        }

        public async Task<IEnumerable<OwnerModel>> GetByPartName(string name)
        {
            var owners = await _unit.OwnerRepository.GetAll()
                .Include(o => o.Orders)
                .ThenInclude(ord => ord.PartsForReplacement).Where(owner => owner.Orders.Any(ord => 
                ord.PartsForReplacement.Any(p => p.Part.Name.Equals(name)))).ToListAsync();

            return _mapper.Map<IEnumerable<OwnerModel>>(owners);
        }

        public async Task<OwnerModel> GetByOrderId(int orderId)
        {
            var owner = await _unit.OwnerRepository.GetAll().Include(o => o.Orders)
                .Where(o => o.Orders.Any(ord => ord.Id.Equals(orderId))).FirstOrDefaultAsync();
            return _mapper.Map<OwnerModel>(owner);
        }

        public async Task<IEnumerable<OwnerModel>> GetByOrderDate(DateTime date)
        {
            var owners = await _unit.OwnerRepository.GetAll().Include(o => o.Orders)
                .Where(o => o.Orders.Any(ord => ord.CreationDate.Date.Equals(date.Date))).ToListAsync();
            return _mapper.Map<IEnumerable<OwnerModel>>(owners);
        }

        public async Task<IEnumerable<OwnerModel>> GetByComputerModel(string model)
        {
            var owners = await _unit.OwnerRepository.GetAll().Include(o => o.Computers)
                .Where(o => o.Computers.Any(c => c.Model.Equals(model))).ToListAsync();
            return _mapper.Map<IEnumerable<OwnerModel>>(owners);
        }
    }
}