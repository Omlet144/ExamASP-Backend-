using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataAccessEF.Data;
using DataAccessEF.Repositories;
using Domain.Models;
using DataAccessEF.UnitOfWork;
using Domain.Interfaces;
using WebApplicationClient.Cach;

namespace WebApplicationClient.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       
        private IUnitOfWork _unitOfWork;
        CacheService _cacheService = new CacheService();

        public CategoryController(IUnitOfWork unitOfWork)
        {
           this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetCategorys")]
        public IEnumerable<Category> GetCategorys()
        {
            List<Category> category = _cacheService.GetData<List<Category>>("Gadget");
            if (category == null)
            {
                var categorysSql = _unitOfWork.CategoryRepository.GetAll();
                if (categorysSql.Count() > 0)
                {
                    _cacheService.SetData("Smartphone", categorysSql, DateTimeOffset.Now.AddDays(1));
                    category = categorysSql.ToList();
                }
            }
            return category;
            //return _unitOfWork.CategoryRepository.GetAll();
        }
        [HttpGet]
        [Route("GetCategorysbyId")]
        public Category GetCategoryById(int id)
        {
            Category category = _cacheService.GetData<Category>("Gadget");
            if (category == null)
            {
                var categorysSql = _unitOfWork.CategoryRepository.GetId(id);
                if (categorysSql != null)
                {
                    _cacheService.SetData("Smartphone", categorysSql, DateTimeOffset.Now.AddDays(1));
                    category = categorysSql;
                }
            }
            return category;
            //return _unitOfWork.CategoryRepository.GetId(id);
        }
    
    }
}
