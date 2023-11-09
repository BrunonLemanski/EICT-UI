using System.ComponentModel.DataAnnotations;

namespace RoutePlanning.Application.Locations.Queries.RouteInfo;
public class RouteInfoInput
{
    [Required]
    public string From { get; set; } = string.Empty;
    [Required]
    public string To { get; set; } = string.Empty;
    [Required]
    public float Weight { get; set; }
    [Required]
    public int Length { get; set; }
    [Required]
    public int Width { get; set; }
    [Required]
    public int Height { get; set; }
    public string[] Types { get; set; } = new string[0];

    public RouteInfoInput()
    {
        
    }

    public RouteInfoInput(string from, string to, float weight, int length, int width, int height, string[] types)
    {
        From = from;
        To = to;
        Weight = weight;
        Length = length;
        Width = width;
        Height = height;
        Types = types;
    }
}
