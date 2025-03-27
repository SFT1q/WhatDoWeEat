using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDWE.Domain.Response
{
    public class BaseResponse<T> : IBaseReponse<T>
    {
        public string Description { get; set; } = string.Empty;

        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
}
