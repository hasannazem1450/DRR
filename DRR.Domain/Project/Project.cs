using DRR.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Project.Exceptions;

namespace DRR.Domain.Project
{
    public class Project
    {
        public Project(string name, int price)
        {
            GuardForName(name);
            GuardForPrice(price);

            Name = name;
            Price = price;
            CreateDate = DateTime.Now;
            ModifyDate = DateTime.Now;
        }




        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int Price { get; set; }

        private static void GuardForName(string name)
        {
            if (name.IsNullOrEmptyExtension())
            {
                throw new ProjectNameIsNullOrEmptyException();
            }
        }

        private static void GuardForPrice(int? price)
        {
            if (!price.IsValidNullableId())
            {
                throw new ProjectPriceIsNullOrEmptyException();
            }
        }
    }
}
