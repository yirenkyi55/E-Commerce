using System.Collections.Generic;

namespace API.Error
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(422)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}