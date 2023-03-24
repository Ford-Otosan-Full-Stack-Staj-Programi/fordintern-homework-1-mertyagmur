using FordInternHW1.Data;
using FordInternHW1.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FordInternHW1.Web.Controllers
{
    [Route("ford/api/v1.0/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public StaffController(IUnitOfWork unitOfWork) 
        { 
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public List<Staff> GetAll()
        {
            List<Staff> staffList = unitOfWork.StaffRepository.GetAll();
            return staffList;
        }

        [HttpGet("{id}")]
        public Staff GetById(int id)
        {
            Staff staffList = unitOfWork.StaffRepository.GetById(id);
            return staffList;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Staff request)
        {
            request.Id = id;
            unitOfWork.StaffRepository.Put(request);
            unitOfWork.Complete();
        }

        [HttpPost]
        public void Post([FromBody] Staff request)
        {
            unitOfWork.StaffRepository.Post(request);
            unitOfWork.Complete();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.StaffRepository.Delete(id);
            unitOfWork.Complete();
        }

        [HttpGet("GetByFilter")]
        public List<Staff> GetByFilter([FromQuery] int yearsOld, string country)
        {
            List<Staff> filteredStaffList =  unitOfWork.StaffRepository.GetAll()
                .Where(s => s.Country == country
                && (DateTime.Today.Year - s.DateOfBirth.Year) < yearsOld)
                .ToList();
            return filteredStaffList;
        }
    }
}
