using HB.TodoApp.Common.ResponseObjects;
using HB.TodoApp.DataAccess.Interfaces;
using HB.TodoApp.Dtos.Dtos;
using HB.TodoApp.Dtos.Interfaces;
using HB.TodoApp.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.TodoApp.Business.Interfaces
{
    public interface IWorkServices
    {
        Task<IResponse<List<WorkListDto>>> GetAll();
        Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto);
        Task<IResponse<IDto>> GetByİd<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto);

    }
}
