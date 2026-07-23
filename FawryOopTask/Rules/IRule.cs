namespace FawryOopTask.Rules;

public interface IRule
{
    string RuleName { get; }
    
    decimal Fee { get; }
    // Returns a Violation if the rule is broken, otherwise returns null
    Violation? Evaluate(Observation observation);
}