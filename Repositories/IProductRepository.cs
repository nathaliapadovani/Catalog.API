using Catalog.API.Entities;


// Interface com a lógica de acesso a dados
namespace Catalog.API.Repositories
{
    // Contrato, especificando os métodos que qualquer classe que implemente
    // IProductRepository deve fornecer
    public interface IProductRepository
    {
        // Método assíncrono (Task) para obter todos os produtos
        Task<IEnumerable<Product>> GetProducts();

        // Método assíncrono (Task) para obter um produto pelo Id
        Task<Product> GetProduct(string id);

        // Método assíncrono (Task) para obter um produto pelo nome
        Task<IEnumerable<Product>> GetProductByName(string name);

        // Método assíncrono (Task) para obter um produto pela categoria
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);

        // Inserir um novo produto na coleção do banco de dados.
        Task CreateProduct(Product product);

        // Atualizar um produto existente na coleção do banco de dados.
        Task<bool> UpdateProduct(Product product);

        // Deletar um produto existente na coleção do banco de dados.
        Task<bool> DeleteProduct(string id);
    }
}
