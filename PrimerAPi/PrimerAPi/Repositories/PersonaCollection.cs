using MongoDB.Bson;
using MongoDB.Driver;
using PrimerAPi.Models;

namespace PrimerAPi.Repositories
{
    public class PersonaCollection : IPersonaCollection
    {

        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<persona> Collection;

        public PersonaCollection()
        {
            Collection = _repository.db.GetCollection<persona>("persona");
        }


        public async Task DeletePersona(string id)
        {
            var filter = Builders<persona>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<persona>> GetAllPersonas()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<persona> GetPersonaById(string id)
        {
            var filter = Builders<persona>.Filter.Eq(s => s.Id, new ObjectId(id));
           return await Collection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public async Task InsertPersona(persona persona)
        {
            await Collection.InsertOneAsync(persona);
        }

        public async Task UpdatePersona(persona persona)
        {
            var filter = Builders<persona>.Filter.Eq(s => s.Id, (persona.Id));

            await Collection.ReplaceOneAsync(filter, persona);
        }
    }
}
