using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Computer> ComputerRepository { get; }
        IRepository<ComputerParts> ComputerPartsRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<Owner> OwnerRepository { get; }
        IRepository<Part> PartRepository { get; }
        UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; }
        Task SaveChangesAsync();
    }
}