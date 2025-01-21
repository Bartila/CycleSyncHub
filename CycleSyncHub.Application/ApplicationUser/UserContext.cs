using System.Data.SqlClient;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;




namespace CycleSyncHub.Application.ApplicationUser
{

    public interface IUserContext
    {
        Task<IEnumerable<CurrentUser>> GetAll(); 
        CurrentUser? GetCurrentUser();        
        bool IsAdmin();
        Task DeleteUsers(string userId);

    }

    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [Obsolete]
        public async Task<IEnumerable<CurrentUser>> GetAll()
        {
            var users = new List<CurrentUser>();

            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=CycleSyncHubDb;Integrated Security=True;";


            var query = @"
              SELECT 
              u.Id AS UserId,
              u.Email,
               r.Name AS RoleName
            FROM AspNetUsers u
             LEFT JOIN AspNetUserRoles ur ON u.Id = ur.UserId
             LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {

                        var userDictionary = new Dictionary<string, CurrentUser>();

                        while (await reader.ReadAsync())
                        {
                            var userId = reader["UserId"].ToString()!;
                            var email = reader["Email"].ToString()!;

                            if (!userDictionary.ContainsKey(userId))
                            {
                                userDictionary[userId] = new CurrentUser(userId, email, new List<string>());
                            }

                          ;
                        }

                        users = userDictionary.Values.ToList();
                    }
                }
            }

            return users;
        }


        public CurrentUser? GetCurrentUser()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("Context user is not present");
            }

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

            if (id == null || email == null)
            {
                return null;
            }

            return new CurrentUser(id, email, roles);
        }


        public bool IsAdmin()
        {
            var user = GetCurrentUser();
            return user != null && user.Email == "admin@gmail.com";
        }
    

    public async Task DeleteUsers(string userId)
    {
            using (var connection = new SqlConnection("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = CycleSyncHubDb; Integrated Security = True;"))
            {
                var query = "DELETE FROM AspNetUsers WHERE Id = @UserId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

    }
