using AsistanApp.Domain.Interfaces;
using AsistanApp.Domain.Models;
using AsistanApp.Infrastructure;
using AsistanApp.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsistanApp.DataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private IRepository<Payment> _paymentRepository;
        private readonly IUnitOfWork _paymentUnitOfWork;
        private AsistanAppDbContext _dbContext;

        public PaymentsController(AsistanAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _paymentUnitOfWork = new UnitOfWork(_dbContext);
            _paymentRepository = _paymentUnitOfWork.GetRepository<Payment>();
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _paymentRepository.GetAll());
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Payment payment)
        {
            var result = string.Empty;
            try
            {
                await _paymentRepository.Add(payment);
                return Ok(payment);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(Payment payment)
        {
            var result = string.Empty;
            try
            {
                _paymentRepository.Update(payment);
                return Ok(payment);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }

        }

        [HttpDelete("delete")]
        public IActionResult Delete(Payment payment)
        {
            var result = string.Empty;
            try
            {
                _paymentRepository.Delete(payment);
                return Ok(payment);
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
                var value=_paymentRepository.Get(x=>x.Id==payment.Id);
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
