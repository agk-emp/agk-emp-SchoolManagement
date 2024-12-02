using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Results;

namespace SchoolProject.Service.Implementations
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository;
        private readonly UserManager<User> _userManager;

        public ClaimService(IClaimRepository claimRepository, UserManager<User> userManager)
        {
            _claimRepository = claimRepository;
            _userManager = userManager;
        }

        public async Task<ManageUserClaimsResult> ManageUserClaims(int userId)
        {
            var response = new ManageUserClaimsResult();
            var claimsManager = new List<ManageUserClaimsResult.UserClaimsChecker>();
            response.UserId = userId;
            var user = await GetUserById(userId);
            var userClaims = await _userManager.GetClaimsAsync(user);
            var claims = await _claimRepository.GetTableAsTracking().ToListAsync();
            foreach (var claim in claims)
            {
                var claimManager = new ManageUserClaimsResult.UserClaimsChecker()
                {
                    ClaimType = claim.ClaimType,
                    ClaimValue = claim.ClaimValue,
                    Id = claim.Id,
                };

                if (userClaims.Any(clm => clm.Type == claim.ClaimType))
                {
                    claimManager.HasClaim = true;
                }
                else
                {
                    claimManager.HasClaim = false;
                }
                claimsManager.Add(claimManager);
            }
            response.UserClaimsCheckers = claimsManager;
            return response;
        }

        private async Task<User> GetUserById(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
            {
                throw new Exception(SharedResourcesKeys.NotFound);
            }
            return user;
        }
    }
}
