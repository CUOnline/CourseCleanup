using Canvas.Clients.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.Clients
{
    public class AccountsClient : ClientBase
    {
        public AccountsClient() : base($"accounts") { }

        /// <summary>
        /// Will return the first user in a list of users.
        /// </summary>
        /// <param name="searchTerm">Search term can be a user id or email address</param>
        /// <returns>User if found.  Null otherwise.</returns>
        public async Task<User> GetUserAsync(string searchTerm)
        {
            ApiPath = ApiController + $@"/self/users?search_term={searchTerm}";
            var result = JArray.Parse(await ExecuteGet(ApiPath));

            User user = result.Count > 0 ? JsonConvert.DeserializeObject<User>(result.First().ToString()) : null;

            return user;
        }

        public async Task<List<Role>> GetAccountRolesForUserAsync(string accountId, string userId)
        {
            var roles = new List<Role>();

            // Get the account
            var account = await Get<Account>(accountId);

            // Get roles for account
            ApiPath = ApiController + $@"/{accountId}/admins?user_id[]={userId}";
            var result = JArray.Parse(await ExecuteGet(ApiPath));
            if(result.Count > 0)
            {
                foreach(var role in result.Children<JObject>())
                {
                    roles.Add(JsonConvert.DeserializeObject<Role>(role.ToString()));
                }
            }

            // Get roles for parent account (recursive)
            if (!string.IsNullOrWhiteSpace(account.ParentAccountId))
            {
                roles.AddRange(await GetAccountRolesForUserAsync(account.ParentAccountId, userId));
            }

            return roles;
        }
    }
}
