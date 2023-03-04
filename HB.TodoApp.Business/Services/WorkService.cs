using AutoMapper;
using FluentValidation;
using HB.TodoApp.Business.Extention;
using HB.TodoApp.Business.Interfaces;
using HB.TodoApp.Business.ValidationRules;
using HB.TodoApp.Common.ResponseObjects;
using HB.TodoApp.DataAccess.Interfaces;
using HB.TodoApp.DataAccess.Repositories;
using HB.TodoApp.DataAccess.UnitOfWork;
using HB.TodoApp.Dtos.Dtos;
using HB.TodoApp.Dtos.Interfaces;
using HB.TodoApp.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HB.TodoApp.Business.Services
{
    public class WorkService : IWorkServices
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<WorkCreateDto> _createDtoValidator;
        private readonly IValidator<WorkUpdateDto> _updateDtoValidator;
        public WorkService(IUow uow, IMapper mapper, IValidator<WorkCreateDto> createDtoValidator, IValidator<WorkUpdateDto> updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                await _uow.SaveChanges();
                return new Response<WorkCreateDto>(ResponseType.Success, dto);
            }
             return new Response<WorkCreateDto>(ResponseType.ValidationError, dto,validationResult.ConvertToCustomValidationError());
            
        }

        public async Task<IResponse<List<WorkListDto>>> GetAll()
        {
          var data =   _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());

            return new Response<List<WorkListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetByİd<IDto>(int id)
        {
            var result = _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));
            if (result == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} id data not found"); 
            }

            return new Response<IDto>(ResponseType.Success, result);
       
        }

        public async Task<IResponse> Remove(int id)
        {       
            //get by filter ile çekme nedenimiz takibe ihtiyac yok
            var removedEntity = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);

            if (removedEntity != null)
            {
                _uow.GetRepository<Work>().Remove(removedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }

            return new Response(ResponseType.NotFound,$"{id} id data not found");
            
           
        }

        public async Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto)
        {

            var validationResult = _updateDtoValidator.Validate(dto);
          
            if (validationResult.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Work>().Find(dto.Id);

                if (updatedEntity != null)
                {
                    _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto),updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<WorkUpdateDto>(ResponseType.Success,dto);
                }
                else
                {
                    return new Response<WorkUpdateDto>(ResponseType.NotFound, dto);
                }

            }
          
             
                return new Response<WorkUpdateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToCustomValidationError());
            
          
              
          


        }

    
    }
}
