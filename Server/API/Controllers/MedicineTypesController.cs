using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.MedicineType;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineTypesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMedicineTypeRepository medicineTypeRepository;

        public MedicineTypesController(IMapper mapper, IUnitOfWork unitOfWork, IMedicineTypeRepository medicineTypeRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.medicineTypeRepository = medicineTypeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MedicineTypeForAddDTO model)
        {

            MedicineType medicineType = mapper.Map<MedicineType>(model);
            await medicineTypeRepository.Add(medicineType).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<MedicineTypeForGetDTO>(await medicineTypeRepository.Get(medicineType.Id).ConfigureAwait(true)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(MedicineTypeForEditDTO model)
        {
            MedicineType medicineType = mapper.Map<MedicineType>(model);
            medicineTypeRepository.Edit(medicineType);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<MedicineTypeForGetDTO>(await medicineTypeRepository.Get(medicineType.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            MedicineType medicineType = await medicineTypeRepository.Get(id).ConfigureAwait(true);
            medicineTypeRepository.Remove(medicineType);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<MedicineTypeForGetDTO>(medicineType));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<MedicineTypeForGetDTO>>(await medicineTypeRepository.Get().ConfigureAwait(true)));
        }
    }
}