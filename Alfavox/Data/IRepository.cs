using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfavox
{
    public interface IRepository
    {
        IDictionary<int, string> GetValuesForKeys(IEnumerable<int> dataKey);
        string GetValuesForKey(int dataKey);
    }
}
