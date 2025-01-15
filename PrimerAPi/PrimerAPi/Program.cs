using MongoDB.Driver;
using PrimerAPi.Models;
using PrimerAPi.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services.AddControllers();
//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var mongoSettings = builder.Configuration.GetSection("PersonaSetting").Get<MongoDBRepository>();
builder.Services.AddSingleton(mongoSettings);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient());

builder.Services.AddScoped<IPersonaCollection, PersonaCollection>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
//using MongoDB.Driver;
//using System;
//using PrimerAPi.Models;  // Ajusta el namespace a donde está tu clase Persona

//namespace TuProyecto
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // 1) Cadena de conexión a MongoDB 
//            string connectionString = "mongodb://localhost:27017";

//            // 2) Crear el cliente de Mongo
//            var client = new MongoClient(connectionString);

//            // 3) Obtener la base de datos
//            var database = client.GetDatabase("PruebaDB");

//            // 4) Obtener la colección
//            var coleccion = database.GetCollection<persona>("persona");

//            // 5) Crear e insertar un nuevo documento
//            var nuevaPersona = new persona
//            {
//                nombre = "Lionel",
//                apellido = "Mess",
//                edad = 40
//            };
//            coleccion.InsertOne(nuevaPersona);

//            Console.WriteLine("Documento insertado correctamente.");

//            // 6) Consultar documentos
//            var personas = coleccion.Find(_ => true).ToList();
//            foreach (var p in personas)
//            {
//                Console.WriteLine($"ID: {p.Id}, Nombre: {p.nombre}, Apellido: {p.apellido}, Edad: {p.edad}");
//            }

//            Console.ReadLine();
//        }
//    }
//}