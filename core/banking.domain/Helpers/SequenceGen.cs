using banking.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking.domain.Helpers
{
    public class SequenceGen
    {
        public static int GetNextSeqId(DateOnly date)
        {
            if (Account.AllTransactions.Any())
            {
                var _nxtid = Account.AllTransactions.Where(e => e.Date == date).OrderByDescending(e => e.Id).FirstOrDefault();

                if (_nxtid != null)
                {
                    return _nxtid.Id++;
                }

            }
            return 1;
        }
    }
}
