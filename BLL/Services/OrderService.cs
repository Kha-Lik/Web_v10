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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unit, IMapper mapper)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public async Task<IEnumerable<OrderModel>> GetAll()
        {
            var orders = await _unit.OrderRepository.GetAll().Include(ord => ord.Owner)
                .Include(ord => ord.PartsForReplacement).ToListAsync();
            return _mapper.Map<IEnumerable<OrderModel>>(orders);
        }

        public async Task CreateOrderAsync(OrderModel orderModel)
        {
            if (!IsRepairable(orderModel.PartsForReplacement)) return;
            var order = _mapper.Map<Order>(orderModel);
            await _unit.OrderRepository.CreateAsync(order);
            await _unit.SaveChangesAsync();
        }
        
        private bool IsRepairable(IEnumerable<PartModel> partsForReplacement)
        {
            return !partsForReplacement.Select(p => p.Name).Except(_unit.PartRepository.GetAll().Select(a => a.Name)).Any();
        }
    }
}
