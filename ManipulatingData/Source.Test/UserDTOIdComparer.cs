using Source.DTOs;
using System.Collections.Generic;

namespace Source.Test
{
    public class UserDTOIdComparer : IEqualityComparer<UserDTO>
    {
        public bool Equals(UserDTO x, UserDTO y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(UserDTO obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}