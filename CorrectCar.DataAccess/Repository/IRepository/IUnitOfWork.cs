using CorrectCar.DataAccess.Repository.IRepository;

namespace CorrectCar.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }

       IImageURLRepository ImageURL { get; }

        public void Save();
    }
}
