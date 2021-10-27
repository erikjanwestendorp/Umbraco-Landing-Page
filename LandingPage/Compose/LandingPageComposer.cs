using LandingPage.Extensions;
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
        }
    }
}
