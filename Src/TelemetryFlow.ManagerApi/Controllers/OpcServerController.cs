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
        //throw new ArgumentNullException(nameof(id));
        return new OpcServerResponse();
    }

    [HttpPost]
    public OpcServerResponse Post([FromBody]CreateOpcServerRequest request)
    {
        return new OpcServerResponse();
    }

    [HttpPut]
    public OpcServerResponse Put([FromBody]CreateOpcServerRequest request)
    {
        return new OpcServerResponse();
    }

    [HttpDelete("{id}")]
    public OpcServerResponse Delete(Guid id)
    {
        return new OpcServerResponse();
    }
}