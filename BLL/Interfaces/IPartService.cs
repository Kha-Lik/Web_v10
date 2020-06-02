using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IPartService
    {
        Task<IEnumerable<PartModel>> GetAll();
        Task<PartModel> GetById(int id);
        Task<IEnumerable<PartModel>> GetByName(string name);
        Task<IEnumerable<PartModel>> GetByDate(DateTime date);
        Task<IEnumerable<PartModel>> GetByOrderId(int orderId);
    }
}