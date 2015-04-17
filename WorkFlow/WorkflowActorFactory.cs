using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow
{
    public static class WorkflowActorFactory
    {
        private static ActorSystem _system = ActorSystem.Create("WorkflowProjectionSystem");

        public static IActorRef Create(WorkFlowActorType actorType, String name ="")
        {
            IActorRef thisActor;
            if (actorType == WorkFlowActorType.DataSource)
            {
                thisActor = _system.ActorOf<DataSourceWorkflowActor>(name);
            }
            else
            {
                thisActor = _system.ActorOf<WorkflowProjectionActor>(name);
            }

            return thisActor;
        }
    }
}
