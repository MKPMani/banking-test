using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace banking.app.Helpers
{
    public class EnumTransType
    {
        public enum TransType
        {
            [EnumMember(Value = "D")]
            Deposit,
            [EnumMember(Value = "W")]
            Withdraw,
            [EnumMember(Value = "I")]
            Interest
        }
    }
}
