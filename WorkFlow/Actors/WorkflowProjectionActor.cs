using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Actors.Interfaces;

namespace WorkFlow
{
    public class WorkflowProjectionActor: TypedActor, IWorkflowDefinitionActor, IWorkflowResponseActor
    {
        private List<Guid> _wfpKeys;
        private Int32 receivedKeyCount = 0;
        private List<WorkflowResponse> responses;
        private IActorRef _parent;

        public WorkflowProjectionActor()
        {
            _wfpKeys = new List<Guid>();
            responses = new List<WorkflowResponse>();
        }

        public void Handle(IWorkflowDefinition message)
        {
            _parent = Sender;

            IActorRef actorLeft = null;
            IActorRef actorRight = null;

            if (message.SourceLeft != null) {
                _wfpKeys.Add(message.SourceLeft.Key);
                actorLeft = WorkflowActorFactory.Create(message.SourceLeft.ActorType, message.SourceLeft.Name);
            }

            if (message.SourceRight != null) {
                _wfpKeys.Add(message.SourceRight.Key);
                actorRight = WorkflowActorFactory.Create(message.SourceRight.ActorType, message.SourceRight.Name);
            }

            if (actorRight != null) { 
                actorRight.Tell(message.SourceRight);
            }

            if (actorLeft != null) { 
                actorLeft.Tell(message.SourceLeft);
            }
        }

        public void Handle(WorkflowResponse message)
        {
            if(_wfpKeys.Any( (k) => k == message.Key))
            {
                receivedKeyCount++;
                responses.Add(message);
            }

            if (receivedKeyCount == _wfpKeys.Count) { 
                //TODO: This is where we do our join
                var respondWith = new WorkflowResponse();

                _parent.Tell(respondWith);
            }
        }
    }
}
