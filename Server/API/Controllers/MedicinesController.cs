using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Medicines;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMedicineRepository medicineRepository;

        public MedicinesController(IMapper mapper, IUnitOfWork unitOfWork, IMedicineRepository medicineRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.medicineRepository = medicineRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MedicineForAddDTO model)
        {
            Medicine medicine = mapper.Map<Medicine>(model);
            await medicineRepository.Add(medicine).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<MedicineForGetDTO>(await medicineRepository.Get(medicine.Id).ConfigureAwait(true)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(MedicineForEditDTO model)
        {
            Medicine medicine = mapper.Map<Medicine>(model);
            medicineRepository.Edit(medicine);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<MedicineForGetDTO>(await medicineRepository.Get(medicine.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Medicine medicine = await medicineRepository.Get(id).ConfigureAwait(true);
            medicineRepository.Remove(medicine);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<MedicineForGetDTO>(medicine));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<MedicineForGetDTO>>(await medicineRepository.Get().ConfigureAwait(true)));
        }
    }
}