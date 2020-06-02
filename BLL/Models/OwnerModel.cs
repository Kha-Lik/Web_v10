using System.Collections;
using System.Collections.Generic;

namespace BLL.Models
{
    public class OwnerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public ICollection<ComputerModel> Computers { get; set; }
        public ICollection<OrderModel> Orders { get; set; }
    }
}
