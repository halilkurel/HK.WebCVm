using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ResponseObject
{
    public class Response<T> : Response, IResponse<T>
    {
        public T Data { get; set; }
        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }

        public Response(ResponseType responseType, string message) : base(responseType, message)
        {
        }

        public Response(ResponseType responseType, T data, List<CustomValidationError> errors) : base(responseType)
        {
            validatorErrors = errors;
            Data = data;
        }

        public List<CustomValidationError> validatorErrors { get; set; }
    }
}
