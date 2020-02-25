using EventHandler.DAL;
using EventHandler.DAL.Interfaces;
using EventHandler.DTO;
using EventHandler.DTO.Grid;
using EventHandler.Services.Utils;
using System.Collections.Generic;
using System.Linq;

namespace EventHandler.Services.Processors
{
    internal class EventGridDataProcessor
    {
        private IEventRepository _eventRepository;

        internal EventGridDataProcessor(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
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

            columns.Add(new GridColumn("applicant", "applicant", "ФИО подавшего заявку", false));
            columns.Add(new GridColumn("applyDateTime", "applyDateTime", "Дата и время подачи", false));
            columns.Add(new GridColumn("description", "description", "Описание", false));
            columns.Add(new GridColumn("responsible", "responsible", "Ответственный", false));
            columns.Add(new GridColumn("eventStatusName", "eventStatusName", "Статус", false));
            columns.Add(new GridColumn("resolveDateTime", "resolveDateTime", "Дата и время выполнения", false));

            return columns;
        }

        private long GetTotalItems()
        {
            return _eventRepository.GetEventsCount();
        }
    }
}
