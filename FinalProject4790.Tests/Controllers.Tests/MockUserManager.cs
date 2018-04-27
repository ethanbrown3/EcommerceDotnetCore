using System;
using System.Linq;
using System.Threading.Tasks;
using FinalProject4790.Auth;
using FinalProject4790.Models.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace FinalProject4790.Tests.Controllers.Tests
{
    /// <summary>
    /// Mocked Identity UserManager using Moq.
    /// </summary>
    public class MockUserManager : UserManager<AppUser>
    {
        public MockUserManager()
            : base(
                new Mock<IUserStore<AppUser>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<AppUser>>().Object,
                new IUserValidator<AppUser>[0],
                new IPasswordValidator<AppUser>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<AppUser>>>().Object
            )
        { }
        public override IQueryable<AppUser> Users { get; }
    }
}