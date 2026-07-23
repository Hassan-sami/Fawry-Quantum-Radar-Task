namespace FawryOopTask.Rules;

public class SpeedRule : IRule
{
    private readonly CarType _targetType;
    private readonly int _maxSpeed;
    public string RuleName => "Speed Limit Rule";
    public decimal Fee { get;  } = 300;

    public SpeedRule(CarType targetType, int maxSpeed)
    {
        _targetType = targetType;
        _maxSpeed = maxSpeed;
    }
    public SpeedRule(CarType targetType, int maxSpeed, decimal fee)
    {
        _targetType = targetType;
        _maxSpeed = maxSpeed;
        this.Fee = fee;
    }
    
    public Violation? Evaluate(Observation obs)
    {
        if (obs.Type == _targetType && obs.Speed > _maxSpeed)
        {
            return new Violation 
            { 
                RuleName = this.RuleName, 
                Description = $"speed of {obs.Speed} exceeded max allowed {_maxSpeed}", 
                Fee = this.Fee
            };
        }
        return null;
    }
}