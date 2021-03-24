namespace ExaminationRooms.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.ExaminationRoomAggregate;
    using Dtos;
    using Mapper;

    public class ExaminationRoomQueriesHandler : IExaminationRoomQueriesHandler
    {
        private readonly IExaminationRoomsRepository _examinationRoomsRepository;

        public ExaminationRoomQueriesHandler(IExaminationRoomsRepository examinationRoomsRepository)
        {
            _examinationRoomsRepository = examinationRoomsRepository;
        }

        public IEnumerable<ExaminationRoomDto> GetAll()
        {
            return _examinationRoomsRepository.GetAll().Select(r=>r.Map());
        }

        public IEnumerable<ExaminationRoomDto> GetByCertificationType(int certificationType)
        {
            return _examinationRoomsRepository.GetByCertificationType(certificationType)?.Select(ld=>ld.Map());
        }
    }
}
