using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Patients;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;
using System.IO;
using OfficeOpenXml;
using API.DTO;
using API.Extensions;
using Domain.Enums;

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

        [HttpPost("upload")]
        public async Task<IActionResult> Upload()
        {
            FileInfo file = new FileInfo(@"D:\1.xlsx");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage package = new ExcelPackage(file);
            ExcelWorksheet workSheet = package.Workbook.Worksheets[0];

            int totalRows = workSheet.Dimension.Rows;
            for (int i = 2; i <= totalRows; i++)
            {
                Patient patient = new Patient
                {
                    Name = workSheet.ConvertToString(i, 1),
                    Telephone = workSheet.ConvertToString(i, 2),
                    Gender = workSheet.ConvertToString(i, 3) == "ذكر" ? GenderEnum.Male : GenderEnum.Female
                };
                await patientRepository.Add(patient).ConfigureAwait(true);
                await unitOfWork.CompleteAsync().ConfigureAwait(true);
            }
            return Ok();
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

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(mapper.Map<PatientForGetDTO>(await patientRepository.Get(id).ConfigureAwait(true)));
        }

        [Route("bytelephone/{telephone}")]
        [HttpGet]
        public async Task<IActionResult> Get(string telephone)
        {
            return Ok(mapper.Map<PatientForGetDTO>(await patientRepository.Get(telephone).ConfigureAwait(true)));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<PatientForGetDTO>>(await patientRepository.Get().ConfigureAwait(true)));
        }
    }
}