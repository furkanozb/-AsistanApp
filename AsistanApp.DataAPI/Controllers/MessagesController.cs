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
    public class MessagesController : ControllerBase
    {
        private IRepository<Message> _messageRepository;
        private readonly IUnitOfWork _messageUnitOfWork;
        private AsistanAppDbContext _dbContext;

        public MessagesController(AsistanAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _messageUnitOfWork = new UnitOfWork(_dbContext);
            _messageRepository = _messageUnitOfWork.GetRepository<Message>();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _messageRepository.GetAll());
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Message message)
        {
            var result = string.Empty;
            try
            {
                await _messageRepository.Add(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(Message message)
        {
            var result = string.Empty;
            try
            {
                _messageRepository.Update(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }

        }

        [HttpDelete("delete")]
        public IActionResult Delete(Message message)
        {
            var result = string.Empty;
            try
            {
                _messageRepository.Delete(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpDelete("getById")]
        public IActionResult GetById(Message message)
        {
            var result = string.Empty;
            try
            {
                var value = _messageRepository.Get(x => x.Id == message.Id);
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
