using CoreApi.DTO.Models.UserModels;
using FluentValidation;

namespace CoreApi.DTO.DTOValidatior.UserValidator
{
    public class UserForAddDTOValidator : AbstractValidator<UserForAddDTO>
    {
        public UserForAddDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().NotNull();
        }

    }
}
