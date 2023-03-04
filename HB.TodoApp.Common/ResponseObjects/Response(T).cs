using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.TodoApp.Common.ResponseObjects
{
    public class Response<T>:Response,IResponse<T>
    {
        public T Data { get; set; }
        public Response(ResponseType type, T data) : base(type)
        {
            Data = data;
        }
        public Response(ResponseType type ,string message):base(type,message)
        {

        }
        public Response(ResponseType type, T data, List<CustomValidationError> errors) : base(type)
        {
            Data = data;
            ValidationErrors = errors;
        }

        public List<CustomValidationError> ValidationErrors { get; set; }
    }
}
