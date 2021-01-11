using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            //all womens' leagues
            ViewBag.AllWomenLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Women"))
                .ToList();

            //all leagues where sport is any type of hockey
            ViewBag.AllLeagueSportIsHockey = _context.Leagues
                .Where(l => l.Sport.Contains("Hockey"))
                .ToList();

            //all leagues where sport is something OTHER THAN football
            ViewBag.LeaguesWhereSportOtherThenFootball = _context.Leagues
                .Where(l => !l.Sport.Contains("Football"))
                .ToList();

            //all leagues that call themselves "conferences"
            ViewBag.LeaguesCalledConferences = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();

            //all leagues in the Atlantic region
            ViewBag.LeageInAtlantic = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();

            //all teams based in Dallas
            ViewBag.TeamsInDallas = _context.Teams
                .Where(t => t.Location == "Dallas")
                .ToList();

            //all teams named the Raptors
            ViewBag.TeamNamedRaptors = _context.Teams
                .Where(t => t.TeamName.Contains("Raptors"))
                .ToList();

            //all teams whose location includes "City"
            ViewBag.TeamLocationHasCity = _context.Teams
                .Where(t => t.Location.Contains("City"))
                .ToList();

            //all teams whose names begin with "T"
            ViewBag.TeamStartsWithT = _context.Teams
                .Where(t => t.TeamName.StartsWith("T"))
                .ToList();

            //all teams, ordered alphabetically by location
            ViewBag.OrderedByLocation = _context.Teams
                .OrderBy(t => t.Location)
                .ToList();

            //all teams, ordered by team name in reverse alphabetical order
            ViewBag.OrderedDescendingByTeam = _context.Teams
                .OrderByDescending(t => t.TeamName)
                .ToList();

            //every player with last name "Cooper"
            ViewBag.PlayerLastNameCooper = _context.Players
                .Where(p => p.LastName == "Cooper")
                .ToList();

            //every player with first name "Joshua"
            ViewBag.PlayerFirstNameJoshua = _context.Players
                .Where(p => p.FirstName == "Joshua")
                .ToList();

            //every player with last name "Cooper" EXCEPT those with "Joshua" as the first name
            ViewBag.PlayersLNameCooperNoFNameJoshua = _context.Players
                .Where(p => (p.LastName=="Cooper") && !(p.FirstName== "Joshua"))
                .ToList();

            //all players with first name "Alexander" OR first name "Wyatt"
            ViewBag.PlayersWithFNameAlexanderOrWyatt = _context.Players
                .Where(p => (p.FirstName == "Alexander") || (p.FirstName == "Wyatt"))
                .ToList();

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            //...all teams in the Atlantic Soccer Conference
            ViewBag.AllTeamsInAtlanticSoccerManyAccess = _context.Teams
                .Include(l => l.CurrLeague).Where(l => l.CurrLeague.Name.Contains("Atlantic Soccer")).ToList();
            //OR
            // ViewBag.AllTeamsInAtlanticSoccerOneAccess = _context.Leagues
            //     .Include(t => t.Teams)
            //     .FirstOrDefault(l => l.Name == "Atlantic Soccer Conference,Soccer"); 



            //..all (current) players on the Boston Penguins (Hint: Boston is the Location, Penguins is the TeamName)
            ViewBag.AllPlayersInBostonPenguins = _context.Players
                .Include(p => p.CurrentTeam.CurrLeague)
                .Where(p => p.CurrentTeam.Location == "Boston")
                .ToList();


            //all (current) players in the International Collegiate Baseball Conference
            ViewBag.AllCurrentPlayersInCollegiateBaseball = _context.Players
                .Include(p => p.CurrentTeam.CurrLeague)
                .Where(p => p.CurrentTeam.CurrLeague.Name
                .Contains("Collegiate Baseball"))
                .ToList();


            //.all (current) players in the American Conference of Amateur Football with last name "Lopez"
            ViewBag.PlayersInAmericanAmateurFootballLNameLopez = _context.Players
                .Include(p => p.CurrentTeam.CurrLeague)
                .Where(p => (p.CurrentTeam.CurrLeague.Name
                .Contains("Amateur Football")) && (p.LastName == "Lopez")).ToList(); //THERE WERE NO LOPEZSSES

            //<li>...all football players</li>
            ViewBag.AllFootballPlayers = _context.Players
                .Include(p => p.CurrentTeam.CurrLeague)
                .Where(p => p.CurrentTeam.CurrLeague.Sport == "Football")
                .ToList();


            //all teams with a (current) player named "Sophia"
            ViewBag.AllTeamsWithSophia = _context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => (p.FirstName == "Sophia") || (p.LastName=="Sophia"))
                .ToList();


            //all leagues with a (current) player named "Sophia"
            ViewBag.AllLeaguesWithPlayersSophia = _context.Players
                .Include(p => p.CurrentTeam.CurrLeague)
                .Where(p => (p.FirstName == "Sophia") || (p.LastName=="Sophia"))
                .ToList();


            //...everyone with the last name "Flores" who DOESN'T (currently) play for the Washington Roughriders
            ViewBag.AllFloresNotInWashingtonRoughriders = _context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => (p.LastName=="Flores") && !(p.CurrentTeam.TeamName.Contains("Roughriders")))
                .ToList();


            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}