using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace TarimCan.DataAccessLayer
{
    public class MSSqlDataAccess
    {
        private SqlConnection sqlConn;

        public MSSqlDataAccess()
        {
            sqlConn = new SqlConnection(ConfigurationManager.AppSettings["DBConnectionString"]);

            SqlConnection.ClearPool(sqlConn);
            SqlConnection.ClearAllPools();
            sqlConn.Open();
        }

        public DataTable GetDataTable(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, sqlConn);
            cmd.Connection.Close();
            DataTable dt = new DataTable();
            cmd.Connection.Open();
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();
            sqlConn.Close();
            return dt;
        }

        private DataTable GetDataTable(SqlCommand cmd)
        {
            cmd.Connection.Close();
            DataTable dt = new DataTable();
            cmd.Connection.Open();
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();
            sqlConn.Close();
            return dt;
        }

        public void ExecuteSQLString(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, sqlConn);
            cmd.Connection.Close();
            cmd.Connection.Open();
            cmd.ExecuteReader();
            cmd.Connection.Close();
            sqlConn.Close();
        }

        public void ExcuteSqlCommand(string spName, List<SqlParameter> sqlParams)
        {
            SqlCommand command = new SqlCommand(spName, sqlConn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (var item in sqlParams)
            {
                command.Parameters.Add(item);
            }

            command.Connection.Close();
            command.Connection.Open();
            command.ExecuteReader();
            command.Connection.Close();
            sqlConn.Close();
        }

        public T ExcuteReturnObject<T>(string spName, List<SqlParameter> sqlParams)
        {
            SqlCommand command = new SqlCommand(spName, sqlConn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (var item in sqlParams)
            {
                command.Parameters.Add(item);
            }

            List<T> data = new List<T>();
            foreach (DataRow row in GetDataTable(command).Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            sqlConn.Close();

            if (data.Count > 0)
            {
                return data[0];
            }
            else
            {
                return default(T);
            }
        }

        public List<T> ExecuteObject<T>(string spName, List<SqlParameter> sqlParams)
        {
            SqlCommand command = new SqlCommand(spName, sqlConn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (var item in sqlParams)
            {
                command.Parameters.Add(item);
            }

            List<T> data = new List<T>();
            foreach (DataRow row in GetDataTable(command).Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            sqlConn.Close();
            return data;
        }

        public List<T> ExecuteObject<T>(string sql)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in GetDataTable(sql).Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            sqlConn.Close();
            return data;
        }

        private T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        if (dr[column.ColumnName] != DBNull.Value)
                        {
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        }
                        else
                            continue;
                }
            }
            sqlConn.Close();
            return obj;
        }
    }
}
