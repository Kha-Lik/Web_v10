using System;
using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class PartModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ManufactureDate { get; set; }
    }
}