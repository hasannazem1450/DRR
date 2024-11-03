using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Framework.Contracts.Makers
{
    public interface IDateTimeProvider
    {
        DateTime GetNow();
    }
}
