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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IEnumerable<Standard>> GetAsync()
        {
            Request<Standard> req = Request<Standard>.CreateRequest();
            req.Type = RequestType.GetAll;
            Response<Standard> res = await mediator.Send(req);
            return (IEnumerable<Standard>)res.Entity;
        }

        [HttpGet("{id}")]
        public async Task<Standard> GetAsync(int id)
        {
            Request<Standard> req = Request<Standard>.CreateRequest();
            req.Type = RequestType.Get;
            req.ID = id;
            Response<Standard> res = await mediator.Send(req);
            return (Standard)res.Entity;
        }

        [HttpPost]
        public async Task<OkResult> PostAsync([FromBody] Standard value)
        {
            Request<Standard> req = Request<Standard>.CreateRequest();
            req.Type = RequestType.Add;
            req.Entity = value;
            Response<Standard> res = await mediator.Send(req);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<OkResult> PutAsync(int id, [FromBody] Standard value)
        {
            Request<Standard> req = Request<Standard>.CreateRequest();
            req.Type = RequestType.Update;
            req.ID = id;
            req.Entity = value;
            Response<Standard> res = await mediator.Send(req);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<OkResult> DeleteAsync(int id)
        {
            Request<Standard> req = Request<Standard>.CreateRequest();
            req.Type = RequestType.Delete;
            req.ID = id;
            Response<Standard> res = await mediator.Send(req);
            return Ok();
        }
        #endregion

    }
}
