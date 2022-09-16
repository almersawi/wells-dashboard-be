using System.Collections.Generic;

namespace API.DTOs
{
    public class ReturnDataListDto<T>
    {
        public List<T> Data { get; set; }
    }
}