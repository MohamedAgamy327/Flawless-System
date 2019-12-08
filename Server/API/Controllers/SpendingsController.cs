using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Spendings;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpendingsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ISpendingRepository spendingRepository;

        public SpendingsController(IMapper mapper, IUnitOfWork unitOfWork, ISpendingRepository spendingRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.spendingRepository = spendingRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SpendingForAddDTO model)
        {
            Spending spending = mapper.Map<Spending>(model);
            await spendingRepository.Add(spending).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<SpendingForGetDTO>(await spendingRepository.Get(spending.Id).ConfigureAwait(true)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(SpendingForEditDTO model)
        {
            Spending oldSpending = await spendingRepository.Get(model.Id).ConfigureAwait(true);
            Spending spending = mapper.Map<Spending>(model);
            spending.Date = oldSpending.Date;
            spendingRepository.Edit(spending);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<SpendingForGetDTO>(await spendingRepository.Get(spending.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Spending spending = await spendingRepository.Get(id).ConfigureAwait(true);
            spendingRepository.Remove(spending);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<SpendingForGetDTO>(spending));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<SpendingForGetDTO>>(await spendingRepository.Get().ConfigureAwait(true)));
        }
    }
}