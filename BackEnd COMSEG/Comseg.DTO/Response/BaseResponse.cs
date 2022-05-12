using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comseg.DTO.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public ICollection<string> ListErrors { get; set; }
        public BaseResponse()
        {
            ListErrors = new List<string>();
        }

    }
    public class BaseResponseLogin<TClass> : BaseResponse
    {
        public TClass? UserResponse { get; set; }
    }
    public class BaseResponsePages<TClass> : BaseResponse
    {
        public TClass? PageResponse { get; set; }
    }

    public class BaseResponseEntity<TClass> : BaseResponse
    {
        public TClass? ResponseResult { get; set; }
    }
}
