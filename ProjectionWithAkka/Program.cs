using Akka.Actor;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using WorkFlow;

namespace ProjectionWithAkka
{
    class Program
    {
        static void Main(string[] args)
        {
            Project();
            Console.ReadLine();
        }

        private static void Project()
        {
            var connString = System.Configuration.ConfigurationManager.AppSettings.Get("mongo.connectionString");
            IContext context = new MongoContext(connString);
            var workflows = context.GetTableFor<WorkflowDefinition>("Workflows");
            var workflow = workflows.FirstOrDefault();
            ActorSystem _system = ActorSystem.Create("WorkflowProjectionSystem");
            var director = _system.ActorOf<WorkflowDirector>("Director");

            director.Tell(workflow);
        }
    }
}
