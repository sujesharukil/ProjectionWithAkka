using Akka.Actor;
using Data;
using DataSourceDefinition;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow
{
    public class DataSourceWorkflowActor : TypedActor, IWorkflowDefinitionActor
    {
        private IContext _context;

        public DataSourceWorkflowActor()
        {
            var connString = System.Configuration.ConfigurationManager.AppSettings.Get("mongo.connectionString");
            _context = new MongoContext(connString);
        }


        public void Handle(IWorkflowDefinition message)
        {
            //grab the data from Mongo
            //message.Key mongo collection name Collection of DataSource
            var datasources = _context.GetTableFor<DataSource>(message.Name);
            var thisResponse = new WorkflowResponse();
            thisResponse.Key = message.Key;
            thisResponse.Name = message.Name;

            List<dynamic> data = new List<dynamic>();

            foreach (var dataSource in datasources)
            {
                IDictionary<String, Object> thisRecord = new ExpandoObject();
                var fields = dataSource.Fields.Keys;
                foreach (var key in fields)
                {
                    thisRecord[key] = dataSource.Fields[key];
                }

                data.Add(thisRecord);
            }

            thisResponse.Data = data.AsReadOnly();

            Sender.Tell(thisResponse);
        }
    }
}
