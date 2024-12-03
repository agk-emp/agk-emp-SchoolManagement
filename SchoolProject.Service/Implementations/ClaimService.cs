using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Requests;
using SchoolProject.Service.Results;
using System.Security.Claims;

namespace SchoolProject.Service.Implementations
{
    public class ClaimService : IClaimService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClaimRepository _claimRepository;
        private readonly UserManager<User> _userManager;

        public ClaimService(IClaimRepository claimRepository,
            UserManager<User> userManager,
            IUserRepository userRepository)
        {
            _claimRepository = claimRepository;
            _userManager = userManager;
            _userRepository = userRepository;
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

        public async Task UpdateUserClaims(UpdateUserClaims request)
        {
            var user = await GetUserById(request.id);
            List<Claim> claimsToAddToUser = await GetClaimsByIds(request);
            await _userRepository.UpdateUserClaims(user, claimsToAddToUser);
        }

        private async Task<List<Claim>> GetClaimsByIds(UpdateUserClaims request)
        {
            var claimsToAddToUser = new List<Claim>();
            foreach (var claimId in request.Claims)
            {
                var claimToAddToUser = await _claimRepository.GetByIdAsync(claimId);
                var claim = new Claim(claimToAddToUser.ClaimType, claimToAddToUser.ClaimValue);
                claimsToAddToUser.Add(claim);
            }

            return claimsToAddToUser;
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
