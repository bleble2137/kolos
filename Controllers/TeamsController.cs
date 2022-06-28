using kolos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public TeamsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{idTeam}")]
        public async Task<IActionResult> GetTeam([FromRoute] int idTeam)
        {/*
            Przygotuj końcówkę, która będzie zwracać informację 
            na temat określonego zespołu.
            Zwrócony  JSON powinienz zawierać 
            nazwę zespołu, jego opis, nazwę organizacji do której należy
           orazlistę znajdujących się wnim użytkowników
                .Końcówka powinna przyjmować ID zespołujako parametr.
             Lista powinna być posortowana rosnąco po dacie dołączenia do
                zespołu(MembershipDate).Należy pamiętać o odpowiednich statusach błędów.
                */

            // input jako ID
            // band name, description, organization name
            // users sorted by membershipdate
            var team = await _dbService.GetTeam(idTeam);
            if(team is null)
            {
                return NotFound();
            }

            var memberships = await _dbService.GetMemberships(team);

            // niestety nie starczylo mi czasu na wiecej
            // w planach bylo wykorzystanie memberships zeby zdobyc liste members
            // wtedy wystarczyloby juz zadbac o wlasciwe zwrocenie danych do uzytkownika

            return Ok(team);
        }
    }
}
