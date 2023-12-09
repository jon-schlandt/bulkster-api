using System.ComponentModel.DataAnnotations;
using Bulkster_API.Models.Controller.Meal;
using Bulkster_API.Models.Service;
using Bulkster_API.Security;
using Bulkster_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bulkster_API.Controllers;

[Route("meal")]
[ApiController]
[RequireAppKey]
public class MealController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly IMealService _mealService;
    private readonly ILogger<MealController> _logger;

    public MealController(
        IClientService clientService, 
        IMealService mealService,
        ILogger<MealController> logger
    )
    {
        _clientService = clientService;
        _mealService = mealService;
        _logger = logger;
    }
    
    [Route("log")]
    [HttpPost]
    public async Task<ActionResult<LogMealResponse>> LogMealAsync([FromBody] LogMealRequest request)
    {
        CompleteMeal meal;
        try
        {
            meal = new CompleteMeal(request);
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { ex.Message });
        }
        
        try
        {
            Client? client = await _clientService.GetClientAsync(request.ClientId.GetValueOrDefault());
            if (client == null)
            {
                return BadRequest(new { Message = $"Client with Id '{request.ClientId}' could not be found." });
            }

            Guid mealId = await _mealService.LogMealAsync(meal);
            return Ok(new LogMealResponse
            {
                MealId = mealId
            });
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An error occured while while logging meal." });
        }
    }
}
