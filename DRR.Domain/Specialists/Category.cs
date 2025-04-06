using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.Specialists
{
    public class Category : Entity<int>
    {
        public string CategoryName { get; set; }
        public string CategoryLogoFile { get; set; }
        public Category()
        {


        }
        public Category(string categoryName, string categoryLogoFile)
        {
            CategoryName = categoryName;
            CategoryLogoFile = categoryLogoFile;
        }
        public void Update(string categoryName, string categoryLogoFile)
        {
            CategoryName = categoryName;
            CategoryLogoFile = categoryLogoFile;
        }
    }
}
