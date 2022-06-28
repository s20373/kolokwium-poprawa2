using kolokwium_poprawa.Models.DTO;

namespace kolokwium_poprawa.Services
{
    public interface IDbService
    {
       public async Task<TeamDTO> GetTeam(int teamId);
       public Task<bool> TeamExists(int teamId);
    }
}
