using KentuckyWebService.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KentuckyWebService.Repository
{
    public class LoginRepository : Connect
    {
        Login login;

        public Login SelectOne(int id)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand("select * from Login where LoginID=@id", Con);
                Cmd.Parameters.AddWithValue("@id", id);
                Dr = Cmd.ExecuteReader();
                login = null;

                if (Dr.Read())
                {
                    login = new Login();

                    login.LoginID = Convert.ToInt32(Dr["LoginID"]);
                    login.User = Convert.ToString(Dr["UserNick"]);
                    login.Password = Convert.ToString(Dr["Password"]);                    
                }
                return login;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao encontrar login: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public Login SelectOneWNick(Login login)
        {
            try
            {
                OpenConnection();

                Cmd = new SqlCommand("select * from Login where UserNick=@userNick", Con);
                Cmd.Parameters.AddWithValue("@userNick", login.User);
                Dr = Cmd.ExecuteReader();
                login = null;

                if (Dr.Read())
                {
                    login = new Login();

                    login.LoginID = Convert.ToInt32(Dr["LoginID"]);
                    login.User = Convert.ToString(Dr["UserNick"]);
                    login.Password = Convert.ToString(Dr["Password"]);
                }
                return login;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao encontrar login: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void NewLogin(Login login)
        {
            try
            {
                OpenConnection();
                
                Cmd = new SqlCommand("insert into Login(UserNick, Password) values(@UserNick, @Password)", Con);
                
                Cmd.Parameters.AddWithValue("@UserNick", login.User);
                Cmd.Parameters.AddWithValue("@Password", login.Password);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar novo login" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


    }
}