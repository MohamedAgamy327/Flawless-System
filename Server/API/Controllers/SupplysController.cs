using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Supply;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplysController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ISupplyRepository supplyRepository;
        private readonly ISupplyItemRepository supplyItemRepository;
        private readonly IItemRepository itemRepository;

        public SupplysController(IMapper mapper, IUnitOfWork unitOfWork, ISupplyRepository supplyRepository, IItemRepository itemRepository, ISupplyItemRepository supplyItemRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.supplyRepository = supplyRepository;
            this.itemRepository = itemRepository;
            this.supplyItemRepository = supplyItemRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SupplyForAddDTO model)
        {
            Supply supply = mapper.Map<Supply>(model);
            supply.SupplyItems = mapper.Map<List<SupplyItem>>(model.SupplyItems);
            await supplyRepository.Add(supply).ConfigureAwait(true);

            foreach (var item in model.SupplyItems)
            {
                Item oldItem = await itemRepository.Get(item.ItemId).ConfigureAwait(true);
                oldItem.Price = item.Price;
                oldItem.Cost = item.Cost;
                oldItem.Quantity += item.Quantity;
                itemRepository.Edit(oldItem);
            }
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<SupplyForGetDTO>>(await supplyRepository.Get().ConfigureAwait(true)));
        }

        [Route("{supplyId:int}/items")]
        [HttpGet]
        public async Task<IActionResult> GetItems(int supplyId)
        {
            return Ok(mapper.Map<List<SupplyItemForGetDTO>>(await supplyItemRepository.Get(supplyId).ConfigureAwait(true)));
        }
    }
}