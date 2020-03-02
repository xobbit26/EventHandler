using EventHandler.DAL;
using EventHandler.DAL.Interfaces;
using EventHandler.DTO;
using EventHandler.DTO.Enums;
using EventHandler.DTO.Grid;
using EventHandler.Services.Interfaces;
using EventHandler.Services.Utils;
using System.Collections.Generic;
using System.Linq;

namespace EventHandler.Services.Processors
{
    internal class EventGridDataProcessor
    {
        private const string _defaultLocale = "EN";
        private readonly string _locale;

        private readonly IEventRepository _eventRepository;
        private readonly IResourceService _resourceService;

        internal EventGridDataProcessor(IEventRepository eventRepository,
            IResourceService resourceService,
            string locale = _defaultLocale)
        {
            _eventRepository = eventRepository;
            _resourceService = resourceService;
            _locale = locale;
        }

        internal GridDTO<EventDTO> GetGridData(PageOptions pageOptions)
        {
            var gridData = new GridDTO<EventDTO>();
            var eventsData = GetEventsData(pageOptions);

            if (eventsData.Count != 0)
            {
                gridData.Data = eventsData;
                gridData.Columns = GetGridColumns();
                gridData.IsGridEmpty = false;
                gridData.TotalItems = GetTotalItems();
            }

            return gridData;
        }

        private List<EventDTO> GetEventsData(PageOptions pageOptions)
        {
            return _eventRepository.GetEvents(pageOptions)
                .Select(x => MapUtils.GetEventDTOFromEventEntity(x))
                .ToList();
        }

        private List<GridColumn> GetGridColumns()
        {
            var columns = new List<GridColumn>();

            columns.Add(new GridColumn("applicant", "applicant",
                _resourceService.GetTranslation(LocalizeKeysEnum.EventsTable_Header_FullName, _locale), ColumnTypeEnum.String, false));
            columns.Add(new GridColumn("applyDateTime", "applyDateTime",
                _resourceService.GetTranslation(LocalizeKeysEnum.EventsTable_Header_ApplyDateTime, _locale), ColumnTypeEnum.DateTime, false));
            columns.Add(new GridColumn("description", "description",
                _resourceService.GetTranslation(LocalizeKeysEnum.EventsTable_Header_Description, _locale), ColumnTypeEnum.String, false));
            columns.Add(new GridColumn("responsible", "responsible",
                _resourceService.GetTranslation(LocalizeKeysEnum.EventsTable_Header_Responsible, _locale), ColumnTypeEnum.String, false));
            columns.Add(new GridColumn("eventStatusName", "eventStatus",
                _resourceService.GetTranslation(LocalizeKeysEnum.EventsTable_Header_Status, _locale), ColumnTypeEnum.String, false));
            columns.Add(new GridColumn("resolveDateTime", "resolveDateTime",
                _resourceService.GetTranslation(LocalizeKeysEnum.EventsTable_Header_ResolveDateTime, _locale), ColumnTypeEnum.String, false));

            return columns;
        }

        private long GetTotalItems()
        {
            return _eventRepository.GetEventsCount();
        }
    }
}
