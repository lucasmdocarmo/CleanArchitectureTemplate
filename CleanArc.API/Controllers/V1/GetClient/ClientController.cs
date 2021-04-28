using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArc.API.Controllers.V1.GetClient
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("V{api-version:apiVersion}/[controller]")]
    public class ClientController : ControllerBase
    {
    }
}
