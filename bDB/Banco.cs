using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace bDB
{
    public class Banco
    {

       

        public MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        public void Open()
        {
            if (conexao.State == System.Data.ConnectionState.Closed)
                conexao.Open();
        }

        public MySqlDataReader ExecuteReadSQL(string strQuery)
        {
            cmd.CommandText = strQuery;
            cmd.Connection = conexao;
            MySqlDataReader leitor = cmd.ExecuteReader();
            return leitor;
        }

        public void ExecuteQuery(string strQuery)
        {
            cmd.CommandText = strQuery;
            cmd.Connection = conexao;
            cmd.ExecuteNonQuery();
        }

        public string ExecuteScalarSQL(string strQuery)
        {
            cmd.CommandText = strQuery;
            cmd.Connection = conexao;
            string scalar = Convert.ToString(cmd.ExecuteScalar());
            if (scalar.Length < 1)
            {
                return scalar = "";
            }
            return scalar;
        }

        public void Close()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }

    }
}
