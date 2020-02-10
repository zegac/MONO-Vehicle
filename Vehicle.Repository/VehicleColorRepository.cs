using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class VehicleColorRepository : IVehicleColorRepository
    {
        #region Methods

        public async Task<bool> CreateColorByIdAsync(VehicleColor newcolor, Guid id)
        {
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("INSERT INTO VehicleColor(Name, ModelId) VALUES(@Name, (SELECT Id from VehicleModel WHERE Id = @Id ))", myConnection);

            sqlCmd.Parameters.AddWithValue("@Name", newcolor.Name);
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

        public async Task<bool> DeleteColorByIdAsync(Guid id)
        {
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("DELETE FROM VehicleColor WHERE Id=@Id", myConnection);

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

        public async Task<VehicleColor> GetColorByIdAsync(Guid id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * from VehicleColor WHERE Id=@Id", myConnection);

            sqlCmd.Parameters.AddWithValue("@Id", id);

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();
            VehicleColor emp = null;
            while (reader.Read())
            {
                emp = new VehicleColor();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
            }
            myConnection.Close();

            return await Task.FromResult(emp);
        }

        public async Task<List<VehicleColor>> GetColorsAsync()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM VehicleColor", myConnection);

            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            List<VehicleColor> colors = new List<VehicleColor>();

            VehicleColor emp = null;
            while (reader.Read())
            {
                emp = new VehicleColor();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
                colors.Add(emp);
            }
            myConnection.Close();
            return await Task.FromResult(colors);
        }

        public async Task<bool> UpdateColorByIdAsync(VehicleColor updatecolor, Guid id)
        {
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("UPDATE VehicleColor SET Name = @Name WHERE Id = @Id", myConnection);

            sqlCmd.Parameters.AddWithValue("@Name", updatecolor.Name);
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

        #endregion Methods
    }
}