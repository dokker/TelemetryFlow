using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TelemetryFlow.Data;
using TelemetryFlow.ManagerApi.Requests;
using TelemetryFlow.ManagerApi.Responses;
using TelemetryFlow.Model;

namespace TelemetryFlow.ManagerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OpcServerController : Controller
{
    private readonly TelemetryFlowDbContext _dbContext;

    public OpcServerController(TelemetryFlowDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    
    [HttpGet("{id}")]
    public OpcServerResponse Get(Guid id)
    {
        //throw new ArgumentNullException(nameof(id));

        // AsNoTracking for optimization
        var opcServer = _dbContext.OpcServers.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (opcServer == null)
        {
            throw new ArgumentNullException(nameof(opcServer));
        }
        
        return new OpcServerResponse()
        {
            Id = opcServer.Id,
            Name = opcServer.Name,
            Address = opcServer.Address,
        };
    }

    [HttpPost]
    public OpcServerResponse Post([FromBody]CreateOpcServerRequest request)
    {
        var opcServer = _dbContext.OpcServers.Add(new OpcServer()
        {
            Name = request.Name,
            Address = request.Address,
        });
        _dbContext.SaveChanges();
        
        return new OpcServerResponse()
        {
            Id = opcServer.Entity.Id,
            Name = opcServer.Entity.Name,
            Address = opcServer.Entity.Address,
        };
    }

    [HttpPut]
    //public ActionResult<OpcServerResponse> Put([FromBody]UpdateOpcServerRequest request)
    public OpcServerResponse Put([FromBody]UpdateOpcServerRequest request)
    {
        var opcServer = _dbContext.OpcServers.FirstOrDefault(x => x.Id == request.Id);
        if (opcServer == null)
        {
            throw new ArgumentNullException(nameof(opcServer));
        }

        opcServer.Name = request.Name;
        opcServer.Address = request.Address;
        
        _dbContext.SaveChanges();
        
        return new OpcServerResponse()
        {
            Id = opcServer.Id,
            Name = opcServer.Name,
            Address = opcServer.Address,
        };
    }

    [HttpDelete("{id}")]
    public OpcServerResponse Delete(Guid id)
    {
        var opcServer = _dbContext.OpcServers.FirstOrDefault(x => x.Id == id);
        if (opcServer == null)
        {
            throw new ArgumentNullException(nameof(opcServer));
        }

        _dbContext.OpcServers.Remove(opcServer);
        _dbContext.SaveChanges();
        
        return new OpcServerResponse()
        {
            Id = opcServer.Id,
            Name = opcServer.Name,
            Address = opcServer.Address,
        };
    }
}