using System;
using ResearchProjectMonolith.NET.Models;

namespace ResearchProjectMonolith.NET.Services
{
    public interface IEdmondsKarpService
    {
        public int CalculateMaxFlow(Graph graph, int source, int destination);

    }
    public class EdmondsKarpService: IEdmondsKarpService
    {
        public IBfSservice _BfSservice { get; set; }
        public EdmondsKarpService(IBfSservice bfsService)
        {
            _BfSservice = bfsService;
        }

        public int CalculateMaxFlow(Graph graph, int source, int destination)
        {
            if (!areSourceAndGraphParametersValid(graph, source, destination))
            {
                throw new Exception($"Invalid source or destination parameter!\n " +
                                    $"Number of vertices: {graph.NumberOfVertices}\n " +
                                    $"Source: {source}\n Destination: {destination}\n");
            }
            
            int u, v;
            Graph residualGraph = (Graph)graph.Clone();
            int maxFlow = 0;
            BFSResult bfsResult = _BfSservice.Bfs(residualGraph, source, destination);

            while (bfsResult.Success)
            {
                int pathFlow = Int32.MaxValue;
                for (v = destination; v != source; v = bfsResult.Parents[v])
                {
                    u = bfsResult.Parents[v];
                    pathFlow = Math.Min(pathFlow, residualGraph.AdjacencyMatrix[u][v]);
                }

                for (v = destination; v != source; v = bfsResult.Parents[v])
                {
                    u = bfsResult.Parents[v];
                    residualGraph.AdjacencyMatrix[u][v] -= pathFlow;
                    residualGraph.AdjacencyMatrix[v][u] += pathFlow;
                }

                maxFlow += pathFlow;
                bfsResult = _BfSservice.Bfs(residualGraph, source, destination);
            }

            return maxFlow;
        }
        
        private bool areSourceAndGraphParametersValid(Graph graph, int source, int destination) {
            return source >= 0 && source < graph.NumberOfVertices && destination >= 0 && destination < graph.NumberOfVertices;
        }
    }
}