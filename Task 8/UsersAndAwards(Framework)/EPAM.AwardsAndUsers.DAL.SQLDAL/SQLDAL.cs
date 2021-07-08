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

        public IEnumerable<Award> GetAllAwards()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_getAllAwards = "GetAllAwards";
                SqlCommand command = new SqlCommand(procedure_getAllAwards, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Award(
                        ID: (Guid)reader["id"],
                        awardTitle: (string)reader["Title"]
                    );
                }
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
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

        public IEnumerable<AuthData> LoadAuthData()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_getAllAuthData = "GetAllAuthData";
                SqlCommand command = new SqlCommand(procedure_getAllAuthData, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new AuthData(
                        id: (Guid)reader[0],
                        hash: (int)reader[1]
                    );
                }
            }
        }

        public Data LoadData()
        {
            IEnumerable<AwardAndUsersData> allData = LoadAwardsAndUsers();
            Data data = new Data();
            foreach (var item in allData)
            {
                if (data.DataValue.ContainsKey(item.UserID))
                    data.AddData(item.UserID, item.AwardID);
                else
                {
                    data.AddKey(item.UserID);
                    data.AddData(item.UserID, item.AwardID);
                }
            }
            return data;
        }

        public IEnumerable<RoleData> LoadRolesData ()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_getRoleByUsername = "getRoles";
                SqlCommand command = new SqlCommand(procedure_getRoleByUsername, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new RoleData(
                        Username: (string)reader["Name"],
                        RoleName: (string)reader["Role"]
                    );
                }
            }
        }

        public bool RecordAuthToFile(AuthData newData)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_createAuthorizationData = "CreateAuthData";
                SqlCommand command = new SqlCommand(procedure_createAuthorizationData, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id_User", newData.UserID);
                command.Parameters.AddWithValue("@Password", newData.UserPasswordHash);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        } 

        public bool RecordAwardToFile(Award award)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_createAward = "CreateAward";
                SqlCommand command = new SqlCommand(procedure_createAward, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", award.id);
                command.Parameters.AddWithValue("@Title", award.Title);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool RecordData(Guid userID, Guid awardID)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_addAwardToUser = "AddAwardToUser";
                SqlCommand command = new SqlCommand(procedure_addAwardToUser, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id_User", userID);
                command.Parameters.AddWithValue("@id_Award", awardID);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool RemoveAwardFromTableWithUsersAndAwards(Guid id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_removeAwardFromUsersAndAwards = "RemoveAwardFromUsers_AwardsTable";
                SqlCommand command = new SqlCommand(procedure_removeAwardFromUsersAndAwards, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
                throw new InvalidOperationException("Cannot find Award with such ID = " + id);
            }
        }

        public bool RecordRolesToFile(RoleData roleData)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_createRole = "CreateRole";
                SqlCommand command = new SqlCommand(procedure_createRole, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Name", roleData.Usernames[0]);
                command.Parameters.AddWithValue("@Role", roleData.RoleNames[0]);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool RecordUserToFile(User user)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_createUser = "CreateUser";
                SqlCommand command = new SqlCommand(procedure_createUser, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", user.id);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@BirthDate", user.DateOfBirth);
                command.Parameters.AddWithValue("@Age", user.Age);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool RemoveAuthData(Guid id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_removeAuthData = "RemoveAuthData";
                SqlCommand command = new SqlCommand(procedure_removeAuthData, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
                throw new InvalidOperationException("Cannot find User with such ID = " + id);
            }
        }

        public bool RemoveAward(Guid id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_removeAward = "RemoveAward";
                SqlCommand command = new SqlCommand(procedure_removeAward, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
                throw new InvalidOperationException("Cannot find Award with such ID = " + id);
            }
        }

        public bool RemoveRolesData(string username)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_removeRole = "RemoveRole";
                SqlCommand command = new SqlCommand(procedure_removeRole, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Name", username);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
                throw new InvalidOperationException("Cannot find User with such username = " + username);
            }
        }

        public bool RemoveUser(Guid id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_removeUser = "RemoveUser";
                SqlCommand command = new SqlCommand(procedure_removeUser, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
                throw new InvalidOperationException("Cannot find User with such ID = " + id);
            }
        }

        public bool RemoveData (User user)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_removeUsersAndAwardsData = "RemoveUserFromUsers_AwardsTable";
                SqlCommand command = new SqlCommand(procedure_removeUsersAndAwardsData, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", user.id);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
                throw new InvalidOperationException("Cannot find User with such ID = " + id);
            }
        }

        public bool SetBase()
        {
            User user = new User("Administrator", new DateTime(1990, 5, 11));

            if (FindUserByName(user.Name))
                return true;
            else
            {
                if (RecordUserToFile(user) && RecordRolesToFile(new RoleData(new string[] { user.Name }, new string[] { "Administrator" })) 
                                           && RecordAuthToFile(new AuthData(user.id, "admin".GetHashCode())))
                    return true;
                else
                    return false;
            }
        }

        public bool UpdateAward(Award award)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_updateAward = "UpdateAward";
                SqlCommand command = new SqlCommand(procedure_updateAward, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", award.id);
                command.Parameters.AddWithValue("@Title", award.Title);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool UpdateUser(User user)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_updateUser = "UpdateUser";
                SqlCommand command = new SqlCommand(procedure_updateUser, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", user.id);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@BirthDate", user.DateOfBirth);
                command.Parameters.AddWithValue("@Age", user.Age);
                _connection.Open();
                var result = command.ExecuteNonQuery();
                return result > 0;
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

        private IEnumerable<AwardAndUsersData> LoadAwardsAndUsers ()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var procedure_getAllAwardsAndUsersData = "GetAllAwardsAndUsers";
                SqlCommand command = new SqlCommand(procedure_getAllAwardsAndUsersData, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new AwardAndUsersData(
                        userid: (Guid)reader[0],
                        awardid: (Guid)reader[1]
                    );
                }
            }
        }
    }
}
