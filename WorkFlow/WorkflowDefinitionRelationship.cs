using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow
{
    public class WorkflowDefinitionRelationship
    {

        public WorkflowDefinitionRelationship(String leftField, String rightField)
        {
            RightField = rightField; LeftField = leftField;
        }

        public String RightField { get; private set; }
        public String LeftField { get; private set; }

    }
}
