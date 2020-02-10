using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {

        #region Methods

        public async Task<List<VehicleModel>> GetModelsAsync()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM VehicleModel", myConnection);

            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            List<VehicleModel> models = new List<VehicleModel>();

            VehicleModel emp = null;
            while (reader.Read())
            {
                emp = new VehicleModel();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
                emp.MakeId = reader.GetGuid(2);
                models.Add(emp);
            }
            myConnection.Close();
            return await Task.FromResult(models);
        }

        public async Task<List<VehicleModel>> GetModelsByMakerAsync(Guid Id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM VehicleModel WHERE MakeId = @Id", myConnection);

            sqlCmd.Parameters.AddWithValue("@Id", Id);

            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            List<VehicleModel> models = new List<VehicleModel>();

            VehicleModel emp = null;
            while (reader.Read())
            {
                emp = new VehicleModel();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
                emp.MakeId = reader.GetGuid(2);
                models.Add(emp);
            }
            myConnection.Close();
            return await Task.FromResult(models);
        }

        public async Task<VehicleModel> GetModelByIdAsync(Guid id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * from VehicleModel WHERE Id=@Id", myConnection);

            sqlCmd.Parameters.AddWithValue("@Id", id);

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();
            VehicleModel emp = null;
            while (reader.Read())
            {
                emp = new VehicleModel();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
                emp.MakeId = reader.GetGuid(2);
            }
            myConnection.Close();

            return await Task.FromResult(emp);
        }

        public async Task<bool> DeleteModelByIdAsync(Guid id)
        {
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("DELETE FROM VehicleModel WHERE Id=@Id", myConnection);

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

        public async Task<bool> CreateModelByIdAsync(VehicleModel newmodel, Guid id)
        {

            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("INSERT INTO VehicleModel(Name, MakeId) VALUES(@Name, (SELECT Id from VehicleMake WHERE Id = @Id ))", myConnection);

            sqlCmd.Parameters.AddWithValue("@Name", newmodel.Name);
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

        public async Task<bool> UpdateModelByIdAsync(VehicleModel updatemodel, Guid id)
        {
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("UPDATE VehicleModel SET Name = @Name WHERE Id = @Id;", myConnection);

            sqlCmd.Parameters.AddWithValue("@Name", updatemodel.Name);
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