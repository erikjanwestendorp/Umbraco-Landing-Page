using System;
using LandingPage.Models;
using LandingPage.Static;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace LandingPage.Services.Implementation
{
    public class ContainerService : IContainerService
    {
        private readonly IDataTypeService _dataTypeService;
        private readonly IContentTypeService _contentTypeService;
        private readonly IMediaTypeService _mediaTypeService;

        public ContainerService(IDataTypeService dataTypeService, IContentTypeService contentTypeService, IMediaTypeService mediaTypeService)
        {
            _dataTypeService = dataTypeService;
            _contentTypeService = contentTypeService;
            _mediaTypeService = mediaTypeService;

        }

        public bool Exists(Container container)
        {
            if (container == null)
                return false;

            switch (container.Type)
            {
                case EntityType.ContentType:
                    var contentTypeContainer = _contentTypeService.GetContainer(container.Key);
                    return contentTypeContainer != null;
                
                case EntityType.DataType:
                    var dataTypeContainer = _dataTypeService.GetContainer(container.Key);
                    return dataTypeContainer != null;

                case EntityType.MediaType:
                    var mediaTypeContainer = _dataTypeService.GetContainer(container.Key);
                    return mediaTypeContainer != null;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public EntityContainer Create(Container container)
        {
            throw new NotImplementedException();
        }
    }
}
