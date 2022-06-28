using kolos.DTO;
using kolos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos.Services
{
    public class DbService : IDbService
    {
        private readonly S20240DbContext _context;
        public DbService(S20240DbContext context)
        {
            _context = context;
        }

        public async Task<TeamDto> GetTeam(int idTeam)
        {
            return await _context.Team.Select(e => new TeamDto
            {
                TeamID = e.TeamID,
                OrganizationID = e.OrganizationID,
                TeamName = e.TeamName,
                TeamDescription = e.TeamDescription
            }).FirstOrDefaultAsync(e => e.TeamID == idTeam);
        }

        public async Task<List<MembershipDto>> GetMemberships(TeamDto team)
        {
            return await _context.Membership.Select(e => new MembershipDto
            {

            }).OrderBy(e => e.MembershipDate).
            Where(e => e.TeamID == team.TeamID ).
            ToListAsync();
        }
    }
}
