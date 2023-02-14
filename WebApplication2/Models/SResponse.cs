using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApplication2.Models
{
     public class SResponse : ControllerBase
    {
        public ActionResult<ApiResponse> response(ApiResponse res)
        {
            if (res.statusCode == HttpStatusCode.OK)
                return Ok(res);
            if (res.statusCode == HttpStatusCode.NotFound)
                return NotFound(res);
            return BadRequest(res);
        }
    }
}
