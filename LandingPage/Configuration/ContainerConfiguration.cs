using System.Collections.Generic;
using LandingPage.Models;
using LandingPage.Static;

namespace LandingPage.Configuration
{
    public static class ContainerConfiguration
    {
        public static List<Container> RootContainers = new()
        {
            new Container(LandingPageConstants.Containers.ContentTypes.LandingPageContainerKey, LandingPageConstants.Containers.ContentTypes.LandingPageContainerName, EntityType.ContentType),
            new Container(LandingPageConstants.Containers.DataTypes.LandingPageContainerKey, LandingPageConstants.Containers.DataTypes.LandingPageContainerName, EntityType.DataType)
        };

        public static List<Container> SubContainers = new()
        {
            new Container(LandingPageConstants.Containers.ContentTypes.PagesContainerKey, LandingPageConstants.Containers.ContentTypes.PagesContainerName, LandingPageConstants.Containers.ContentTypes.LandingPageContainerKey, EntityType.ContentType)
        };
    }


}
