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
    public class BloksController : ControllerBase
    {
        private IRepository<Blok> _blokRepository;
        private readonly IUnitOfWork _blokUnitOfWork;
        private AsistanAppDbContext _dbContext;

        public BloksController(AsistanAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _blokUnitOfWork = new UnitOfWork(_dbContext);
            _blokRepository = _blokUnitOfWork.GetRepository<Blok>();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _blokRepository.GetAll());
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Blok blok)
        {
            var result = string.Empty;
            try
            {
                await _blokRepository.Add(blok);
                return Ok(blok);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(Blok blok)
        {
            var result = string.Empty;
            try
            {
                _blokRepository.Update(blok);
                return Ok(blok);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }

        }

        [HttpDelete("delete")]
        public IActionResult Delete(Blok blok)
        {
            var result = string.Empty;
            try
            {
                _blokRepository.Delete(blok);
                return Ok(blok);
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
                var value = _blokRepository.Get(x => x.Id == payment.Id);
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
