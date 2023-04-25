using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum CarState
    {
        [EnumMember(Value = "Available")]
        Available, // 0
        [EnumMember(Value = "Rented")]
        Rented, // 1
        [EnumMember(Value = "Maintenance")]
        Maintenance // 2
    }
}
