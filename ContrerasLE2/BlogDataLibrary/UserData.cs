using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlogDataLibrary.Models;

namespace BlogDataLibrary
{
    public class UserData
    {
        public static UserModel? GetUserById(int id)
        {
            string sql = @"SELECT Id, UserName, FirstName, LastName, Password
               FROM dbo.Users
               WHERE Id = @Id;";

            var parameters = new { Id = id };

            var users = SqlDataAccess.LoadData<UserModel, dynamic>(
                sql,
                parameters);

            return users.FirstOrDefault();
        }

        public static int CreateUser(UserModel user)
        {
            string sql = @"INSERT INTO dbo.Users
                   (UserName, FirstName, LastName, Password)
                   VALUES
                   (@UserName, @FirstName, @LastName, @Password);";

            return SqlDataAccess.SaveData(sql, user);
        }
        public static int UpdateUser(UserModel user)
        {
            string sql = @"UPDATE dbo.Users
                   SET UserName = @UserName,
                       FirstName = @FirstName,
                       LastName = @LastName,
                       Password = @Password
                   WHERE Id = @Id;";

            return SqlDataAccess.SaveData(sql, user);
        }

        public static int DeleteUser(int id)
        {
            string sql = @"DELETE FROM dbo.Users
                   WHERE Id = @Id;";

            var parameters = new { Id = id };

            return SqlDataAccess.SaveData(sql, parameters);
        }
    }
}
