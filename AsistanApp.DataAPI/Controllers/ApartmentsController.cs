using AsistanApp.Domain.Interfaces;
using AsistanApp.Domain.Models;
using AsistanApp.Infrastructure;
using AsistanApp.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsistanApp.DataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private IRepository<Apartment> _apartmentRepository;
        private readonly IUnitOfWork _apartmentUnitOfWork;
        private AsistanAppDbContext _dbContext;
        public ApartmentsController(AsistanAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _apartmentUnitOfWork = new UnitOfWork(_dbContext);
            _apartmentRepository = _apartmentUnitOfWork.GetRepository<Apartment>();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _apartmentRepository.GetAll());
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Apartment apartment)
        {
            var result = string.Empty;
            try
            {
                await _apartmentRepository.Add(apartment);
                return Ok(apartment);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(Apartment apartment)
        {
            var result = string.Empty;
            try
            {
                _apartmentRepository.Update(apartment);
                return Ok(apartment);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }

        }

        [HttpDelete("delete")]
        public IActionResult Delete(Apartment apartment)
        {
            var result = string.Empty;
            try
            {
                _apartmentRepository.Delete(apartment);
                return Ok(apartment);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpDelete("getById")]
        public IActionResult GetById(Payment payment)
        {
            var result = string.Empty;
            try
            {
                var value = _apartmentRepository.Get(x => x.Id == payment.Id);
                return Ok(value);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }
        }
    }
}
