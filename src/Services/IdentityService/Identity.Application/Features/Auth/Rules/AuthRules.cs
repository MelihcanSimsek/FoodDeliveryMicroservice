using Identity.Application.Bases;
using Identity.Application.Features.Auth.Exceptions;
using Identity.Domain.Entities;

namespace Identity.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public async Task UserShouldNotBeExistsWhenRegistered(User? user)
        {
            if (user is not null) throw new UserAlreadyExistsException();
        }

        public async Task ShouldEmailAndPasswordCorrect(User? user, bool checkPassword)
        {
            if (user is null || !checkPassword) throw new EmailOrPasswordWrongException();
        }

        public async Task ShouldUserRefreshTokenNotBeExpired(DateTime? refreshTokenExpiryDate)
        {
            if (refreshTokenExpiryDate <= DateTime.Now) throw new RefreshTokenShouldNotBeExpiredException();
        }

        public async Task ShouldEmailValidWhenRevoked(User? user)
        {
            if (user is null) throw new EmailNotValidException();
        }
    }
}
