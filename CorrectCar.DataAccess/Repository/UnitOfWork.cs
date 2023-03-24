using CorrectCar.DataAccess;
using CorrectCar.DataAccess.Repository;
using CorrectCar.DataAccess.Repository.IRepository;
using CorrectCar.Repository.IRepository;

namespace CorrectCar.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            Product = new ProductRepository(_db);
            ImageURL = new ImageURLRepository(_db);

        }

        public IProductRepository Product { get; private set; }

        public IImageURLRepository ImageURL { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
