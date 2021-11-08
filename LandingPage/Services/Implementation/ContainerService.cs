using System;
using LandingPage.Models;
using LandingPage.Static;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.ContentEditing;
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
            if (!Exists(container)) 
                return CreateContainer(container);
            
            
            _logger.LogWarning("Cannot create container, container with key {containerKey} already exists", container.Key);
            return false;


        }

        private bool CreateContainer(Container container)
        {
            return container != null && CreateContainerAttempt(container);
        }

        private bool CreateContainerAttempt(Container container)
        {
            if (container == null)
                return false;

            Attempt<OperationResult<OperationResultType, EntityContainer>> attempt;

            switch (container.Type)
            {
                case EntityType.ContentType:
                    attempt = container.ParentKey != Guid.Empty 
                        ? _contentTypeService.CreateContainer(GetParentContainerId(container), container.Key, container.Name) 
                        : _contentTypeService.CreateContainer(-1, container.Key, container.Name);
                    
                    return attempt.Success;

                case EntityType.DataType:
                    attempt = container.ParentKey != Guid.Empty
                        ? _dataTypeService.CreateContainer(GetParentContainerId(container), container.Key, container.Name)
                        : _dataTypeService.CreateContainer(-1, container.Key, container.Name);
                    return attempt.Success;

                case EntityType.MediaType:
                    attempt = container.ParentKey != Guid.Empty
                        ? _mediaTypeService.CreateContainer(GetParentContainerId(container), container.Key, container.Name)
                        : _mediaTypeService.CreateContainer(-1, container.Key, container.Name);
                    return attempt.Success;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private int GetParentContainerId(Container container)
        {
            var entityContainer = GetParentContainer(container);

            if (entityContainer != null) 
                return entityContainer.Id;
            
            
            _logger.LogWarning("Cannot get container with key {key}", container.ParentKey);
            return 0;

        }

        private EntityContainer GetParentContainer(Container container)
        {
            return container.Type switch
            {
                EntityType.ContentType => _contentTypeService.GetContainer(container.ParentKey),
                EntityType.DataType => _dataTypeService.GetContainer(container.ParentKey),
                EntityType.MediaType => _mediaTypeService.GetContainer(container.ParentKey),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

         
    }
}
