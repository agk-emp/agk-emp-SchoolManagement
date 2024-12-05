using SchoolProject.Service.Requests;
using SchoolProject.Service.Results;

namespace SchoolProject.Service.Abstracts
{
    public interface IClaimService
    {
        Task<ManageUserClaimsResult> ManageUserClaims(int userId);
        Task UpdateUserClaims(UpdateUserClaims request);
    }
}
