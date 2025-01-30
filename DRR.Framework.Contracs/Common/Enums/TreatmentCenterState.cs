using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Framework.Contracs.Common.Enums;

public enum TreatmentCenterState
{
    /// <summary>
    /// گذشته
    /// </summary>
    [Description("تعطیل")]
    Finished = -1,

    /// <summary>
    /// در حال برگزاری
    /// </summary>
    [Description("در حال فعالیت")]
    InProgress = 0,

    /// <summary>
    /// آینده
    /// </summary>
    [Description("بزودی")]
    Feature = 1
}