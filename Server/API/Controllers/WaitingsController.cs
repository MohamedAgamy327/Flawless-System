using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Waiting;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaitingsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IWaitingRepository waitingRepository;

        public WaitingsController(IMapper mapper, IUnitOfWork unitOfWork, IWaitingRepository waitingRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.waitingRepository = waitingRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(WaitingForAddDTO model)
        {
            Waiting waiting = new Waiting
            {
                PatientId = model.PatientId,
                Order = await waitingRepository.GetLastOrder().ConfigureAwait(true) + 1
            };
            await waitingRepository.Add(waiting).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<WaitingForGetDTO>(await waitingRepository.Get(waiting.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}/cancel")]
        [HttpPatch]
        public async Task<IActionResult> Cancel(int id)
        {
            Waiting waiting = await waitingRepository.Get(id).ConfigureAwait(true);
            waiting.CanceledDate = DateTime.Now;
            waitingRepository.Edit(waiting);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<WaitingForGetDTO>(await waitingRepository.Get(id).ConfigureAwait(true)));
        }

        [Route("{id:int}/enter")]
        [HttpPatch]
        public async Task<IActionResult> Enter(int id)
        {
            Waiting waiting = await waitingRepository.Get(id).ConfigureAwait(true);
            waiting.EnteredDate = DateTime.Now;
            waitingRepository.Edit(waiting);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<WaitingForGetDTO>(await waitingRepository.Get(id).ConfigureAwait(true)));
        }

        [Route("order")]
        [HttpPatch]
        public async Task<IActionResult> Order(List<int> Ids)
        {
            for (int i = 0; i < Ids.Count; i++)
            {
                Waiting waiting = await waitingRepository.Get(Ids[i]).ConfigureAwait(true);
                waiting.Order = i + 1;
                waitingRepository.Edit(waiting);
            }
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<List<WaitingForGetDTO>>(await waitingRepository.Get().ConfigureAwait(true)));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<WaitingForGetDTO>>(await waitingRepository.Get().ConfigureAwait(true)));
        }
    }
}