using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ComputerWorkshopContext _context;

        public UnitOfWork(IRepository<Computer> computerRepository,
            IRepository<ComputerParts> computerPartsRepository,
            IRepository<Order> orderRepository,
            IRepository<Owner> ownerRepository,
            IRepository<Part> partRepository,
            ComputerWorkshopContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            ComputerRepository = computerRepository;
            ComputerPartsRepository = computerPartsRepository;
            OrderRepository = orderRepository;
            OwnerRepository = ownerRepository;
            PartRepository = partRepository;
            _context = context;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public IRepository<Computer> ComputerRepository { get; }
        public IRepository<ComputerParts> ComputerPartsRepository { get; }
        public IRepository<Order> OrderRepository { get; }
        public IRepository<Owner> OwnerRepository { get; }
        public IRepository<Part> PartRepository { get; }
        public UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}