using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataAccessEF.Data;
using DataAccessEF.Repositories;
using Domain.Models;
using DataAccessEF.UnitOfWork;
using Domain.Interfaces;

namespace WebApplicationClient.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       
        private IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
           this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("Get Categorys")]
        public IEnumerable<Category> GetCategorys()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }
        [HttpGet]
        [Route("Get Categorys by Id")]
        public Category GetCategoryById(int id)
        {
            return _unitOfWork.CategoryRepository.GetId(id);
        }
    
    }
}
