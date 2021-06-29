using EPAM.AwardsAndUsers.Common.Entities;
using EPAM.AwardsAndUsers.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace EPAM.AwardsAndUsers.DAL.SQLDAL
{
    public class SQLDAL : IDAL
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public List<Award> GetAllAwards()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                List<User> users = new List<User> { };
                var procedure_getAllUsers = "GetAllUsers";
                SqlCommand command = new SqlCommand(procedure_getAllUsers, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new User(
                        ID: (Guid)reader["id"],
                        username: (string)reader["Name"],
                        birthDate: (string)reader["BirthDate"],
                        userAge: (int)reader["Age"]
                    );
                }
            }
        }

        public List<AuthData> LoadAuthData()
        {
            throw new NotImplementedException();
        }

        public Data LoadData()
        {
            throw new NotImplementedException();
        }

        public List<RoleData> LoadRolesData()
        {
            throw new NotImplementedException();
        }

        public void RecordAuthToFile(AuthData newData)
        {
            throw new NotImplementedException();
        }

        public void RecordAwardToFile(Award award)
        {
            throw new NotImplementedException();
        }

        public void RecordData(Data data)
        {
            throw new NotImplementedException();
        }

        public void RecordRolesToFile(RoleData roleData)
        {
            throw new NotImplementedException();
        }

        public void RecordUserToFile(User user)
        {
            throw new NotImplementedException();
        }

        public void RemoveAuthData(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAward(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveRolesData(string username)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool SetBase()
        {
            User user = new User("Administrator", new DateTime(1990, 5, 11));

            if (FindUserByName(user.Name))
                return true;
            else
            {
                if (CreateAdmin(user))
                {
                    if (CreateAdminRole(user))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        private bool FindUserByName(string username)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_findUserByName = "FindUserByNameFromUsers";
                SqlCommand command = new SqlCommand(procedure_findUserByName, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Name", username);
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (username == (string)reader[0])
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private bool CreateAdmin(User admin)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_createAdmin = "CreateAdmin";
                SqlCommand command = new SqlCommand(procedure_createAdmin, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", admin.id);
                command.Parameters.AddWithValue("@Name", admin.Name);
                command.Parameters.AddWithValue("@BirthDate", admin.DateOfBirth);
                command.Parameters.AddWithValue("@Age", admin.Age);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        private bool CreateAdminRole (User admin)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_createAdminRole = "CreateAdminRole";
                SqlCommand command = new SqlCommand(procedure_createAdminRole, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id_User", admin.id);
                command.Parameters.AddWithValue("@Name", admin.Name);
                command.Parameters.AddWithValue("@Role", "Administrator");
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
