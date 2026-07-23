namespace FawryOopTask;

public class Observation
{
    public string PlateNumber { get; set; }
    public DateTime Date { get; set; }
    public CarType Type { get; set; }
    public int Speed { get; set; }
    public bool IsSeatbeltFastened { get; set; }
}