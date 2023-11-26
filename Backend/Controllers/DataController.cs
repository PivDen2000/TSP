using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    private readonly ILogger<DataController> _logger;
    private readonly IAlgorithmService _algorithmService;

    public DataController(ILogger<DataController> logger, IAlgorithmService algorithmService)
    {
        _logger = logger;
        _algorithmService = algorithmService;
    }

    [HttpGet(Name = "GetData")]
    public ActionResult<object> Get([FromBody] object request)
    {
        var data = request;
        var dataAfterFuncUsing = _algorithmService.DoWork();
        return Ok(dataAfterFuncUsing);
    }
}