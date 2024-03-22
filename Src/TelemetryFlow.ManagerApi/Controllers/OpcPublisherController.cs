using Microsoft.AspNetCore.Mvc;
using TelemetryFlow.Data;
using TelemetryFlow.ManagerApi.Requests;
using TelemetryFlow.ManagerApi.Responses;
using TelemetryFlow.Model;

namespace TelemetryFlow.ManagerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OpcPublisherController : Controller
{
    private readonly TelemetryFlowDbContext _dbContext;

    public OpcPublisherController(TelemetryFlowDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    [HttpGet("{id}")]
    public OpcPublisherResponse Get(Guid id)
    {
        var opcPublisher = _dbContext.OpcPublishers.FirstOrDefault(x => x.Id == id);
        if (opcPublisher == null)
        {
            throw new ArgumentNullException(nameof(opcPublisher));
        }
        
        return new OpcPublisherResponse()
        {
            Id = opcPublisher.Id,
            Name = opcPublisher.Name,
            MethodTopics = opcPublisher.MethodTopics,
            ServerId = opcPublisher.ServerId,
        };
    }

    [HttpPost]
    public OpcPublisherResponse Post([FromBody]CreateOpcPublisherRequest request)
    {
        var opcPublisher = _dbContext.OpcPublishers.Add(new OpcPublisher()
        {
            //Id = request.Id,
            Name = request.Name,
            MethodTopics = request.MethodTopics,
            ServerId = request.ServerId,
        });

        _dbContext.SaveChanges();
        
        return new OpcPublisherResponse()
        {
            Id = opcPublisher.Entity.Id,
            Name = opcPublisher.Entity.Name,
            MethodTopics = opcPublisher.Entity.MethodTopics,
            ServerId = opcPublisher.Entity.ServerId,
        };
    }
    
    [HttpPut]
    public OpcPublisherResponse Put([FromBody]UpdateOpcPublisherRequest request)
    {
        var opcPublisher = _dbContext.OpcPublishers.FirstOrDefault(x => x.Id == request.Id);
        if (opcPublisher == null)
        {
            throw new ArgumentNullException(nameof(opcPublisher));
        }

        opcPublisher.Name = request.Name;
        opcPublisher.MethodTopics = request.MethodTopics;
        opcPublisher.ServerId = request.ServerId;

        // TODO: proper check if SaveChanges was successful
        _dbContext.SaveChanges();
        
        return new OpcPublisherResponse()
        {
            Id = opcPublisher.Id,
            Name = opcPublisher.Name,
            MethodTopics = opcPublisher.MethodTopics,
            ServerId = opcPublisher.ServerId,
        };
    }

    [HttpDelete("{id}")]
    public OpcPublisherResponse Delete(Guid id)
    {
        var opcPublisher = _dbContext.OpcPublishers.FirstOrDefault(x => x.Id == id);
        if (opcPublisher == null)
        {
            throw new ArgumentNullException(nameof(opcPublisher));
        }

        _dbContext.OpcPublishers.Remove(opcPublisher);
        _dbContext.SaveChanges();
        
        return new OpcPublisherResponse()
        {
            Id = opcPublisher.Id,
            Name = opcPublisher.Name,
            MethodTopics = opcPublisher.MethodTopics,
            ServerId = opcPublisher.ServerId,
        };
    }
}