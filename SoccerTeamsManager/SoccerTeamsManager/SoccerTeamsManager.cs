using SoccerTeamsManager.Exceptions;
using SoccerTeamsManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SoccerTeamsManager
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        private List<Team> _Teams;
        private List<Player> _Players;

        public SoccerTeamsManager()
        {
            _Teams = new List<Team>();
            _Players = new List<Player>();
        }

        private void TeamExist(long id)
        {
            if (!_Teams.Any(x => x.Id.Equals(id)))
                throw new TeamNotFoundException();
        }

        private void PlayerExist(long id)
        {
            if (!_Teams.Any(x => x.Id.Equals(id)))
                throw new PlayerNotFoundException();
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            _Teams.Add(new Team
            {
                Id = _Teams.Any(x => x.Id.Equals(id)) ? throw new UniqueIdentifierException() : id,
                Name = name,
                CreateDate = createDate,
                MainShirtColor = mainShirtColor,
                SecondaryShirtColor = secondaryShirtColor
            });
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            TeamExist(teamId);
            _Players.Add(new Player
            {
                Id = _Players.Any(x => x.Id.Equals(id)) ? throw new UniqueIdentifierException() : id,
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
            var soccer = _Players.First(x => x.Id == playerId);
            var team = _Teams.First(x => x.Id == soccer.TeamId);
            team.IdCaptain = soccer.Id;
        }

        public long GetTeamCaptain(long teamId)
        {
            TeamExist(teamId);
            return _Teams
                .Any(x => x.IdCaptain.HasValue && x.Id.Equals(teamId)) ?
                _Teams
                .Where(x => x.Id.Equals(teamId)).Select(x => x)
                .First()
                .IdCaptain
                .Value :
                throw new CaptainNotFoundException();
        }

        public string GetPlayerName(long playerId)
        {
            PlayerExist(playerId);
            return _Players
                .Where(x => x.Id.Equals(playerId))
                .Select(x => x.Name)
                .ToString();
        }

        public string GetTeamName(long teamId)
        {
            TeamExist(teamId);
            return _Teams
                .Where(x => x.Id.Equals(teamId))
                .Select(x => x.Name)
                .First();
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            TeamExist(teamId);
            return _Players
                .Where(x => x.TeamId.Equals(teamId))
                .Select(x => x.Id)
                .OrderBy(x => x)
                .ToList();

        }

        public long GetBestTeamPlayer(long teamId)
        {
            TeamExist(teamId);
            return _Players
                .Where(x => x.TeamId.Equals(teamId))
                .Select(x => x)
                .OrderByDescending(x => x.SkillLevel)
                .ThenBy(x => x.Id)
                .First()
                .Id;
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            TeamExist(teamId);
            return _Players
                .Where(x => x.TeamId.Equals(teamId))
                .Select(x => x)
                .OrderBy(x => x.birthDate)
                .ThenBy(x => x.Id)
                .First()
                .Id;
        }

        public List<long> GetTeams()
        {
            return _Teams
                .Count() == 0 ? new List<long>() :
                _Teams
                .Select(x => x.Id)
                .OrderBy(x => x)
                .ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            TeamExist(teamId);
            return _Players
                .Where(x => x.TeamId.Equals(teamId))
                .Select(x => x)
                .OrderByDescending(x => x.Salary)
                .ThenBy(x => x.Id)
                .First()
                .Id;
        }

        public decimal GetPlayerSalary(long playerId)
        {
            PlayerExist(playerId);
            return _Players
                .Where(x => x.Id.Equals(playerId))
                .Select(x => x.Salary)
                .First();
        }

        public List<long> GetTopPlayers(int top)
        {
            return _Players
                 .OrderByDescending(x => x.SkillLevel)
                 .ThenBy(x => x.Id)
                 .Select(x => x.Id)
                 .Take(top)
                 .ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            TeamExist(teamId);
            TeamExist(visitorTeamId);

            return _Teams
                .Where(x => x.Id.Equals(teamId))
                .Select(x => x.MainShirtColor.ToUpper())
                .First()
                .Equals(_Teams.Where(x => x.Id.Equals(visitorTeamId))
                .Select(x => x.MainShirtColor.ToUpper()).First()) ?
                _Teams
                .Where(x => x.Id.Equals(visitorTeamId))
                .Select(x => x.SecondaryShirtColor)
                .First() :
                _Teams
                .Where(x => x.Id.Equals(visitorTeamId))
                .Select(x => x.MainShirtColor)
                .First();

        }
    }
}
