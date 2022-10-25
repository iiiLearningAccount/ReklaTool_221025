namespace ReklaTool.Models;

public class FilterRequest
{
    public string Aktenzeichen_Typ { get; set; }
    public string Aktenzeichen { get; set; }
    public bool IsSchnellsuche { get; set; }
    public int VorgangIndex { get; set; }
}