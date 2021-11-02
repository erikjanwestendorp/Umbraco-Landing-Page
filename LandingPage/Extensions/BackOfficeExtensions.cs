using LandingPage.Components;
using Umbraco.Cms.Core.DependencyInjection;

namespace LandingPage.Extensions
{
    public static class BackOfficeExtensions
    {
        public static IUmbracoBuilder AddLandingPageConfiguration(this IUmbracoBuilder builder)
        {
            // Add components
            builder.Components().Append<ContainerComponent>();

            return builder;

        }
    }
}
