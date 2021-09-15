using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplyDeliciousBarEvents.Data;
using SimplyDeliciousBarEvents.Models;
using Microsoft.EntityFrameworkCore;

namespace SimplyDeliciousBarEvents.Models
{
    public class DatabaseAccess : IDisposable
    {
        private SqlConnectionStringBuilder _sqlsb;
        public List<LocationModel> _locations;
        public DatabaseAccess()
        {
            //harcoded for testing.
            //TODO: pull from EF.
            string localConnection = @"Server=(localdb)\mssqllocaldb;Database=aspnet-SimplyDeliciousBarEvents-80C9A4C5-B657-4B85-8D9A-42B3F06C5167;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlSb = new SqlConnectionStringBuilder(localConnection);
        }

        public SqlConnectionStringBuilder SqlSb
        {
            get { return _sqlsb; }
            set { _sqlsb = value; }
        }
        
        //TODO: Create Locations View
        public DataTable GetLocations()
        {
            _locations = new List<LocationModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = $"SELECT * FROM vw_Locations";
                    command.CommandTimeout = 30;

                    DataTable dt = new DataTable();
                    SqlDataAdapter a = new SqlDataAdapter(command);
                    a.Fill(dt);

                    conn.Close();
                    return dt;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }

        }

        //TODO: Create Clients View
        public DbDataReader GetClients()
        {
            using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM vw_Clients";
                command.CommandTimeout = 30;

                return command.ExecuteReader();
            }
        }

        //TODO: Create Employees View
        public DbDataReader GetEmployees()
        {
            using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM vw_Employees";
                command.CommandTimeout = 30;

                return command.ExecuteReader();
            }
        }

        //TODO: Create Menu View
        public DbDataReader GetMenu()
        {
            using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM vw_Menu";
                command.CommandTimeout = 30;

                return command.ExecuteReader();
            }
        }

        //TODO: Create sp_CreateLocation and sp_CreateAddress
        public void CreateLocation(string locationName, string locationOwnerFirstName, string locationOwnerLastName, string locationContactNumber,
            string address1, string address2, string city, string state, string zipCode)
        {
            using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
            {
                conn.Open();
                SqlCommand locationCommand = new SqlCommand();
                locationCommand.Connection = conn;
                locationCommand.CommandType = CommandType.StoredProcedure;
                locationCommand.CommandText = "sp_CreateLocation";
                locationCommand.CommandTimeout = 30;

                locationCommand.Parameters.AddRange(
                    new[]
                    {
                        new SqlParameter("@LocationName", SqlDbType.VarChar) { Value = locationName  },
                        new SqlParameter("@LocationOwnerFirstName", SqlDbType.VarChar) { Value = locationOwnerFirstName },
                        new SqlParameter("@LocationOwnerLastName", SqlDbType.VarChar) { Value = locationOwnerLastName },
                        new SqlParameter("@LocationContactNumber", SqlDbType.VarChar) { Value = locationContactNumber },
                        new SqlParameter("@LocationName", SqlDbType.VarChar) { Value = locationName  }
                    });

                locationCommand.ExecuteNonQuery();
                conn.Close();
            }

            if (!string.IsNullOrEmpty(address1) || !string.IsNullOrEmpty(address2) || !string.IsNullOrEmpty(city) ||
                !string.IsNullOrEmpty(state) || !string.IsNullOrEmpty(zipCode))
            {
                CreateAddress(address1, address2, city, state, zipCode);
            }
        }

        //TODO: Create sp_UpdateLocation
        public void UpdateLocation(string locationName, string locationOwnerFirstName, string locationOwnerLastName, string locationContactNumber,
            string address1, string address2, string city, string state, string zipCode)
        {
            using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
            {
                conn.Open();
                SqlCommand locationCommand = new SqlCommand();
                locationCommand.Connection = conn;
                locationCommand.CommandType = CommandType.StoredProcedure;
                locationCommand.CommandText = "sp_UpdateLocation";
                locationCommand.CommandTimeout = 30;

                locationCommand.Parameters.AddRange(
                    new[]
                    {
                        new SqlParameter("@LocationName", SqlDbType.VarChar) { Value = locationName  },
                        new SqlParameter("@LocationOwnerFirstName", SqlDbType.VarChar) { Value = locationOwnerFirstName },
                        new SqlParameter("@LocationOwnerLastName", SqlDbType.VarChar) { Value = locationOwnerLastName },
                        new SqlParameter("@LocationContactNumber", SqlDbType.VarChar) { Value = locationContactNumber },
                        new SqlParameter("@LocationName", SqlDbType.VarChar) { Value = locationName  }
                    });

                locationCommand.ExecuteNonQuery();
                conn.Close();
            }

            if (!string.IsNullOrEmpty(address1) || !string.IsNullOrEmpty(address2) || !string.IsNullOrEmpty(city) ||
                !string.IsNullOrEmpty(state) || !string.IsNullOrEmpty(zipCode))
            {
                CreateAddress(address1, address2, city, state, zipCode);
            }
        }

        //TODO: Create sp_CreateAddress
        public void CreateAddress(string address1, string address2, string city, string state, string zipCode)
        {
            using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
            {
                conn.Open();
                SqlCommand addressCommand = new SqlCommand();
                addressCommand.Connection = conn;
                addressCommand.CommandType = CommandType.StoredProcedure;
                addressCommand.CommandText = "sp_CreateAddress";
                addressCommand.CommandTimeout = 30;

                addressCommand.Parameters.AddRange(
                    new[]
                    {
                        new SqlParameter("@Address1", SqlDbType.VarChar) { Value = address1 },
                        new SqlParameter("@Address2", SqlDbType.VarChar) { Value = address2 },
                        new SqlParameter("@City", SqlDbType.VarChar) { Value = city},
                        new SqlParameter("@State", SqlDbType.VarChar) { Value = state },
                        new SqlParameter("@ZipCode", SqlDbType.VarChar) { Value = zipCode  }
                    });

                addressCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        //TODO: Create sp_UpdateAddress
        public void UpdateAddress(string address1, string address2, string city, string state, string zipCode)
        {
            using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
            {
                conn.Open();
                SqlCommand addressCommand = new SqlCommand();
                addressCommand.Connection = conn;
                addressCommand.CommandType = CommandType.StoredProcedure;
                addressCommand.CommandText = "sp_UpdateAddress";
                addressCommand.CommandTimeout = 30;

                addressCommand.Parameters.AddRange(
                    new[]
                    {
                        new SqlParameter("@Address1", SqlDbType.VarChar) { Value = address1 },
                        new SqlParameter("@Address2", SqlDbType.VarChar) { Value = address2 },
                        new SqlParameter("@City", SqlDbType.VarChar) { Value = city},
                        new SqlParameter("@State", SqlDbType.VarChar) { Value = state },
                        new SqlParameter("@ZipCode", SqlDbType.VarChar) { Value = zipCode  }
                    });

                addressCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public DataTable GetEventSheet(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = $"sp_GetEventSheet"; 
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });
                    command.CommandTimeout = 30;


                    DataTable dt = new DataTable();
                    SqlDataAdapter a = new SqlDataAdapter(command);
                    a.Fill(dt);          

                    conn.Close();
                    return dt;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }
        public void Dispose()
        {
            if (this != null)
            {
                this.Dispose();
            }
        }
    }
}
