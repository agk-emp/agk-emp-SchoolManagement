using SchoolProject.Service.Results;

namespace SchoolProject.Service.Abstracts
{
    public interface IClaimService
    {
        Task<ManageUserClaimsResult> ManageUserClaims(int userId);
    }
}
