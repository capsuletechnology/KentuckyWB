using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /*Classe de conexão genérica
     * 
     * Alterar se for 
     * trocar de banco
     * 
     */

    public class Connect
    {
        protected SqlConnection Con;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;

        protected void OpenConnection()
        {
            try
            {
                Con = new SqlConnection("Data Source=SUP02\\SQLEXPRESS;Initial Catalog=kentucky;Integrated Security=True");
                Con.Open();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //Fechar Conexão
        protected void CloseConnection()
        {
            try
            {
                Con.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
