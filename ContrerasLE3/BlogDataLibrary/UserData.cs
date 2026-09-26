using BlogDataLibrary.Database;
using BlogDataLibrary.Models;
using System.Linq;

namespace BlogDataLibrary
{
    public class UserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public UserModel? GetUserById(int id)
        {
            string sql = @"SELECT Id, UserName, FirstName, LastName, Password
                           FROM dbo.Users
                           WHERE Id = @Id;";

            var parameters = new { Id = id };

            var users = _db.LoadData<UserModel, dynamic>(
                sql,
                parameters,
                "Default",
                false);

            return users.FirstOrDefault();
        }

        public int CreateUser(UserModel user)
        {
            string sql = @"INSERT INTO dbo.Users
                           (UserName, FirstName, LastName, Password)
                           VALUES
                           (@UserName, @FirstName, @LastName, @Password);";

            _db.SaveData(
                sql,
                user,
                "Default",
                false);

            return 1;
        }

        public int UpdateUser(UserModel user)
        {
            string sql = @"UPDATE dbo.Users
                           SET UserName = @UserName,
                               FirstName = @FirstName,
                               LastName = @LastName,
                               Password = @Password
                           WHERE Id = @Id;";

            _db.SaveData(
                sql,
                user,
                "Default",
                false);

            return 1;
        }

        public int DeleteUser(int id)
        {
            string sql = @"DELETE FROM dbo.Users
                           WHERE Id = @Id;";

            var parameters = new { Id = id };

            _db.SaveData(
                sql,
                parameters,
                "Default",
                false);

            return 1;
        }
    }
}