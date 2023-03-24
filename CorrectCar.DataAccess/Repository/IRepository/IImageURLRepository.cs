using CorrectCar.Models;
using CorrectCar.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectCar.DataAccess.Repository.IRepository
{
    public interface IImageURLRepository : IRepository<ImageURL>
    {
        void Update(ImageURL imageURL);
    }
}
