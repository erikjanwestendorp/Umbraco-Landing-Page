using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Composing;

namespace LandingPage.Components
{
    public class DataTypeComponent : IComponent
    {
        private readonly ILogger<DataTypeComponent> _logger;

        public DataTypeComponent(ILogger<DataTypeComponent> logger)
        {
            _logger = logger;
        }

        public void Initialize()
        {
            _logger.LogInformation("Initialize DataTypeComponent");
        }

        private void AddDataTypes()
        {
            _logger.LogInformation("Setup DataTypes");
        }

        public void Terminate()
        {
            _logger.LogInformation("Terminate DataTypeComponent");
        }
    }
}
