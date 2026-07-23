namespace FawryOopTask.Rules;

public class SeatbeltRule : IRule
{
    public string RuleName => "Seatbelt Rule";
    public decimal Fee { get;  } = 100;

    public SeatbeltRule ()
    {
        
    }

    public SeatbeltRule(decimal fee)
    {
        this.Fee = fee;
    }
    public Violation? Evaluate(Observation obs)
    {
        if (!obs.IsSeatbeltFastened)
        {
            return new Violation 
            { 
                RuleName = this.RuleName, 
                Description = "Seatbelt not fastned", 
                Fee = this.Fee 
            };
        }
        return null;
    }
}
