using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Profile;

namespace DRR.Application.Contracts.Commands.News
{
    public class AdsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public virtual SmeProfile SmeProfile { get; set; }
    }
}
