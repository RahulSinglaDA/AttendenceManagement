using ManagementSystem.Models.Enums;
using ManagementSystem.Models.Models;
using ManagementSystem.Handlers.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementSystem.Helpers;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardController : ControllerBase
    {
        #region
        private readonly IMediator mediator;
        #endregion

        #region "ctor"
        public StandardController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        #endregion

        #region "Requests"
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Standard>>> GetAsync()
        {
            Response<Standard> res = await Helper<Standard>.SendRequestAsync(mediator, RequestType.GetAll, null);
            if (res != null)
                return ((IEnumerable<Standard>)res.Entity).ToList();
            else
                return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<Standard> GetAsync(int id)
        {
            Response<Standard> res = await Helper<Standard>.SendRequestAsync(mediator, RequestType.Get, null, id);
            return (Standard)res.Entity;
        }

        [HttpPost]
        public async Task<OkResult> PostAsync([FromBody] Standard value)
        {
            Response<Standard> res = await Helper<Standard>.SendRequestAsync(mediator, RequestType.Add, value);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<OkResult> PutAsync(int id, [FromBody] Standard value)
        {
            Response<Standard> res = await Helper<Standard>.SendRequestAsync(mediator, RequestType.Update, value, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<OkResult> DeleteAsync(int id)
        {
            Response<Standard> res = await Helper<Standard>.SendRequestAsync(mediator, RequestType.Delete, null, id);
            return Ok();
        }
        #endregion

    }
}
