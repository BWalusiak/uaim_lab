namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IExaminationRoomsSelectorHandler
    {
        Task<int> GetExaminationRoomsSelectionAsync();
    }
}
