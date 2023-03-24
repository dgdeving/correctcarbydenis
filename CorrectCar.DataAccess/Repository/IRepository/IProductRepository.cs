using CorrectCar.Models;

namespace CorrectCar.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);

        //IEnumerable<Product> GetAllByCategoryId(int id);


    }
}
