using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class VehicleAdditionalEquipmentRepository : IVehicleAdditionalEquipmentRepository
    {
        #region Methods

        public async Task<List<VehicleAdditionalEquipment>> GetAdditionalEquipmentAsync()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM VehicleAdditionalEquipment", myConnection);

            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            List<VehicleAdditionalEquipment> AdditionalEquipment = new List<VehicleAdditionalEquipment>();

            VehicleAdditionalEquipment emp = null;
            while (reader.Read())
            {
                emp = new VehicleAdditionalEquipment();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
                emp.ModelId = reader.GetGuid(2);
                AdditionalEquipment.Add(emp);
            }
            myConnection.Close();
            return await Task.FromResult(AdditionalEquipment);
        }

        public async Task<VehicleAdditionalEquipment> GetAdditionalEquipmentByIdAsync(Guid id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * from VehicleAdditionalEquipment WHERE Id=@Id", myConnection);

            sqlCmd.Parameters.AddWithValue("@Id", id);

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();
            VehicleAdditionalEquipment AdditionalEquipment = null;
            while (reader.Read())
            {
                AdditionalEquipment = new VehicleAdditionalEquipment();
                AdditionalEquipment.Id = reader.GetGuid(0);
                AdditionalEquipment.Name = reader.GetValue(1).ToString();
                AdditionalEquipment.ModelId = reader.GetGuid(2);
            }
            myConnection.Close();

            return await Task.FromResult(AdditionalEquipment);
        }

        #endregion Methods
    }
}