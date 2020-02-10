using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class VehicleBodyStyleRepository : IVehicleBodyStyleRepository
    {

        public async Task<List<VehicleBodyStyle>> GetBodyStylesAsync()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM VehicleBodyStyle", myConnection);

            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            List<VehicleBodyStyle> BodyStyles = new List<VehicleBodyStyle>();

            VehicleBodyStyle emp = null;
            while (reader.Read())
            {
                emp = new VehicleBodyStyle();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
                emp.ModelId = reader.GetGuid(2);
                BodyStyles.Add(emp);
            }
            myConnection.Close();
            return await Task.FromResult(BodyStyles);
        }

        public async Task<VehicleBodyStyle> GetBodyStylesByIdAsync(Guid id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * from VehicleBodyStyle WHERE Id=@Id", myConnection);

            sqlCmd.Parameters.AddWithValue("@Id", id);

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();
            VehicleBodyStyle emp = null;
            while (reader.Read())
            {
                emp = new VehicleBodyStyle();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
                emp.ModelId = reader.GetGuid(2);
            }
            myConnection.Close();

            return await Task.FromResult(emp);
        }

        public async Task<bool> DeleteBodyStylesByIdAsync(Guid id)
        {
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("DELETE FROM VehicleBodyStyle WHERE Id=@Id", myConnection);

            sqlCmd.Parameters.AddWithValue("@Id", id);

            myConnection.Open();
            int rowDeleted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();

            if (rowDeleted == 0)
            {
                return await Task.FromResult(false);
            }
            else
            {
                return await Task.FromResult(true);
            }
        }

        public async Task<bool> CreateBodyStylesByIdAsync(VehicleBodyStyle newBodyStyles, Guid id)
        {

            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("INSERT INTO VehicleBodyStyle(Name, ModelId) VALUES(@Name, (SELECT Id from VehicleModel WHERE Id = @Id ))", myConnection);

            sqlCmd.Parameters.AddWithValue("@Name", newBodyStyles.Name);
            sqlCmd.Parameters.AddWithValue("@Id", id);

            myConnection.Open();
            int rowAdded = sqlCmd.ExecuteNonQuery();
            myConnection.Close();

            if (rowAdded == 0)
            {
                return await Task.FromResult(false);
            }
            else
            {
                return await Task.FromResult(true);
            }
        }

        public async Task<bool> UpdateBodyStylesByIdAsync(VehicleBodyStyle updateBodyStyles, Guid id)
        {
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("UPDATE VehicleBodyStyle SET Name = @Name WHERE Id = @Id;", myConnection);

            sqlCmd.Parameters.AddWithValue("@Name", updateBodyStyles.Name);
            sqlCmd.Parameters.AddWithValue("@Id", id);

            myConnection.Open();
            int rowUpdated = sqlCmd.ExecuteNonQuery();
            myConnection.Close();

            if (rowUpdated == 0)
            {
                return await Task.FromResult(false);
            }
            else
            {
                return await Task.FromResult(true);
            }
        }


    }
}
