using PrimerAPi.Models;

namespace PrimerAPi.Repositories
{
    public interface IPersonaCollection
    {

        Task InsertPersona(persona persona);
        Task UpdatePersona(persona persona);
        Task DeletePersona(string id);

        Task<List<persona>> GetAllPersonas();
        Task<persona> GetPersonaById(string id);


    }
}
