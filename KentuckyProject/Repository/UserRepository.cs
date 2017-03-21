using KentuckyWebService.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KentuckyWebService.Repository
{
    public class UserRepository : Connect
    {
        User user;
        LoginRepository login = new LoginRepository();

        public User SelectOneAnon(int id)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand("select * from [User] where Userid=@id", Con);
                Cmd.Parameters.AddWithValue("@id", id);
                Dr = Cmd.ExecuteReader();
                user = null;

                if (Dr.Read())
                {
                    user = new User();

                    user.Userid = Convert.ToInt32(Dr["Userid"]);
                    user.Rating = Convert.ToDouble(Dr["Rating"]);
                    //user.UserFullName = Convert.ToString(Dr["UserFullName"]);
                    //user.Email = Convert.ToString(Dr["Email"]);
                    //user.Telefone = Convert.ToString(Dr["Telefone"]);
                    //user.Login = login.SelectOne(Convert.ToInt32(Dr["Login_id"]));
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao encontrar usuario: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public User SelectOneNoLogin(int id)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand("select * from [User] where Userid=@id", Con);
                Cmd.Parameters.AddWithValue("@id", id);
                Dr = Cmd.ExecuteReader();
                user = null;

                if (Dr.Read())
                {
                    user = new User();

                    user.Userid = Convert.ToInt32(Dr["Userid"]);
                    user.UserFullName = Convert.ToString(Dr["UserFullName"]);
                    user.Email = Convert.ToString(Dr["Email"]);
                    user.Phone = Convert.ToString(Dr["Telefone"]);
                    //user.Login = login.SelectOne(Convert.ToInt32(Dr["Login_id"]));
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao encontrar usuario: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public User SelectOneLogin(int id)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand("select * from [User] where Userid=@id", Con);
                Cmd.Parameters.AddWithValue("@id", id);
                Dr = Cmd.ExecuteReader();
                user = null;

                if (Dr.Read())
                {
                    user = new User();

                    user.Userid = Convert.ToInt32(Dr["Userid"]);
                    user.UserFullName = Convert.ToString(Dr["UserFullName"]);
                    user.Email = Convert.ToString(Dr["Email"]);
                    user.Phone = Convert.ToString(Dr["Telefone"]);
                    user.Login = login.SelectOne(Convert.ToInt32(Dr["Login_id"]));
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao encontrar usuario: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public User SelectOneLogin(User user)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand("select * from [User] where UserFullName=@FullName", Con);
                Cmd.Parameters.AddWithValue("@FullName", user.UserFullName);
                Dr = Cmd.ExecuteReader();
                user = null;

                if (Dr.Read())
                {
                    user = new User();

                    user.Userid = Convert.ToInt32(Dr["Userid"]);
                    user.UserFullName = Convert.ToString(Dr["UserFullName"]);
                    user.Email = Convert.ToString(Dr["Email"]);
                    user.Phone = Convert.ToString(Dr["Telefone"]);
                    user.Login = login.SelectOne(Convert.ToInt32(Dr["Login_id"]));
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao encontrar usuario: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void CreateUser(User user)
        {
            try
            {
                login.NewLogin(user.Login);                

                OpenConnection();

                Cmd = new SqlCommand("insert into [User](UserFullName, Email, Telefone, Rating, Login_id) values(@UserFullName, @Email, @Telefone, @Rating, @Login_id)", Con);

                Cmd.Parameters.AddWithValue("@UserFullName", user.UserFullName);
                Cmd.Parameters.AddWithValue("@Email", user.Email);
                Cmd.Parameters.AddWithValue("@Telefone", user.Phone);
                Cmd.Parameters.AddWithValue("@Rating", user.Rating);
                Cmd.Parameters.AddWithValue("@Login_id", (login.SelectOneWNick(user.Login)).Loginid);

                Cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir cliente: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

        }
    }
}