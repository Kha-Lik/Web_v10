using System;
using System.Collections.Generic;

namespace BLL.Models
{
   public class OrderModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<PartModel> PartsForReplacement { get; set; }
        public int OwnerId { get; set; }
        public decimal Price { get; set; }  

    }
}