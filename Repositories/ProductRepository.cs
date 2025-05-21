using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

// Lógica de acesso a dados
namespace Catalog.API.Repositories
{
    // Classe que atende ao contrato da interface IProductRepository
    public class ProductRepository : IProductRepository
    {

        // Construtor que recebe o contexto do banco de dados
        private readonly ICatalogContext _context;

        // Construtor que inicializa o contexto do banco de dados, através da 
        // injeção de dependência
        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        //  Insere um novo produto no banco de dados.
        public async Task CreateProduct(Product product)
        {
            // adiciona o produto ao banco de forma assíncrona
            await _context.Products.InsertOneAsync(product);
        }

        // Deleta um produto existente no banco de dados com base no Id
        public async Task<bool> DeleteProduct(string id)
        {
            // Cria um filtro para encontrar o produto pelo Id
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            // Exclui o produto correspondene ao filtro de forma assíncrona
            DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);

            // Verifica se a exclusão foi bem-sucedida e se algum produto foi excluído
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        // Obtém um produto específico do banco de dados com base no Id
        public async Task<Product> GetProduct(string id)
        {
            // Cria um filtro para encontrar o produto pelo Id
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        // Obtém todos os produtos do banco de dados com base na categoria
        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            // Cria um filtro para encontrar produtos pela categoria
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);

            // Retorna todos os produtos que correspondem ao filtro de forma assíncrona
            return await _context.Products.Find(filter).ToListAsync();
        }

        // Obtém todos os produtos do banco de dados com base no nome
        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            // Cria um filtro para encontrar produtos pelo nome
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);

            // Retorna todos os produtos que correspondem ao filtro de forma assíncrona
            return await _context.Products.Find(filter).ToListAsync();
        }

        // Obtém todos os produtos do banco de dados
        public async Task<IEnumerable<Product>> GetProducts()
        {
            // Retorna todos
            return await _context.Products.Find(p => true).ToListAsync();
        }

        // Atualiza um produto existente no banco de dados com base no Id
        public async Task<bool> UpdateProduct(Product product)
        {
            // Cria um filtro para encontrar o produto pelo Id
            var updateResult = await _context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            // Verifica se a atualização foi bem-sucedida e se algum produto foi modificado
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
