using SoccerTeamsManager.Exceptions;
using SoccerTeamsManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SoccerTeamsManager
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        private List<Team> TableTeams = new List<Team>();
        private List<Player> TablePlayers = new List<Player>();

        public SoccerTeamsManager()
        {
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            TableTeams.Add(new Team
            {
                Id = TableTeams.Any(x => x.Id.Equals(id)) ? throw new UniqueIdentifierException() : id,
                Name = name,
                CreateDate = createDate,
                MainShirtColor = mainShirtColor,
                SecondaryShirtColor = secondaryShirtColor
            });
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            TablePlayers.Add(new Player
            {
                Id = TablePlayers.Any(x => x.Id.Equals(id)) ? throw new UniqueIdentifierException() : id,
                TeamId = TableTeams.Any(x => x.Id.Equals(teamId)) ? teamId : throw new TeamNotFoundException(),
                Name = name,
                birthDate = birthDate,
                SkillLevel = skillLevel,
                Salary = salary
            });
        }

        public void SetCaptain(long playerId)
        {
            var soccer = TablePlayers.Any(x => x.Id.Equals(playerId)) ? TablePlayers.First(x => x.Id == playerId) : throw new PlayerNotFoundException();
            var team = TableTeams.FirstOrDefault(x => x.Id == soccer.TeamId);
            team.IdCaptain = soccer.Id;
        }

        public long GetTeamCaptain(long teamId)
        {
            return TableTeams.Any(x => x.Id.Equals(teamId)) ?
                TableTeams.Any(x => !x.IdCaptain.Equals(-1) && x.Id.Equals(teamId)) ? TableTeams.Where(x => x.Id.Equals(teamId)).Select(x => x.IdCaptain).First() : throw new CaptainNotFoundException()
                        : throw new TeamNotFoundException();
        }

        public string GetPlayerName(long playerId)
        {
            return TablePlayers.Any(x => x.Id.Equals(playerId)) ?
                TablePlayers.Where(x => x.Id.Equals(playerId)).Select(x => x.Name).ToString() :
                throw new PlayerNotFoundException();
        }

        public string GetTeamName(long teamId)
        {
            return TableTeams.Any(x => x.Id.Equals(teamId)) ?
                TableTeams.Where(x => x.Id.Equals(teamId)).Select(x => x.Name).First()
                : throw new TeamNotFoundException();
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            var list = TableTeams.Any(x => x.Id.Equals(teamId)) ?
                (from tabTeam in TableTeams
                 join tabSoccer in TablePlayers
                 on tabTeam.Id equals tabSoccer.TeamId
                 where tabSoccer.TeamId.Equals(teamId)
                 select tabSoccer.Id).OrderBy(x => x).ToList()
                 : throw new TeamNotFoundException();
            return list;
        }

        public long GetBestTeamPlayer(long teamId)
        {
            return TableTeams.Any(x => x.Id.Equals(teamId)) ?
                TablePlayers.Where(x => x.TeamId.Equals(teamId)).Select(x => x).OrderByDescending(x => x.SkillLevel).ThenBy(x => x.Id).First().Id
                : throw new TeamNotFoundException();
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            return TableTeams.Any(x => x.Id.Equals(teamId)) ?
                TablePlayers.Where(x => x.TeamId.Equals(teamId)).Select(x => x).OrderBy(x => x.birthDate).ThenBy(x => x.Id).First().Id
                : throw new TeamNotFoundException();
        }

        public List<long> GetTeams()
        {
            return TableTeams.Count() == 0 ? new List<long>() : TableTeams.Select(x => x.Id).OrderBy(x => x).ToList(); ;
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            return TableTeams.Any(x => x.Id.Equals(teamId)) ?
                TablePlayers.Where(x => x.TeamId.Equals(teamId)).Select(x => x).OrderByDescending(x => x.Salary).ThenBy(x => x.Id).First().Id
                : throw new TeamNotFoundException();
        }

        public decimal GetPlayerSalary(long playerId)
        {
            return TablePlayers.Any(x => x.Id.Equals(playerId)) ?
                TablePlayers.Where(x => x.Id.Equals(playerId)).Select(x => x.Salary).First() :
                throw new PlayerNotFoundException();
        }

        public List<long> GetTopPlayers(int top)
        {
            var players = TablePlayers.Select(x => x).OrderByDescending(x => x.SkillLevel).ToList();
            var listBestPlayers = new List<long>();
            for (int i = 0; players[i].SkillLevel.Equals(players[i + 1].SkillLevel); i++)
            {
                listBestPlayers.Add(players[i].Id);
            }
            return listBestPlayers.Count.Equals(0) ? players.Select(x => x.Id).Take(top).ToList() : listBestPlayers.OrderBy(x => x).Take(top).ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            var shirtVisitorTeam = TableTeams.Any(x => x.Id == teamId || x.Id == visitorTeamId) ?
                TableTeams.Where(x => x.Id.Equals(teamId)).Select(x => x.MainShirtColor.ToUpper()).First().Equals(TableTeams.Where(x => x.Id.Equals(visitorTeamId)).Select(x => x.MainShirtColor.ToUpper()).First()) ?
                TableTeams.Where(x => x.Id.Equals(visitorTeamId)).Select(x => x.SecondaryShirtColor).First() :
                TableTeams.Where(x => x.Id.Equals(visitorTeamId)).Select(x => x.MainShirtColor).First()
                : throw new TeamNotFoundException();

            return shirtVisitorTeam;
        }

    }
}
