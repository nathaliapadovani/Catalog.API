using System;
using MongoDB.Driver; // Referencia ao pacote MongoDB.Driver
using Catalog.API.Entities; // Referencia a entidade Product

namespace Catalog.API.Data
{
    // Interface que define o contexto para acessar a coleção de produtos no MongoDB
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}

