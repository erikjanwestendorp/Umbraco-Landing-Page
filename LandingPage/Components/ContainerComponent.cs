using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Composing;

namespace LandingPage.Components
{
    public class ContainerComponent : IComponent
    {
        private readonly ILogger<ContainerComponent> _logger;
        public ContainerComponent(ILogger<ContainerComponent> logger)
        {
            _logger = logger;
        }

        public void Initialize()
        {
            _logger.LogInformation("Initialize ContainerComponent");
            
            AddContainers();
        }

        public void AddContainers()
        {

        }

        public void Terminate()
        {
            _logger.LogInformation("Terminate ContainerComponent");
        }
    }
}
