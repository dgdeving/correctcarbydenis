using CorrectCar.Models;
using CorrectCar.Models.ViewModels;
using CorrectCar.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CorrectCar.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _unitOfWork.Product.GetAll();
            return View(objProductList);
        }
        //GET
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Product = new(),
                ImagesList = new()
            };

            if (id == null || id == 0)
            {
                //create product
                //ViewBag.TargetList = TargetList;
                //ViewData["TargetTypeList"] = TargetTypeList;
                return View(productVM);
            }
            else
            {
                //update product
                productVM.Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
                productVM.ImagesList = _unitOfWork.ImageURL.GetAll(u => u.ProductId == id).ToList();
                return View(productVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM obj, IFormFile?[] files)
        {
           

            // custom server side validation 
            //if(obj.Name == "male")
            //{
            //    ModelState.AddModelError("Name", "name must be different from male");
            //}
            //server side validation
            if (ModelState.IsValid)
            {
                if (obj.Product.Id != 0)
                {
                    _unitOfWork.Product.Update(obj.Product);
                    _unitOfWork.Save();
                    TempData["Success"] = "Product updated successfully";
                }
                else
                {
                    _unitOfWork.Product.Add(obj.Product);
                    _unitOfWork.Save();
                    TempData["Success"] = "Product created successfully";
                }

                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (files.Length > 0)
                {
                    if (obj.ImagesList != null)
                    {
                        foreach (ImageURL image in obj.ImagesList)
                        {
                            var oldImagePath = Path.Combine(wwwRootPath, image.ImageUrl.TrimStart('\\'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                             
                        }
                        _unitOfWork.ImageURL.RemoveRange(obj.ImagesList);
                    }

                    foreach (IFormFile file in files)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(wwwRootPath, @"images\products");
                        var extension = Path.GetExtension(file.FileName);

                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                        {
                            file.CopyTo(fileStreams);
                        }
                        ImageURL imageURL = new ImageURL()
                        {
                            ProductId = obj.Product.Id,
                            ImageUrl = @"\images\products\" + fileName + extension
                        };
                        _unitOfWork.ImageURL.Add(imageURL);

                        //updating the product ListImageUrl to the first picture in files
                        if (files[0]==file)
                        {
                            obj.Product.ListImageUrl = imageURL.ImageUrl;
                            _unitOfWork.Product.Update(obj.Product);
                        }
                    }
                    _unitOfWork.Save();
                }

                return RedirectToAction("Index", "Product");
            }

            return View(obj);

        }


        //Post
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productFromDb = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id);
            List<ImageURL> imagesURLFromDb = _unitOfWork.ImageURL.GetAll(x => x.ProductId == id).ToList();
            if (productFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Product.Remove(productFromDb);
            _unitOfWork.Save();

            string wwwRootPath = _hostEnvironment.WebRootPath;
            foreach(ImageURL image in imagesURLFromDb)
            {
                var imagePath = Path.Combine(wwwRootPath, image.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            return Json(new { success = true, message = "Delete successful" });
        }

    }
}
