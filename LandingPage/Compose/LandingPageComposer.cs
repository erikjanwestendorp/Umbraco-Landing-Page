using LandingPage.Extensions;
using LandingPage.Services;
using LandingPage.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace LandingPage.Compose
{
    public class LandingPageComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            // Add Configuration
            builder.AddLandingPageConfiguration();

            // Add Services
            builder.Services.AddTransient<IContainerService, ContainerService>();
        }
    }
}
