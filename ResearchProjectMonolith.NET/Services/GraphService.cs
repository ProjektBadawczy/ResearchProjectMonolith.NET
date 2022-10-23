using ResearchProjectMonolith.NET.Models;
using ResearchProjectMonolith.NET.Repositories;

namespace ResearchProjectMonolith.NET.Services
{

    public interface IGraphService
    {
        public Graph getGraph(int id);

        public DirectedGraph getDirectedGraph(int id);

    }
    
    public class GraphService: IGraphService
    {
        public GraphRepository _graphRepository;

        public GraphService(GraphRepository graphRepository)
        {
            _graphRepository = graphRepository;
        }

        public Graph getGraph(int id)
        {
            var graph = _graphRepository.Graphs.Find(obj => obj.graph.Id == id);
            return graph.graph;
        }
        
        public DirectedGraph getDirectedGraph(int id)
        {
            var graph = _graphRepository.Graphs.Find(obj => obj.directedGraph.Id == id);
            return graph.directedGraph;
        }
        
    }
}