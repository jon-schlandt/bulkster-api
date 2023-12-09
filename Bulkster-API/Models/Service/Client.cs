using System.ComponentModel.DataAnnotations;
using Bulkster_API.Models.Controller;
using Bulkster_API.Models.Controller.Client;
using Bulkster_API.Models.Repository;

namespace Bulkster_API.Models.Service;

public class Client
{
    public Guid Id { get; set; }
    
    public Guid GenderId { get; }
    
    public byte Age { get; }

    public short Weight { get; }
    
    public short Height { get; }
    
    public Guid ActivityLevelId { get; }
    
    public short CalorieModifier { get; }
    
    public short DailyCalorieGoal { get; }

    #region Constructors

    public Client(InitializeClientRequest request)
    {
        string? validationErr = null;
        
        if (request.GenderId == null || request.GenderId == Guid.Empty)
        {
            validationErr = $"The {nameof(request.GenderId)} field cannot be null or empty.";
        }

        if (request.Age is null or <= 0)
        {
            validationErr = $"The {nameof(request.Age)} field cannot be null or have a value less than 1";
        }

        if (request.Weight is null or <= 0)
        {
            validationErr = $"The {nameof(request.Weight)} field cannot be null or have a value less than 1";
        }

        if (request.Height is null or <= 0)
        {
            validationErr = $"The {nameof(request.Height)} field cannot be null or have a value less than 1";
        }

        if (request.ActivityLevelId == null || request.ActivityLevelId == Guid.Empty)
        { 
            validationErr = $"The {nameof(request.ActivityLevelId)} field cannot be null or empty.";
        }

        if (request.CalorieModifier is null or <= 0)
        {
            validationErr = $"The {nameof(request.CalorieModifier)} field cannot be null or have a value less than 1";
        }

        if (request.DailyCalorieGoal is null or <= 0)
        {
            validationErr = $"The {nameof(request.DailyCalorieGoal)} field cannot be null or have a value less than 1";
        }

        if (validationErr != null)
        {
            throw new ValidationException(validationErr);
        }
        
        GenderId = request.GenderId.GetValueOrDefault();
        Age = request.Age.GetValueOrDefault();
        Weight = request.Weight.GetValueOrDefault();
        Height = request.Height.GetValueOrDefault();
        ActivityLevelId = request.ActivityLevelId.GetValueOrDefault();
        CalorieModifier = request.CalorieModifier.GetValueOrDefault();
        DailyCalorieGoal = request.DailyCalorieGoal.GetValueOrDefault();
    }

    public Client(UpdateClientRequest request)
    {
        string? validationErr = null;

        if (request.ClientId == null || request.ClientId == Guid.Empty)
        {
            validationErr = $"The {nameof(request.ClientId)} field cannot be null or empty.";
        }
        
        if (request.GenderId == null || request.GenderId == Guid.Empty)
        {
            validationErr = $"The {nameof(request.GenderId)} field cannot be null or empty.";
        }

        if (request.Age is null or <= 0)
        {
            validationErr = $"The {nameof(request.Age)} field cannot be null or have a value less than 1";
        }

        if (request.Weight is null or <= 0)
        {
            validationErr = $"The {nameof(request.Weight)} field cannot be null or have a value less than 1";
        }

        if (request.Height is null or <= 0)
        {
            validationErr = $"The {nameof(request.Height)} field cannot be null or have a value less than 1";
        }

        if (request.ActivityLevelId == null || request.ActivityLevelId == Guid.Empty)
        { 
            validationErr = $"The {nameof(request.ActivityLevelId)} field cannot be null or empty.";
        }

        if (request.CalorieModifier is null or <= 0)
        {
            validationErr = $"The {nameof(request.CalorieModifier)} field cannot be null or have a value less than 1";
        }

        if (request.DailyCalorieGoal is null or <= 0)
        {
            validationErr = $"The {nameof(request.DailyCalorieGoal)} field cannot be null or have a value less than 1";
        }

        if (validationErr != null)
        {
            throw new ValidationException(validationErr);
        }

        Id = request.ClientId.GetValueOrDefault();
        GenderId = request.GenderId.GetValueOrDefault();
        Age = request.Age.GetValueOrDefault();
        Weight = request.Weight.GetValueOrDefault();
        Height = request.Height.GetValueOrDefault();
        ActivityLevelId = request.ActivityLevelId.GetValueOrDefault();
        CalorieModifier = request.CalorieModifier.GetValueOrDefault();
        DailyCalorieGoal = request.DailyCalorieGoal.GetValueOrDefault();
    }

    public Client(ClientEntity entity)
    {
        Id = entity.ClientId;
        GenderId = entity.GenderId;
        Age = entity.Age;
        Weight = entity.Weight;
        Height = entity.Height;
        ActivityLevelId = entity.ActivityLevelId;
        CalorieModifier = entity.CalorieModifier;
        DailyCalorieGoal = entity.DailyCalorieGoal;
    }

    #endregion
}
