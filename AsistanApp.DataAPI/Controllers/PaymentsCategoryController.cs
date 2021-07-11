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
    public class PaymentsCategoryController : ControllerBase
    {
        private IRepository<PaymentCategory> _modelRepository;
        private readonly IUnitOfWork _ModelUnitOfWork;
        private AsistanAppDbContext _dbContext;
        public PaymentsCategoryController(AsistanAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _ModelUnitOfWork = new UnitOfWork(_dbContext);
            _modelRepository = _ModelUnitOfWork.GetRepository<PaymentCategory>();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _modelRepository.GetAll());
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(PaymentCategory paymentCategory)
        {
            var result = string.Empty;
            try
            {
                await _modelRepository.Add(paymentCategory);
                return Ok(paymentCategory);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(PaymentCategory paymentCategory)
        {
            var result = string.Empty;
            try
            {
                _modelRepository.Update(paymentCategory);
                return Ok(paymentCategory);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }

        }

        [HttpDelete("delete")]
        public IActionResult Delete(PaymentCategory paymentCategory)
        {
            var result = string.Empty;
            try
            {
                _modelRepository.Delete(paymentCategory);
                return Ok(paymentCategory);
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
                var value = _modelRepository.Get(x => x.Id == payment.Id);
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
