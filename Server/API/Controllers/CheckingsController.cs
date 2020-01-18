using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Checking;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckingsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICheckingRepository checkingRepository;
        private readonly ICheckingMedicineRepository checkingMedicineRepository;
        private readonly ICheckingTestRepository checkingTestRepository;
        private readonly ICheckingItemRepository checkingItemRepository;
        private readonly IItemRepository itemRepository;

        public CheckingsController(IMapper mapper, IUnitOfWork unitOfWork, ICheckingRepository checkingRepository, ICheckingTestRepository checkingTestRepository, ICheckingMedicineRepository checkingMedicineRepository, ICheckingItemRepository checkingItemRepository, IItemRepository itemRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.itemRepository = itemRepository;
            this.checkingRepository = checkingRepository;
            this.checkingTestRepository = checkingTestRepository;
            this.checkingItemRepository = checkingItemRepository;
            this.checkingMedicineRepository = checkingMedicineRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CheckingForAddDTO model)
        {
            Checking checking = mapper.Map<Checking>(model);
            checking.CheckingTests = mapper.Map<List<CheckingTest>>(model.CheckingTests);
            checking.CheckingItems = mapper.Map<List<CheckingItem>>(model.CheckingItems);
            checking.CheckingMedicines = mapper.Map<List<CheckingMedicine>>(model.CheckingMedicines);

            foreach (var item in checking.CheckingItems)
            {
                Item oldItem = await itemRepository.Get(item.ItemId).ConfigureAwait(true);
                item.Price = oldItem.Price;
                item.Cost = oldItem.Cost;
                oldItem.Quantity -= item.Quantity;
                itemRepository.Edit(oldItem);
            }

            await checkingRepository.Add(checking).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<CheckingForGetDTO>(await checkingRepository.Get(checking.Id).ConfigureAwait(true)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(CheckingForEditDTO model)
        {

            Checking oldChecking = await checkingRepository.Get(model.Id).ConfigureAwait(true);

            foreach (var item in oldChecking.CheckingItems)
            {
                Item oldItem = await itemRepository.Get(item.ItemId).ConfigureAwait(true);
                oldItem.Quantity += item.Quantity;
                itemRepository.Edit(oldItem);
            }
            checkingTestRepository.Remove(model.Id);
            checkingItemRepository.Remove(model.Id);
            checkingMedicineRepository.Remove(model.Id);

            await unitOfWork.CompleteAsync().ConfigureAwait(true);

            Checking checking = mapper.Map<Checking>(model);
            checking.PatientId = oldChecking.PatientId;
            checking.CheckingTests = mapper.Map<List<CheckingTest>>(model.CheckingTests);
            checking.CheckingItems = mapper.Map<List<CheckingItem>>(model.CheckingItems);
            checking.CheckingMedicines = mapper.Map<List<CheckingMedicine>>(model.CheckingMedicines);

            foreach (var item in checking.CheckingItems)
            {
                Item oldItem = await itemRepository.Get(item.ItemId).ConfigureAwait(true);
                item.Price = oldItem.Price;
                item.Cost = oldItem.Cost;
                oldItem.Quantity -= item.Quantity;
                itemRepository.Edit(oldItem);
            }

            checkingTestRepository.Add(checking.CheckingTests);
            checkingItemRepository.Add(checking.CheckingItems);
            checkingMedicineRepository.Add(checking.CheckingMedicines);

            checkingRepository.Edit(checking);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<CheckingForGetDTO>(await checkingRepository.Get(checking.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Checking checking = await checkingRepository.Get(id).ConfigureAwait(true);
            foreach (var item in checking.CheckingItems)
            {
                Item oldItem = await itemRepository.Get(item.ItemId).ConfigureAwait(true);
                oldItem.Quantity += item.Quantity;
                itemRepository.Edit(oldItem);
            }

            checkingRepository.Remove(checking);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<CheckingForGetDTO>(checking));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(mapper.Map<CheckingForGetDTO>(await checkingRepository.Get(id).ConfigureAwait(true)));
        }

        [Route("patients/{patientId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetForPatient(int patientId)
        {
            return Ok(mapper.Map<List<CheckingForGetDTO>>(await checkingRepository.GetForPatient(patientId).ConfigureAwait(true)));
        }

        [Route("{id:int}/medicines")]
        [HttpGet]
        public async Task<IActionResult> GetMedicines(int id)
        {
            return Ok(mapper.Map<List<CheckingMedicineForGetDTO>>(await checkingMedicineRepository.Get(id).ConfigureAwait(true)));
        }

        [Route("{id:int}/tests")]
        [HttpGet]
        public async Task<IActionResult> GetTests(int id)
        {
            return Ok(mapper.Map<List<CheckingTestForGetDTO>>(await checkingTestRepository.Get(id).ConfigureAwait(true)));
        }

        [Route("{id:int}/items")]
        [HttpGet]
        public async Task<IActionResult> GetItems(int id)
        {
            return Ok(mapper.Map<List<CheckingItemForGetDTO>>(await checkingItemRepository.Get(id).ConfigureAwait(true)));
        }

    }
}