using System;
using MongoDB.Driver; // Referencia ao pacote MongoDB.Driver
using Catalog.API.Entities; // Referencia a entidade Product

namespace Catalog.API.Data
{
    // Implementação da interface ICatalogContext e é responsável por configurar a conexão com 
    // o MongoDB e acessar a coleção de produtos. 
    public class CatalogContext : ICatalogContext
    {
        // Construtor que recebe a configuração e inicializa a conexão com o MongoDB
        public CatalogContext(IConfiguration configuration)
        {
            // Cria uma instância do cliente MongoDB usando a string de conexão fornecida na
            // configuração
            var client = new MongoClient(configuration.GetValue<string>
                ("DatabaseSettings:ConnectionString"));

            // Obtém o banco de dados usando o nome do banco de dados fornecido na configuração
            var database = client.GetDatabase(configuration.GetValue<string>
                ("DatabaseSettings:DatabaseName"));

            // Obtém a coleção de produtos usando o nome da coleção fornecido na configuração
            Products = database.GetCollection<Product>(configuration.GetValue<string>
                ("DatabaseSettings:CollectionName"));

            // Chama o método para popular a coleção com dados iniciais
            CatalogContextSeed.SeedData(Products);
        }

        // Propriedade que representa a coleção de produtos no MongoDB
        public IMongoCollection<Product> Products { get; }
    }
}
