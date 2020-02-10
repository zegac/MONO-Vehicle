using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class VehicleEngineTypeRepository : IVehicleEngineTypeRepository
    {
        public async Task<List<VehicleEngineType>> GetEngineTypesAsync()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM VehicleEngineType", myConnection);

            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            List<VehicleEngineType> engineTypes = new List<VehicleEngineType>();

            VehicleEngineType emp = null;
            while (reader.Read())
            {
                emp = new VehicleEngineType();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
                emp.Power = reader.GetInt32(3);
                engineTypes.Add(emp);
            }
            myConnection.Close();
            return await Task.FromResult(engineTypes);
        }

        public async Task<VehicleEngineType> GetEngineTypeByIdAsync(Guid Id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM VehicleEngineType WHERE Id = @Id", myConnection);

            sqlCmd.Parameters.AddWithValue("@Id", Id);

            myConnection.Open();
            reader = sqlCmd.ExecuteReader();


            VehicleEngineType emp = null;
            while (reader.Read())
            {
                emp = new VehicleEngineType();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
                emp.Power = reader.GetInt32(3);
            }
            myConnection.Close();
            return await Task.FromResult(emp);
        }

        public async Task<bool> DeleteEngineTypeByIdAsync(Guid Id)
        {
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("DELETE FROM VehicleEngineType WHERE Id=@Id", myConnection);

            sqlCmd.Parameters.AddWithValue("@Id", Id);

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

        public async Task<bool> CreateEngineTypeByIdAsync(VehicleEngineType newEngineType, Guid Id)
        {

            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("INSERT INTO VehicleEngineType(Name, Power, ModelId) VALUES(@Name, @Power, (SELECT Id from VehicleModel WHERE Id = @Id))", myConnection);

            sqlCmd.Parameters.AddWithValue("@Name", newEngineType.Name);
            sqlCmd.Parameters.AddWithValue("@Power", newEngineType.Power);
            sqlCmd.Parameters.AddWithValue("@Id", Id);

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

        public async Task<bool> UpdateEngineTypeByIdAsync(VehicleEngineType updateEngineType, Guid Id)
        {
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("UPDATE VehicleEngineType SET Name = @Name, Power = @Power WHERE Id = @Id;", myConnection);

            sqlCmd.Parameters.AddWithValue("@Name", updateEngineType.Name);
            sqlCmd.Parameters.AddWithValue("@Power", updateEngineType.Power);
            sqlCmd.Parameters.AddWithValue("@Id", Id);

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
