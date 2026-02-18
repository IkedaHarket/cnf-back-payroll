using System.Collections.Generic;

namespace Backend.Payroll.API.Application.DTO.Response
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
