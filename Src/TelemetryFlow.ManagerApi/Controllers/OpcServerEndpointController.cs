using Microsoft.AspNetCore.Mvc;
using TelemetryFlow.Data;
using TelemetryFlow.ManagerApi.Requests;
using TelemetryFlow.ManagerApi.Responses;
using TelemetryFlow.Model;

namespace TelemetryFlow.ManagerApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class OpcServerEndpointController : Controller
{
    private readonly TelemetryFlowDbContext _dbContext;

    public OpcServerEndpointController(TelemetryFlowDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    [HttpGet("{id}")]
    public OpcServerEndpointResponse Get(Guid id)
    {
        var opcServerEndpoint = _dbContext.OpcServerEndpoints.FirstOrDefault(x => x.Id == id);
        if (opcServerEndpoint == null)
        {
            throw new ArgumentNullException(nameof(opcServerEndpoint));
        }
        
        return new OpcServerEndpointResponse()
        {
            Id = opcServerEndpoint.Id,
            Name = opcServerEndpoint.Name,
            SecurityMode = opcServerEndpoint.SecurityMode,
            SecurityPolicy = opcServerEndpoint.SecurityPolicy,
            AuthenticationMode = opcServerEndpoint.AuthenticationMode,
            Username = opcServerEndpoint.Username,
            Password = opcServerEndpoint.Password,
            ServerId = opcServerEndpoint.ServerId,
        };
    }

    [HttpPost]
    public OpcServerEndpointResponse Post([FromBody]CreateOpcServerEndpointRequest request)
    {
        var opcServerEndpoint = _dbContext.OpcServerEndpoints.Add(new OpcServerEndpoint()
        {
            Name = request.Name,
            SecurityMode = request.SecurityMode,
            SecurityPolicy = request.SecurityPolicy,
            AuthenticationMode = request.AuthenticationMode,
            Username = request.Username,
            Password = request.Password,
            ServerId = request.ServerId,
        });
        _dbContext.SaveChanges();
        
        return new OpcServerEndpointResponse()
        {
            Id = opcServerEndpoint.Entity.Id,
            Name = opcServerEndpoint.Entity.Name,
            SecurityMode = opcServerEndpoint.Entity.SecurityMode,
            SecurityPolicy = opcServerEndpoint.Entity.SecurityPolicy,
            AuthenticationMode = opcServerEndpoint.Entity.AuthenticationMode,
            Username = opcServerEndpoint.Entity.Username,
            Password = opcServerEndpoint.Entity.Password,
            ServerId = opcServerEndpoint.Entity.ServerId,
        };
    }

    [HttpPut]
    public OpcServerEndpointResponse Post([FromBody]UpdateOpcServerEndpointRequest request)
    {
        var opcServerEndpoint = _dbContext.OpcServerEndpoints.FirstOrDefault(x => x.Id == request.id);
        if (opcServerEndpoint == null)
        {
            throw new ArgumentNullException(nameof(opcServerEndpoint));
        }
            
        _dbContext.OpcServerEndpoints.Add(new OpcServerEndpoint()
        {
            Name = request.Name,
            SecurityMode = request.SecurityMode,
            SecurityPolicy = request.SecurityPolicy,
            AuthenticationMode = request.AuthenticationMode,
            Username = request.Username,
            Password = request.Password,
            ServerId = request.ServerId,
        });
        _dbContext.SaveChanges();
        
        return new OpcServerEndpointResponse()
        {
            Id = opcServerEndpoint.Id,
            Name = opcServerEndpoint.Name,
            SecurityMode = opcServerEndpoint.SecurityMode,
            SecurityPolicy = opcServerEndpoint.SecurityPolicy,
            AuthenticationMode = opcServerEndpoint.AuthenticationMode,
            Username = opcServerEndpoint.Username,
            Password = opcServerEndpoint.Password,
            ServerId = opcServerEndpoint.ServerId,
        };
    }

    [HttpDelete("{id}")]
    public OpcServerEndpointResponse Delete(Guid id)
    {
        var opcServerEndpoint = _dbContext.OpcServerEndpoints.FirstOrDefault(x => x.Id == id);
        
        if (opcServerEndpoint == null)
        {
            throw new ArgumentNullException(nameof(opcServerEndpoint));
        }

        _dbContext.OpcServerEndpoints.Remove(opcServerEndpoint);
        _dbContext.SaveChanges();
        
        return new OpcServerEndpointResponse()
        {
            Id = opcServerEndpoint.Id,
            Name = opcServerEndpoint.Name,
            SecurityMode = opcServerEndpoint.SecurityMode,
            SecurityPolicy = opcServerEndpoint.SecurityPolicy,
            AuthenticationMode = opcServerEndpoint.AuthenticationMode,
            Username = opcServerEndpoint.Username,
            Password = opcServerEndpoint.Password,
            ServerId = opcServerEndpoint.ServerId,
        };
    }
}