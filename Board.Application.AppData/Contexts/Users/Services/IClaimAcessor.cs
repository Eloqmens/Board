using System.Security.Claims;

namespace Board.Application.AppData.Contexts.Users.Services
{
    public interface IClaimAcessor
    {
        Task<IEnumerable<Claim>> GetClaims(CancellationToken token);
    }
}
