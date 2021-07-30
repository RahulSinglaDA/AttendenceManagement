using ManagementSystem.Models.Enums;
using ManagementSystem.Models.Models;
using ManagementSystem.Handlers.Request;
using ManagementSystem.Handlers.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementSystem.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        #region
        private readonly IMediator mediator;
        #endregion

        #region "ctor"
        public StudentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        #endregion

        #region "Requests"
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAsync()
        {
            Response<Student> res = await Helper<Student>.SendRequestAsync(mediator, RequestType.GetAll, null);
            if (res != null)
                return ((IEnumerable<Student>)res.Entity).ToList();
            else
                return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<Student> GetAsync(int id)
        {
            Response<Student> res = await Helper<Student>.SendRequestAsync(mediator, RequestType.Get, null, id);
            return (Student)res.Entity;
        }

        [HttpPost]
        public async Task<OkResult> PostAsync([FromBody] Student value)
        {
            Response<Student> res = await Helper<Student>.SendRequestAsync(mediator, RequestType.Add, value);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<OkResult> PutAsync(int id, [FromBody] Student value)
        {
            Response<Student> res = await Helper<Student>.SendRequestAsync(mediator, RequestType.Update, value, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<OkResult> DeleteAsync(int id)
        {
            Response<Student> res = await Helper<Student>.SendRequestAsync(mediator, RequestType.Delete, null, id);
            return Ok();
        }
        #endregion

    }
}
