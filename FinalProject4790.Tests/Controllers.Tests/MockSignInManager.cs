using System;
using System.Threading.Tasks;
using FinalProject4790.Auth;
using FinalProject4790.Models.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace FinalProject4790.Tests.Controllers.Tests
{
    /// <summary>
    /// Mocke SignInManager for tests using Moq. 
    /// </summary>
    public class MockSignInManager : SignInManager<AppUser>
    {
        public MockSignInManager()
            : base(new Mock<MockUserManager>().Object,
                  new HttpContextAccessor(),
                  new Mock<IUserClaimsPrincipalFactory<AppUser>>().Object,
                  new Mock<IOptions<IdentityOptions>>().Object,
                  new Mock<ILogger<SignInManager<AppUser>>>().Object, 
                  new Mock<IAuthenticationSchemeProvider>().Object)
        { }
    }
}