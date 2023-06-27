using EMartProject.Models;

namespace EMartProject.Repository
{
    public interface IProductRepository
    {
        bool AddProduct(Product product);
        void deleteByI(int id);
        List<Product> GetAllProducts();
        Product GetByID(int id);
        void Update(Product product);
    }
}
