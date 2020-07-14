using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private CodenationContext _context;
        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            return _context
                .Candidates
                .Where(x => x.Acceleration.Name.Equals(name))
                .Select(x => x.User)
                .ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            return _context
                .Candidates
                .Where(x => x.CompanyId.Equals(companyId))
                .Select(x => x.User)
                .Distinct()
                .ToList();
        }

        public User FindById(int id)
        {
            return _context
                .Users
                .Where(x => x.Id.Equals(id))
                .FirstOrDefault();
        }

        public User Save(User user)
        {
            if (user.Id.Equals(0))
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            else
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
                return user;
            }
        }
    }
}
