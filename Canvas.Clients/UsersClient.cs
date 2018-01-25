using Canvas.Clients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.Clients
{
    public class UsersClient : ClientBase
    {
        public UsersClient() : base($"users") { }

        public async Task<UserProfile> GetUserProfile(string userId)
        {
            ApiPath = ApiController + $@"/{userId}/profile";
            return await ExecuteGet<UserProfile>(ApiPath);
        }
    }
}
