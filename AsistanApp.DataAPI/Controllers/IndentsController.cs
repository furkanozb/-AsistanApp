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
    public class IndentsController : ControllerBase
    {
        private IRepository<Indent> _indentRepository;
        private readonly IUnitOfWork _indentUnitOfWork;
        private AsistanAppDbContext _dbContext;

        public IndentsController(AsistanAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _indentUnitOfWork = new UnitOfWork(_dbContext);
            _indentRepository = _indentUnitOfWork.GetRepository<Indent>();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _indentRepository.GetAll());
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Indent indent)
        {
            var result = string.Empty;
            try
            {
                await _indentRepository.Add(indent);
                return Ok(indent);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(Indent indent)
        {
            var result = string.Empty;
            try
            {
                _indentRepository.Update(indent);
                return Ok(indent);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }

        }

        [HttpDelete("delete")]
        public IActionResult Delete(Indent indent)
        {
            var result = string.Empty;
            try
            {
                _indentRepository.Delete(indent);
                return Ok(indent);
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
                var value = _indentRepository.Get(x => x.Id == payment.Id);
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
