using MongoDB.Driver;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.App_Start
{
    public class MongoContext
    {//start class
        // MongoClient is used for connect to server 
        public MongoClient client;
        // IMongoDatabase interface is used for database transactions
        public IMongoDatabase database;

        public MongoContext()
        {
            
            client = new MongoClient(ConfigurationManager.AppSettings["MongoDBHost"]);

            database = client.GetDatabase(ConfigurationManager.AppSettings["MongoDatabaseName"]);
        }




    }//end class
}