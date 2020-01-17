using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.User;
using API.IHelpers;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.UnitOfWork;
using Utilities.Password;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IJWTManager jwtManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;

        public UsersController(IJWTManager jwtManager, IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.jwtManager = jwtManager;
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserForAddDTO model)
        {
            User user = mapper.Map<User>(model);
            await userRepository.Add(user).ConfigureAwait(true);
            SecurePassword.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<UserForGetDTO>(await userRepository.Get(user.Id).ConfigureAwait(true)));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserForEditDTO model)
        {
            User user = mapper.Map<User>(model);
            User oldUser = await userRepository.Get(model.Id).ConfigureAwait(true);
            user.PasswordHash = oldUser.PasswordHash;
            user.PasswordSalt = oldUser.PasswordSalt;
            userRepository.Edit(user);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<UserForGetDTO>(await userRepository.Get(user.Id).ConfigureAwait(true)));
        }

        [Route("ChangePassword")]
        [HttpPut]
        public async Task<IActionResult> ChangePassword(UserForChangePasswordDTO model)
        {
            User user = await userRepository.Get(model.Id).ConfigureAwait(true);
            SecurePassword.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            userRepository.Edit(user);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<UserForGetDTO>(await userRepository.Get(user.Id).ConfigureAwait(true)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            User user = await userRepository.Get(id).ConfigureAwait(true);
            userRepository.Remove(user);
            await unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok(mapper.Map<UserForGetDTO>(user));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<List<UserForGetDTO>>(await userRepository.Get().ConfigureAwait(true)));
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDTO model)
        {
            User user = await userRepository.Login(model.Name, model.Password).ConfigureAwait(true);
            if (user == null)
                return NotFound();

            return Ok(new { Token = jwtManager.GenerateToken(user.Id, user.Name,  user.Role.ToString()) });
        }

    }
}