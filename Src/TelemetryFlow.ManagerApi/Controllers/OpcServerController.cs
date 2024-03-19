using Microsoft.AspNetCore.Mvc;
using TelemetryFlow.ManagerApi.Requests;
using TelemetryFlow.ManagerApi.Responses;

namespace TelemetryFlow.ManagerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OpcServerController : Controller
{
    [HttpGet("{id}")]
    public OpcServerResponse Get(Guid id)
    {
        throw new ArgumentNullException(nameof(id));
        return new OpcServerResponse();
    }

    [HttpPost]
    public OpcServerResponse Post([FromBody]CreateOpcServerRequest request)
    {
        return new OpcServerResponse();
    }
}