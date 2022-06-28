
using kolos.DTO;
using kolos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kolos.Services
{
    public interface IDbService
    {
        Task<TeamDto> GetTeam(int idTeam);
        Task<List<MembershipDto>> GetMemberships(TeamDto team);



    }
}
