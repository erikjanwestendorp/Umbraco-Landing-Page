using LandingPage.Models;
using Umbraco.Cms.Core.Models;

namespace LandingPage.Services
{
    public interface IContainerService
    {
        bool Exists(Container container);
        EntityContainer Create(Container container);
    }
}