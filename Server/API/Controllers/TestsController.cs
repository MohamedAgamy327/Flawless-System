using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Test;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ITestRepository testRepository;

        public TestsController(IMapper mapper, IUnitOfWork unitOfWork, ITestRepository testRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.testRepository = testRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TestForAddDTO model)
        {

            Test test = mapper.Map<Test>(model);
            await testRepository.Add(test).ConfigureAwait(true);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<TestForGetDTO>(await testRepository.Get(test.Id).ConfigureAwait(true)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(TestForEditDTO model)
        {
            Test test = mapper.Map<Test>(model);
            testRepository.Edit(test);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<TestForGetDTO>(await testRepository.Get(test.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Test test = await testRepository.Get(id).ConfigureAwait(true);
            testRepository.Remove(test);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<TestForGetDTO>(test));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<TestForGetDTO>>(await testRepository.Get().ConfigureAwait(true)));
        }
    }
}