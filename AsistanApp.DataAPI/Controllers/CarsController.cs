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
    public class CarsController : ControllerBase
    {
        private IRepository<Car> _carRepository;
        private readonly IUnitOfWork _carUnitOfWork;
        private AsistanAppDbContext _dbContext;

        public CarsController(AsistanAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _carRepository.GetAll());
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Car car)
        {
            var result = string.Empty;
            try
            {
                await _carRepository.Add(car);
                return Ok(car);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = string.Empty;
            try
            {
                _carRepository.Update(car);
                return Ok(car);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }

        }

        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            var result = string.Empty;
            try
            {
                _carRepository.Delete(car);
                return Ok(car);
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
                var value = _carRepository.Get(x => x.Id == payment.Id);
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
