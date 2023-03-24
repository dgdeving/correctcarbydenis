using CorrectCar.DataAccess;
using CorrectCar.Models;
using CorrectCar.Repository.IRepository;

namespace CorrectCar.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public IEnumerable<Product> GetAllByCategoryId(int id)
        //{
        //    return _db.Products.Where(x => x.CategoryId == id).ToList();
        //}

        public void Update(Product obj)
        {
            //this updates all the properties even if they are not updated
            //_db.Categories.Update(category);

            var objFromDb = _db.Products.FirstOrDefault(c => c.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Marca = obj.Marca;
                objFromDb.Model = obj.Model;
                objFromDb.Descriere = obj.Descriere;
                objFromDb.Pret = obj.Pret;
                objFromDb.CapacitateMotor = obj.CapacitateMotor;
                objFromDb.Rulaj = obj.Rulaj;
                objFromDb.Putere = obj.Putere;
                objFromDb.Culoare = obj.Culoare;
                objFromDb.CutieViteze = obj.CutieViteze;
                objFromDb.Caroserie = obj.Caroserie;
                objFromDb.Combustibil = obj.Combustibil;

            }
        }
    }
}
