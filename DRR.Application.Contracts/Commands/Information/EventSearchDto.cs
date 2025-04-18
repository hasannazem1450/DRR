using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Information
{
    public class EventSearchDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "در همایش ها و نمایشگاه ها";
        public string Result { get; set; }
        public string ShortDesc { get; set; }
        public string Link { get; set; }
    }
}
