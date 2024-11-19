using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.Finance
{
    public class DiscountCode : Entity<int>
    {
        public DiscountCode(string code, decimal discountPercent, bool isUsed)
        {
            Code = code;
            DiscountPercent = discountPercent;
            IsUsed = isUsed;

        }

        public string  Code { get; set; }
        public decimal DiscountPercent { get; set; }
        public bool IsUsed { get; set; }


    }

}
