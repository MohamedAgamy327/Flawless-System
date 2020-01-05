using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Diagnosis;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosissController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDiagnosisRepository diagnosisRepository;

        public DiagnosissController(IMapper mapper, IUnitOfWork unitOfWork, IDiagnosisRepository diagnosisRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.diagnosisRepository = diagnosisRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(DiagnosisForAddDTO model)
        {

            Diagnosis diagnosis = mapper.Map<Diagnosis>(model);
            await diagnosisRepository.Add(diagnosis).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<DiagnosisForGetDTO>(await diagnosisRepository.Get(diagnosis.Id).ConfigureAwait(true)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(DiagnosisForEditDTO model)
        {
            Diagnosis diagnosis = mapper.Map<Diagnosis>(model);
            diagnosisRepository.Edit(diagnosis);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<DiagnosisForGetDTO>(await diagnosisRepository.Get(diagnosis.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Diagnosis diagnosis = await diagnosisRepository.Get(id).ConfigureAwait(true);
            diagnosisRepository.Remove(diagnosis);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<DiagnosisForGetDTO>(diagnosis));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<DiagnosisForGetDTO>>(await diagnosisRepository.Get().ConfigureAwait(true)));
        }
    }
}