using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace WorkFlow
{
    public class WorkflowDirector : TypedActor, IHandle<WorkflowResponse>, IHandle<WorkflowDefinition>
    {
        private IList<Field> _fields;
        private Guid _key;
        private String _name;
        private IWorkflowDefinition _sourceLeft;
        private IWorkflowDefinition _sourceRight;
        private WorkFlowActorType _actorType;
        private List<Guid> _keys;
        private Int32 _keyCount = 0;
        private List<WorkflowResponse> _responses;

        public WorkflowDirector()
        {
            _keys = new List<Guid>();
            _responses = new List<WorkflowResponse>();
        }
        
        public void Handle(WorkflowResponse message)
        {
            //Final response... just deal with it (like persist to mongo)
            //needs keys and key count and response.
            //NOTE: This is turning out to be a workflowprojectionactor.
            if (_keys.Any(k => k == message.Key)) 
            { 
                _keyCount++;
                _responses.Add(message);
            }

            if (_keyCount == _keys.Count) { 
                var firstMessageData = _responses.First();
                var secondMessageData = _responses.Skip(1).First();

                foreach (var item in secondMessageData.Data)
                { 
                    Console.WriteLine(item["FirstName"]);
                }

                foreach (var item in firstMessageData.Data)
                {
                    Console.WriteLine(item["Salary"]);
                }
            }


        }

        public void Handle(WorkflowDefinition definition)
        {
            _key = definition.Key;
            _fields = definition.Fields;
            _name = definition.Name;
            _sourceLeft = definition.SourceLeft;
            _sourceRight = definition.SourceRight;
            _actorType = definition.ActorType;
            var actorLeft = WorkflowActorFactory.Create(_sourceLeft.ActorType, _sourceLeft.Name);
            var actorRight = WorkflowActorFactory.Create(_sourceRight.ActorType, _sourceRight.Name);

            _keys.Add(_sourceLeft.Key);
            _keys.Add(_sourceRight.Key);

            actorLeft.Tell(_sourceLeft);
            actorRight.Tell(_sourceRight);
        }
    }
}
