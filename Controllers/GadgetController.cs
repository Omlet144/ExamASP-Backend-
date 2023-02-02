using DataAccessEF.Data;
using DataAccessEF.Repositories;
using DataAccessEF.UnitOfWork;
using Domain.Interfaces;
using Domain.Models;
using Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationClient.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class GadgetController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public GadgetController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        ///POST

        [HttpPost]
        [Route("Add Gadget")]
        [Authorize(Roles = UserRoles.Manager)]
        public IResult Add([FromBody]Gadget gadget)
        {
            try
            {
                _unitOfWork.GadgetRepository.Create(gadget);
                return Results.StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return Results.StatusCode(StatusCodes.Status400BadRequest);
            }
            return Results.StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        [Route("Update Gadget by Id")]
        [Authorize(Roles = UserRoles.Manager)]
        public IResult Update([FromBody]Gadget gadget)
        {
            try
            {
                _unitOfWork.GadgetRepository.Update(gadget);
                return Results.StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return Results.StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        [Route("Remove Gadget by Id")]
        [Authorize(Roles = UserRoles.Manager)]
        public IResult RemoveById([FromBody]int id)
        {
            try
            {
                _unitOfWork.GadgetRepository.Delete(id);
                return Results.StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return Results.StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        ///GET

        [HttpGet]
        [Route("Get Gadgets")]
        public IEnumerable<Gadget> GetGadgets()
        {
            return _unitOfWork.GadgetRepository.GetAll();
        }

        [HttpGet]
        [Route("Get Gadget by Id")]
        public Gadget GetGadgetById(int id)
        {
            return _unitOfWork.GadgetRepository.GetId(id);
        }

        [HttpGet]
        [Route("Get Gadget by Id_Category")]
        public IEnumerable<Gadget> GetGadgetByIdCategory(int id)
        {
            return _unitOfWork.GadgetRepository.GetbyIdCategory(id);
        }
    }
}