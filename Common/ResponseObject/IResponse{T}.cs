using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ResponseObject
{
    public interface IResponse<T>
    {
        T Data { get; set; }
        List<CustomValidationError> validatorErrors { get; set; }
        ResponseType ResponseType { get; }
    }
}
