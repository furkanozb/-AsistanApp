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
    public class BlokFloorsController : ControllerBase
    {
        private IRepository<BlokFloor> _blokfloorRepository;
        private readonly IUnitOfWork _blokfloorUnitOfWork;
        private AsistanAppDbContext _dbContext;

        public BlokFloorsController(AsistanAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _blokfloorUnitOfWork = new UnitOfWork(_dbContext);
            _blokfloorRepository = _blokfloorUnitOfWork.GetRepository<BlokFloor>();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _blokfloorRepository.GetAll());
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(BlokFloor blokFloor)
        {
            var result = string.Empty;
            try
            {
                await _blokfloorRepository.Add(blokFloor);
                return Ok(blokFloor);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(BlokFloor blokFloor)
        {
            var result = string.Empty;
            try
            {
                _blokfloorRepository.Update(blokFloor);
                return Ok(blokFloor);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }

        }

        [HttpDelete("delete")]
        public IActionResult Delete(BlokFloor blokFloor)
        {
            var result = string.Empty;
            try
            {
                _blokfloorRepository.Delete(blokFloor);
                return Ok(blokFloor);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpDelete("getById")]
        public IActionResult GetById(BlokFloor blokFloor)
        {
            var result = string.Empty;
            try
            {
                var value = _blokfloorRepository.Get(x => x.Id == blokFloor.Id);
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
