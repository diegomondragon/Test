using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearcher.Common
{
    public enum FilterType
    {
        Undefined,
        Contains,
        Equal,
        GreatherEqualThan,
        LessEqualThan
    }

    public enum ColumnType
    {
        String,
        Number,
        Date
    }
}
