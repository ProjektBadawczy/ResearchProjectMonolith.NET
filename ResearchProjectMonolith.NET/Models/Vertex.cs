using System.Text.Json.Serialization;

namespace ResearchProjectMonolith.NET.Models;

public class Vertex
{
    [JsonPropertyName("i")]
    public int i { get; set; }

    [JsonPropertyName("w")]
    public int w { get; set; }

    public Vertex(int i, int w)
    {
        this.i = i;
        this.w = w;
    }
}