using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceDefinition
{
    public class DataSourceDefinition
    {
        public DataSourceDefinition()
        {
            Fields = new List<Field>();
        }

        public Guid Id { get; set; }
        public String Name { get; set; }
        public List<Field> Fields { get; set; }
    }
}
