using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow
{
    public class WorkflowResponse
    {
        public Guid Key { get; set; }
        public String Name { get; set; }
        public IEnumerable<dynamic> Data { get; set; }
    }
}
