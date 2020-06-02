﻿ using System.Collections.Generic;
  using DAL.Entities;

  namespace BLL.Models
{
    public class ComputerModel
    {
        public string Model { get; set; }
        public OwnerModel Owner { get; set; }
        public int OwnerId { get; set; }
        public ICollection<PartModel> Parts { get; set; }
    }
}