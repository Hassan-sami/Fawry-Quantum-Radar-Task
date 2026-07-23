namespace FawryOopTask;

public class Fine
{
    public string PlateNumber { get; set; }
    public List<Violation> Violations { get; set; } = new List<Violation>();
    public decimal TotalAmount => Violations.Sum(v => v.Fee);
    
    public override string ToString()
    {
        var result = $"Traffic fine for car {PlateNumber}\n";
        result += $"Total amount: {TotalAmount} EGP\n";
        result += "Violations:\n";
        foreach (var violation in Violations)
        {
            result += $"- {violation.RuleName} : {violation.Fee} EGP\n";
        }
        return result.TrimEnd();
    }
}
