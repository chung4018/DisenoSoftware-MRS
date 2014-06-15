using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace nutriApp.Models.Interfaces
{
    interface ConexionBD
    {
        private SqlDataAdapter myAdapter;
        private SqlConnection conn;


        //public string CadenaConexion()
        //{
        //se brindan los datos del server IP/NOMBRE para almacenar la conexion en una variable 
        //y utilizarla para realizar las diferentes consultas a la misma
        //    SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
        //   csb.DataSource = @"Data Source=SQLMASTER\BDMASTER;Initial Catalog=proyecto_diseno;Persist Security Info=True;User ID=sa;Password=Mmaudiel2012";
        //  csb.IntegratedSecurity = true;
        // csb.ToString();

        // return csb.DataSource;
        //}

        /// <constructor>
        /// Initialise Connection
        /// </constructor>
        public ConexionBD()
        {
            myAdapter = new SqlDataAdapter();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings
					[@"Data Source=SQLMASTER\BDMASTER;Initial Catalog=proyecto_diseno;Persist Security Info=True;User ID=sa;Password=Mmaudiel2012"].ConnectionString);
        }

        /// <method>
        /// Open Database Connection if Closed or Broken
        /// </method>
        private SqlConnection abrirConexion()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        /// <method>
        /// Select Query
        /// </method>
        public DataTable selectConsulta(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = abrirConexion();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();                
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return null;
            }
            finally
            {

            }
            return dataTable;
        }

        /// <method>
        /// Insert Query
        /// </method>
        public bool deleteConsulta(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = abrirConexion();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeInsertQuery - Query: " + _query + " \nException: \n" + e.StackTrace.ToString());
                return false;
            }
            finally
            {
            }
            return true;
        }

        /// <method>
        /// Update Query
        /// </method>
        public bool updateConsulta(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = abrirConexion();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeUpdateQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            finally
            {
            }
            return true;
        }

    }
}