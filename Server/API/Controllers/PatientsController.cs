using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Patients;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPatientRepository patientRepository;

        public PatientsController(IMapper mapper, IUnitOfWork unitOfWork, IPatientRepository patientRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.patientRepository = patientRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PatientForAddDTO model)
        {
            Patient patient = mapper.Map<Patient>(model);
            await patientRepository.Add(patient).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<PatientForGetDTO>(await patientRepository.Get(patient.Id).ConfigureAwait(true)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(PatientForEditDTO model)
        {
            Patient patient = mapper.Map<Patient>(model);
            patientRepository.Edit(patient);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<PatientForGetDTO>(await patientRepository.Get(patient.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Patient patient = await patientRepository.Get(id).ConfigureAwait(true);
            patientRepository.Remove(patient);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<PatientForGetDTO>(patient));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<PatientForGetDTO>>(await patientRepository.Get().ConfigureAwait(true)));
        }
    }
}