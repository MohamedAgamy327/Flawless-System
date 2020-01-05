using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Items;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IItemRepository itemRepository;

        public ItemsController(IMapper mapper, IUnitOfWork unitOfWork, IItemRepository itemRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.itemRepository = itemRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ItemForAddDTO model)
        {
            Item item = mapper.Map<Item>(model);
            await itemRepository.Add(item).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<ItemForGetDTO>(await itemRepository.Get(item.Id).ConfigureAwait(true)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(ItemForEditDTO model)
        {
            Item oldItem = await itemRepository.Get(model.Id).ConfigureAwait(true);
            Item item = mapper.Map<Item>(model);
            item.Cost = oldItem.Cost;
            item.Quantity = oldItem.Quantity;
            itemRepository.Edit(item);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<ItemForGetDTO>(await itemRepository.Get(item.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Item item = await itemRepository.Get(id).ConfigureAwait(true);
            itemRepository.Remove(item);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<ItemForGetDTO>(item));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<ItemForGetDTO>>(await itemRepository.Get().ConfigureAwait(true)));
        }
    }
}