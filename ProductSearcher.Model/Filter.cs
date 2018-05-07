using ProductSearcher.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearcher.Model
{
    public class Filter
    {
        public FilterType FilterType { get; set; }
        public string ColumnName { get; set; }
        public string Value { get; set; }

    }
}
