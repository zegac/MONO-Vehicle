using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {

        #region Methods
        public async Task<List<IVehicleModel>> GetModelsForSpecificMaker(Guid id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * from VehicleModel WHERE MakeId=@Id", myConnection);

            sqlCmd.Parameters.AddWithValue("@Id", id);

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();
            List<IVehicleModel> models = new List<IVehicleModel>();

            VehicleModel emp = null;
            while (reader.Read())
            {
                emp = new VehicleModel();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
                models.Add(emp);
            }
            myConnection.Close();
            return await Task.FromResult(models);
        }
        public async Task<List<VehicleMake>> GetMakersAsync()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM VehicleMake", myConnection);

            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            List<VehicleMake> makers = new List<VehicleMake>();

            VehicleMake emp = null;
            while (reader.Read())
            {
                emp = new VehicleMake();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
                makers.Add(emp);
            }
            myConnection.Close();
            return await Task.FromResult(makers);
        }

        public async Task<VehicleMake> GetMakerByIdAsync(Guid id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * from VehicleMake WHERE Id=@Id", myConnection);

            sqlCmd.Parameters.AddWithValue("@Id", id);

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();
            VehicleMake emp = null;
            while (reader.Read())
            {
                emp = new VehicleMake();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
            }
            myConnection.Close();

            return await Task.FromResult(emp);
        }

        public async Task<bool> DeleteMakerByIdAsync(Guid id)
        {

            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("DELETE FROM VehicleMake WHERE Id=@Id", myConnection);

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

        public async Task<bool> CreateMakerByIdAsync(VehicleMake newmaker)
        {

            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("INSERT INTO VehicleMake(Name) Values (@Name)", myConnection);

            sqlCmd.Parameters.AddWithValue("@Name", newmaker.Name);

            myConnection.Open();
            int rowAdded = sqlCmd.ExecuteNonQuery();
            myConnection.Close();

            if (rowAdded == 0)
            {
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }


        public async Task<bool> UpdateMakerByIdAsync(VehicleMake updatemaker, Guid id)
        {
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("UPDATE VehicleMake SET Name = @Name WHERE Id = @Id", myConnection);

            sqlCmd.Parameters.AddWithValue("@Name", updatemaker.Name);
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
