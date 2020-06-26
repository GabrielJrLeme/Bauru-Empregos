using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Models.Enum
{
    public enum Role
    {
        [Description("Administrator")]
        Admin,

        [Description("User")]
        Client

    }
}
