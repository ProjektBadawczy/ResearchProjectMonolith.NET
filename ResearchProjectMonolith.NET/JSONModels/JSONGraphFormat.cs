using System.Text.Json.Serialization;
using ResearchProjectMonolith.NET.Models;

namespace ResearchProjectMonolith.NET.JSONModels;

[Serializable]
public class JSONGraphFormat
{
    [JsonPropertyName("graph")]
    public Graph graph { get; set; }
    
    [JsonPropertyName("directedGraph")]
    public DirectedGraph directedGraph { get; set; }
}