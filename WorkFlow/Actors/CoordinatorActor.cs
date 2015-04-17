using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Actors.Interfaces;

namespace WorkFlow.Actors
{
    public class CoordinatorActor : TypedActor, IWorkflowDefinitionActor, IWorkflowResponseActor
    {
        private List<Guid> _wfpKeys;
        private Int32 receivedKeyCount = 0;
        private List<WorkflowResponse> _responses;
        private IActorRef _parent;
        private WorkflowDefinition _wfDefinition;

        public CoordinatorActor()
        {
            _wfpKeys = new List<Guid>();
            _responses = new List<WorkflowResponse>();
        }

        /// <summary>
        /// Starts the projection
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Handle(IWorkflowDefinition message)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles the Response and persists to DB
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Handle(WorkflowResponse message)
        {
            throw new NotImplementedException();
        }

    }
}
