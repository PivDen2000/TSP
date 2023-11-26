using Backend.Domain;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    private readonly ILogger<DataController> _logger;
    private readonly ISolverService _solverService;

    public DataController(ILogger<DataController> logger, ISolverService solverService)
    {
        _logger = logger;
        _solverService = solverService;
    }

    [HttpGet(Name = "GetData")]
    public ActionResult<object> Get([FromBody] object request)
    {
        var data = request;
        var graph = new Graph(1);
        var dataAfterFuncUsing = _solverService.Solve(graph);
        return Ok(dataAfterFuncUsing);
    }
}