using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace web.Models
{
    public enum PaymentStatusEnum
    {
        [Description("None")]
        None,
        [Description("PIF")]
        PIF,
        [Description("Deposit")]
        Deposit
    }
}