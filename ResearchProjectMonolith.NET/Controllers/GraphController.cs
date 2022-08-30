using Microsoft.AspNetCore.Mvc;
using ResearchProjectMonolith.NET.Models;
using ResearchProjectMonolith.NET.Services;

namespace ResearchProjectMonolith.NET.Controllers
{
    [ApiController]
    public class GraphController : ControllerBase
    {
        private IGraphService _graphService;

        private IEdmondsKarpService _edmondsKarpService;

        private IPushRelabelService _pushRelabelService;

        public GraphController(IGraphService graphService, IEdmondsKarpService edmondsKarpService,
            IPushRelabelService pushRelabelService)
        {
            _graphService = graphService;
            _edmondsKarpService = edmondsKarpService;
            _pushRelabelService = pushRelabelService;
        }

        [HttpGet]
        [Route("graph")]
        public ActionResult<Graph> GetGraph([FromQuery] int id)
        {
            Graph graph = _graphService.getGraph(id);
            if (graph != null)
            {
                return graph;
            }

            return NotFound();
        }

        [HttpGet]
        [Route("edmondsKarpMaxGraphFlow")]
        public ActionResult<int> GetEdmondsKarpMaxGraphFlow([FromQuery] GraphParametersFlow graphParametersFlow)
        {
            Graph graph = _graphService.getGraph(graphParametersFlow.id);
            if (graph == null)
            {
                return NotFound();
            }

            int maxFlow =
                _edmondsKarpService.CalculateMaxFlow(graph, graphParametersFlow.source,
                    graphParametersFlow.destination);

            return maxFlow;
        }

        [HttpGet]
        [Route("pushRelabelMaxGraphFlow")]
        public ActionResult<int> GetPushRelabelMaxGraphFlow([FromQuery] GraphParametersFlow graphParametersFlow)
        {
            DirectedGraph graph = _graphService.getDirectedGraph(graphParametersFlow.id);
            if (graph == null)
            {
                return NotFound();
            }

            int maxFlow =
                _pushRelabelService.CalculateMaxFlow(graph, graphParametersFlow.source,
                    graphParametersFlow.destination);

            return maxFlow;
        }
    }
}