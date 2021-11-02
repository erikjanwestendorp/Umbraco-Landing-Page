using LandingPage.Configuration;
using LandingPage.Services;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Composing;

namespace LandingPage.Components
{
    public class ContainerComponent : IComponent
    {
        private readonly ILogger<ContainerComponent> _logger;
        private readonly IContainerService _containerService;

        
        public ContainerComponent(ILogger<ContainerComponent> logger, IContainerService containerService)
        {
            _logger = logger;
            _containerService = containerService;

        }

        public void Initialize()
        {
            _logger.LogInformation("Initialize ContainerComponent");

            AddRootContainersContainers();
        }

        private void AddRootContainersContainers()
        {
            foreach (var container in ContainerConfiguration.RootContainers)
            {
                _containerService.Create(container);

            }
        }

      

        public void Terminate()
        {
            _logger.LogInformation("Terminate ContainerComponent");
        }
    }
}
