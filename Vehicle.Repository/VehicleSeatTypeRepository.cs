using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class VehicleSeatTypeRepository : IVehicleSeatTypeRepository
    {
        public async Task<List<VehicleSeatType>> GetSeatTypesAsync()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM VehicleSeatType", myConnection);

            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            List<VehicleSeatType> seatTypes = new List<VehicleSeatType>();

            VehicleSeatType emp = null;
            while (reader.Read())
            {
                emp = new VehicleSeatType();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
                seatTypes.Add(emp);
            }
            myConnection.Close();
            return await Task.FromResult(seatTypes);
        }

        public async Task<VehicleSeatType> GetSeatTypeByIdAsync(Guid Id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            myConnection.ConnectionString = cs;

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM VehicleSeatType WHERE Id = @Id", myConnection);

            sqlCmd.Parameters.AddWithValue("@Id", Id);

            myConnection.Open();
            reader = sqlCmd.ExecuteReader();


            VehicleSeatType emp = null;
            while (reader.Read())
            {
                emp = new VehicleSeatType();
                emp.Id = reader.GetGuid(0);
                emp.Name = reader.GetValue(1).ToString();
            }
            myConnection.Close();
            return await Task.FromResult(emp);
        }
    }
}
