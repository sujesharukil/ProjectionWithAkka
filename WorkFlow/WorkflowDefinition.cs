using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow
{
    public class WorkflowDefinition : IWorkflowDefinition
    {
        public WorkflowDefinition(Guid key, String name, WorkFlowActorType actorType, List<Field> fields, 
                                        WorkflowDefinition sourceLeft, WorkflowDefinition sourceRight, WorkflowDefinitionRelationship relationship)
        {
            Id = key;
            Key = key;
            Name = name;
            Fields = fields;
            SourceLeft = sourceLeft;
            SourceRight = sourceRight;
            Relationship = relationship;
        }

        public Guid Id { get; private set; }
        public Guid Key { get; private set; }
        public String Name { get; private set; }
        public WorkFlowActorType ActorType { get; private set; }
        public List<Field> Fields { get; private set; }
        public WorkflowDefinition SourceLeft { get; private set; }
        public WorkflowDefinition SourceRight { get; private set; }
        public WorkflowDefinitionRelationship Relationship { get; private set; }
    }
}
