using kolokwium_poprawa.Models;
using kolokwium_poprawa.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_poprawa.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _mainDbContext;

        public DbService(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<TeamDTO> GetTeam(int teamId)
        {
            var team = await _mainDbContext.Team
                .Where(e => e.TeamID == teamId)
                .Select(e => new Team
                {
                    TeamName = e.TeamName,
                    Organization = e.Organization
                }).FirstOrDefaultAsync();

            return new TeamDTO
            {
                TeamName = team.TeamName,
                OrganizationName = team.Organization.OrganizationName,
                Members = team.Organization.Members,
                TeamDescription = team.TeamDescription
            };
        }

        public async Task<bool> TeamExists(int teamId)
        {
            var team = await _mainDbContext.Team.Where(e => e.TeamID == teamId).FirstOrDefaultAsync();
            if (team == null) return false;
            return true;
        }

        //public async Task<bool> AddMemberToTeam(int memberId)
        //{
        //    using (var tran = await _mainDbContext.Database.BeginTransactionAsync())
        //    {
        //        var member = await _mainDbContext.Member.Where(e => e.MemberId == memberId).FirsOrDefaultAsync();


        //    }
        //}
    }
}
