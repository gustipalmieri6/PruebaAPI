﻿using MongoDB.Driver;

namespace PrimerAPi.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient Client;

        public IMongoDatabase db;


        //mongodb+srv://<db_username>:<db_password>@cluster0.amf9k.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0

        public MongoDBRepository()
        {
            Client = new MongoClient("mongodb+srv://Gustavo@admin:Gustavo@cluster0.amf9k.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            db = Client.GetDatabase("PruebaDB");
        }



    
    }
}
