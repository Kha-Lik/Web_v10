using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class PartService : IPartService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public PartService(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public async Task<IEnumerable<PartModel>> GetAll()
        {
            var parts = await _unit.PartRepository.GetAll().Include(p => p.Computers)
                .Include(p => p.Orders)
                .ToListAsync();
            var partModels = _mapper.Map<IEnumerable<PartModel>>(parts);
            return partModels;
        }

        public async Task<PartModel> GetById(int id)
        {
            var part = await _unit.PartRepository.GetByIdAsync(id);
            return _mapper.Map<PartModel>(part);
        }

        public async Task<IEnumerable<PartModel>> GetByName(string name)
        {
            var parts = await _unit.PartRepository.GetAll().Where(p => p.Name.Equals(name)).ToListAsync();
            return _mapper.Map<IEnumerable<PartModel>>(parts);
        }

        public async Task<IEnumerable<PartModel>> GetByDate(DateTime date)
        {
            var parts = await _unit.PartRepository.GetAll().Where(p => p.ManufactureDate.Date.Equals(date.Date))
                .ToListAsync();
            return _mapper.Map<IEnumerable<PartModel>>(parts);
        }

        public async Task<IEnumerable<PartModel>> GetByOrderId(int orderId)
        {
            var parts = await _unit.PartRepository.GetAll().Where(p => p.Orders
                .Any(ord => ord.Id.Equals(orderId))).ToListAsync();
            return _mapper.Map<IEnumerable<PartModel>>(parts);
        }
    }
}