using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mission10.Data;

namespace Mission10.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private IBowlerRepository _repo;
        public BowlerController(IBowlerRepository temp)
        {
            _repo = temp;
        }

        [HttpGet]
        public IEnumerable<Bowler> Get()
        {
            var bowlersWithTeams = from bowler in _repo.Bowlers
                                   join team in _repo.Teams on bowler.TeamID equals team.TeamID
                                   where team.TeamName == "Sharks" || team.TeamName == "Marlins"
                                   select new Bowler
                                   {
                                       BowlerID = bowler.BowlerID,
                                       BowlerLastName = bowler.BowlerLastName,
                                       BowlerFirstName = bowler.BowlerFirstName,
                                       BowlerMiddleInit = bowler.BowlerMiddleInit,
                                       BowlerAddress = bowler.BowlerAddress,
                                       BowlerCity = bowler.BowlerCity,
                                       BowlerState = bowler.BowlerState,
                                       BowlerZip = bowler.BowlerZip,
                                       BowlerPhoneNumber = bowler.BowlerPhoneNumber,
                                       TeamID = team.TeamID,
                                       Team = team
                                   };

            return bowlersWithTeams.ToArray();

            //var bowlerData = _repo.Bowlers.ToArray();

            //return bowlerData;
        }
    }
}
