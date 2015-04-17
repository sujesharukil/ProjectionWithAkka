using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow
{
    public interface IWorkflowDefinition
    {
        Guid Id { get;}
        Guid Key { get;}
        String Name { get;}
        WorkFlowActorType ActorType { get; }
        List<Field> Fields { get;}
        WorkflowDefinition SourceLeft { get;}
        WorkflowDefinition SourceRight { get;}
        WorkflowDefinitionRelationship Relationship { get;}
    }
}
