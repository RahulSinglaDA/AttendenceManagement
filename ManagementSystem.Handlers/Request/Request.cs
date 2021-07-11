using ManagementSystem.Models.Enums;
using ManagementSystem.Handlers.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Handlers.Request
{
    public class Request<T> : IRequest<Response<T>>
    {
        public RequestType Type { get; set; }
        public int ID { get; set; }
        public T Entity { get; set; }
        public static Request<T> CreateRequest()
        {
            return new Request<T>();
        }
    }
}
