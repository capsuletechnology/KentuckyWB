using KentuckyWebService.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KentuckyWebService.Repository
{
    public class ReportRepository : Connect
    {
        Report report = new Report();

        public List<Report> GetReports(int id)
        {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand("select * from [Report] where Post_ID=@id", Con);
                Cmd.Parameters.AddWithValue("@id", id);
                Dr = Cmd.ExecuteReader();

                List<Report> reports = new List<Report>();
                report = null;

                while (Dr.Read())
                {
                    report = new Report();
                    report.Post = new Post();
                    report.User = new User();

                    report.ReportID = Convert.ToInt32(Dr["ReportID"]);
                    report.Post.PostID = Convert.ToInt32(Dr["Post_ID"]);
                    report.User.UserID = Convert.ToInt32(Dr["User_ID"]);

                    reports.Add(report);
                }

                return reports;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao solicitar reports: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public int GetCountUserId(int id)
        {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand("SELECT COUNT(PostUserID) FROM [Report] WHERE PostUserID=@id", Con);
                Cmd.Parameters.AddWithValue("@id", id);

                int count = (Int32)Cmd.ExecuteScalar();

                return count;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao solicitar reports: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}