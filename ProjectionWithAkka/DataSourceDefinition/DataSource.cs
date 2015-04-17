using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceDefinition
{
    public class DataSource
    {
        public DataSource()
        {
            Fields = new Dictionary<String, Object>();
        }

        public Guid Id { get; set; }
        public IDictionary<String, Object> Fields { get; set; }
    }
}
