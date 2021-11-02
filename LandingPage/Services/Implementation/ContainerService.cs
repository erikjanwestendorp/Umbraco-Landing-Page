using System;
using LandingPage.Models;
using LandingPage.Static;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Services;

namespace LandingPage.Services.Implementation
{
    public class ContainerService : IContainerService
    {
        private readonly ILogger<ContainerService> _logger;
        private readonly IDataTypeService _dataTypeService;
        private readonly IContentTypeService _contentTypeService;
        private readonly IMediaTypeService _mediaTypeService;

        public ContainerService(ILogger<ContainerService> logger, IDataTypeService dataTypeService, IContentTypeService contentTypeService, IMediaTypeService mediaTypeService)
        {
            _logger = logger;
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
                    var mediaTypeContainer = _mediaTypeService.GetContainer(container.Key);
                    return mediaTypeContainer != null;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public bool Create(Container container)
        {
            if (Exists(container))
            {
                _logger.LogWarning("Cannot create container, container with key {containerKey} already exists", container.Key);
                return false;
            }

            
            return CreateRootContainer(container);
        }

        private bool CreateRootContainer(Container container)
        {
            switch (container.Type)
            {
                case EntityType.ContentType:
                    var createContentTypeContainerAttempt = _contentTypeService.CreateContainer(-1, container.Key, container.Name);
                    return createContentTypeContainerAttempt.Success;

                case EntityType.DataType:
                    var createDataTypeContainerAttempt = _dataTypeService.CreateContainer(-1, container.Key, container.Name);
                    return createDataTypeContainerAttempt.Success;

                case EntityType.MediaType:
                    var createMediaTypeContainerAttempt = _dataTypeService.CreateContainer(-1, container.Key, container.Name);
                    return createMediaTypeContainerAttempt.Success;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

         
    }
}
