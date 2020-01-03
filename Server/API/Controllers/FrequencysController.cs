using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Frequency;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrequencysController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IFrequencyRepository frequencyRepository;

        public FrequencysController(IMapper mapper, IUnitOfWork unitOfWork, IFrequencyRepository frequencyRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.frequencyRepository = frequencyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(FrequencyForAddDTO model)
        {

            Frequency frequency = mapper.Map<Frequency>(model);
            await frequencyRepository.Add(frequency).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<FrequencyForGetDTO>(await frequencyRepository.Get(frequency.Id).ConfigureAwait(true)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(FrequencyForEditDTO model)
        {
            Frequency frequency = mapper.Map<Frequency>(model);
            frequencyRepository.Edit(frequency);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<FrequencyForGetDTO>(await frequencyRepository.Get(frequency.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Frequency frequency = await frequencyRepository.Get(id).ConfigureAwait(true);
            frequencyRepository.Remove(frequency);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<FrequencyForGetDTO>(frequency));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<FrequencyForGetDTO>>(await frequencyRepository.Get().ConfigureAwait(true)));
        }
    }
}