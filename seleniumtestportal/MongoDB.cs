using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumtestportal
{
    static class MongoDB
    {
        private static IMongoClient client;
        private static IMongoDatabase database;
        


        public static bool initializeDatabase()
        {
            try
            {
                client = new MongoClient("/* deleted for security reasons */");
                database = client.GetDatabase("/* deleted for security reasons */");
                database.GetCollection<BsonDocument>("/* deleted for security reasons */").Find(new BsonDocument() { });
                // MongoDb throw exception if internet connection breaks
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't connect");
                return false;
            }
            return true;
           
        }

        public static bool validateActivationCode(string code) //getCode
        {
            try
            {
                var collection = database.GetCollection<BsonDocument>("collection2138");
                var filter = Builders<BsonDocument>.Filter.Eq("code", code);
                BsonDocument doc = collection.Find(filter).FirstOrDefault();
                if (doc != null)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                    return false;
            }
        }
        public static bool validateHwid(string hwid) //TODO: need refactoring 
        {
          
            var collection = database.GetCollection<BsonDocument>("/* deleted for security reasons */");
            var filter = Builders<BsonDocument>.Filter.Eq("hwid", hwid);

            List<BsonDocument> documents = collection.Find(filter).ToList();

            if(documents.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static void insertHwid(string fingerprint) 
        {

        }
    }
}
