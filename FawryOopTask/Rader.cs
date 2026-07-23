using FawryOopTask.Rules;

namespace FawryOopTask;

 public class Radar
 {
    private readonly List<IRule> _rules = new List<IRule>();
    private readonly List<Fine> _issuedFines = new List<Fine>();
    private readonly Dictionary<string, int> _violatedRulesCount = new Dictionary<string, int>();
    public void AddRule(IRule rule)
    {
        _rules.Add(rule);
    }
    public void AddRule(IEnumerable<IRule> rule)
    {
        _rules.AddRange(rule);
    }

    public void ProcessObservation(Observation obs)
    {
        var fine = new Fine { PlateNumber = obs.PlateNumber };

        foreach (var rule in _rules)
        {
            var violation = rule.Evaluate(obs);
            if (violation != null)
            {
                fine.Violations.Add(violation);
                RecordRuleViolation(violation.RuleName);
            }
        }

        // Issue fine only if violations exist
        if (fine.Violations.Any())
        {
            _issuedFines.Add(fine);
            Console.WriteLine($"{fine}\n");
        }
    }

    private void RecordRuleViolation(string ruleName)
    {
        if (_violatedRulesCount.ContainsKey(ruleName))
        {
            _violatedRulesCount[ruleName]++;
        }
        else
        {
            _violatedRulesCount[ruleName] = 1;
        }
    }
    
    public void PrintAllFinesSummary()
    {
        Console.WriteLine("=== All Fines Summary ===");
        foreach (var fine in _issuedFines)
        {
            Console.WriteLine($"Plate: {fine.PlateNumber} | Total Amount: {fine.TotalAmount} EGP");
        }
        Console.WriteLine();
    }

    public void PrintViolatedRulesCount()
    {
        Console.WriteLine("=== Violated Rules Count ===");
        foreach (var violatedRule in _violatedRulesCount)
        {
            Console.WriteLine($"{violatedRule.Key}: {violatedRule.Value} violation(s)");
        }
        Console.WriteLine();
    }
 }