﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
 using BLL.Models;

 namespace BLL.Interfaces
{
    public interface IOwnerService
    {
        Task<IEnumerable<OwnerModel>> GetAll();
        Task<IEnumerable<OwnerModel>> GetByFullName(string fullName);
        Task<IEnumerable<OwnerModel>> GetByPartName(string name);
        Task<OwnerModel> GetByOrderId(int orderId);
        Task<IEnumerable<OwnerModel>> GetByOrderDate(DateTime date);
        Task<IEnumerable<OwnerModel>> GetByComputerModel(string model);
    }
}