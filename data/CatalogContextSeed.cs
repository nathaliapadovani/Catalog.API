using System;
using Catalog.API.Entities; // Referencia a entidade Product
using MongoDB.Driver; // Referencia ao pacote MongoDB.Driver
using System.Linq; // Referencia ao LINQ para manipulação de dados

namespace Catalog.API.Data
{
    // Popular a coleção de produtos no MongoDB com dados iniciais caso a coleção esteja vazia. 
    public class CatalogContextSeed
    {
        // Método para popular a coleção de produtos
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            // Verifica se a coleção de produtos está vazia
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                // Se a coleção estiver vazia, insere os produtos iniciais
                productCollection.InsertManyAsync(GetMyProducts());
            }
        }

        // Declara um método estático privado que retorna uma coleção de objetos da classe
        // Product.
        private static IEnumerable<Product> GetMyProducts()
        {
            // Cria uma lista de produtos com dados iniciais
            return new List<Product>()
            {
                // Cria um novo objeto da classe Product com os dados do produto
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Iphone X",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vitae euismod elit. Cras rhoncus blandit tincidunt. Suspendisse volutpat mauris ex, bibendum pretium eros posuere vel. Aliquam sit amet auctor nibh, sit amet ultricies ante. Duis facilisis, mi eu tincidunt ullamcorper, mi purus varius leo, quis cursus nibh ex in leo. Integer vestibulum enim at ultrices tincidunt. Proin et laoreet quam.",
                    Image = "product-1.png",
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Iphone X",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vitae euismod elit. Cras rhoncus blandit tincidunt. Suspendisse volutpat mauris ex, bibendum pretium eros posuere vel. Aliquam sit amet auctor nibh, sit amet ultricies ante. Duis facilisis, mi eu tincidunt ullamcorper, mi purus varius leo, quis cursus nibh ex in leo. Integer vestibulum enim at ultrices tincidunt. Proin et laoreet quam.",
                    Image = "product-1.png",
                    Category = "Smart Phone"
                }
            };
        }
    }
}


