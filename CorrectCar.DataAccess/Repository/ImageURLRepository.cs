using CorrectCar.DataAccess.Repository.IRepository;
using CorrectCar.Models;
using CorrectCar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectCar.DataAccess.Repository
{
    public class ImageURLRepository : Repository<ImageURL>, IImageURLRepository
    {
        public readonly ApplicationDbContext _db;
        public ImageURLRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public IEnumerable<Product> GetAllByCategoryId(int id)
        //{
        //    return _db.Products.Where(x => x.CategoryId == id).ToList();
        //}

        public void Update(ImageURL obj)
        {
            //this updates all the properties even if they are not updated
            //_db.Categories.Update(category);

            var objFromDb = _db.Images.FirstOrDefault(c => c.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.ImageUrl = obj.ImageUrl;
                objFromDb.ProductId = obj.ProductId;
               

            }
        }
    }
}
