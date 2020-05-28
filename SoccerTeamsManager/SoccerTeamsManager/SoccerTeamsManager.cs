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

        private void TeamExist(long id)
        {
            if (!TableTeams.Any(x => x.Id.Equals(id)))
                throw new TeamNotFoundException();
        }

        private void PlayerExist(long id)
        {
            if (!TableTeams.Any(x => x.Id.Equals(id)))
                throw new PlayerNotFoundException();
        }


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
            TeamExist(teamId);
            TablePlayers.Add(new Player
            {
                Id = TablePlayers.Any(x => x.Id.Equals(id)) ? throw new UniqueIdentifierException() : id,
                TeamId = teamId,
                Name = name,
                birthDate = birthDate,
                SkillLevel = skillLevel,
                Salary = salary
            });
        }

        public void SetCaptain(long playerId)
        {
            PlayerExist(playerId);
            var soccer = TablePlayers.First(x => x.Id == playerId);
            var team = TableTeams.First(x => x.Id == soccer.TeamId);
            team.IdCaptain = soccer.Id;
        }

        public long GetTeamCaptain(long teamId)
        {
            TeamExist(teamId);
            return TableTeams.Any(x => x.IdCaptain.HasValue && x.Id.Equals(teamId)) ?
                TableTeams.Where(x => x.Id.Equals(teamId)).Select(x => x).First().IdCaptain.Value :
                throw new CaptainNotFoundException();
        }

        public string GetPlayerName(long playerId)
        {
            PlayerExist(playerId);
            return TablePlayers.Where(x => x.Id.Equals(playerId)).Select(x => x.Name).ToString();
        }

        public string GetTeamName(long teamId)
        {
            TeamExist(teamId);
            return TableTeams.Where(x => x.Id.Equals(teamId)).Select(x => x.Name).First();
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            TeamExist(teamId);
            return (from tabTeam in TableTeams
                    join tabSoccer in TablePlayers
                    on tabTeam.Id equals tabSoccer.TeamId
                    where tabSoccer.TeamId.Equals(teamId)
                    select tabSoccer.Id).OrderBy(x => x).ToList();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            TeamExist(teamId);
            return TablePlayers.Where(x => x.TeamId.Equals(teamId)).Select(x => x).OrderByDescending(x => x.SkillLevel).ThenBy(x => x.Id).First().Id;
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            TeamExist(teamId);
            return TablePlayers.Where(x => x.TeamId.Equals(teamId)).Select(x => x).OrderBy(x => x.birthDate).ThenBy(x => x.Id).First().Id;
        }

        public List<long> GetTeams()
        {
            return TableTeams.Count() == 0 ? new List<long>() : TableTeams.Select(x => x.Id).OrderBy(x => x).ToList(); ;
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            TeamExist(teamId);
            return TablePlayers.Where(x => x.TeamId.Equals(teamId)).Select(x => x).OrderByDescending(x => x.Salary).ThenBy(x => x.Id).First().Id;
        }

        public decimal GetPlayerSalary(long playerId)
        {
            PlayerExist(playerId);
            return TablePlayers.Where(x => x.Id.Equals(playerId)).Select(x => x.Salary).First();
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
            TeamExist(teamId);
            TeamExist(visitorTeamId);

            return TableTeams.Where(x => x.Id.Equals(teamId)).Select(x => x.MainShirtColor.ToUpper()).First().Equals(TableTeams.Where(x => x.Id.Equals(visitorTeamId)).Select(x => x.MainShirtColor.ToUpper()).First()) ?
                TableTeams.Where(x => x.Id.Equals(visitorTeamId)).Select(x => x.SecondaryShirtColor).First() :
                TableTeams.Where(x => x.Id.Equals(visitorTeamId)).Select(x => x.MainShirtColor).First();

        }
    }
}
