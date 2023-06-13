using System;
using System.Collections.Generic;
using bModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bModel;
using bDB;
using MySql.Data.MySqlClient;

namespace bModel
{
    public class UsuarioDAO
    {



        Banco db = new Banco();
        public void Insert(Usuario objUsuario)
        {
            string srtInsert = string.Format("insert into tbUsuario( NomeUsu, Cargo, DataNasc) " +
                   " values ('{0}', '{1}',STR_TO_DATE( '{2}', '%d/%m/%Y %T'))", objUsuario.NomeUsu, objUsuario.Cargo, objUsuario.DataNasc);
            db.Open();
            db.ExecuteQuery(srtInsert);
            db.Close();
        }

        public void Delete(int Id)
        {
            db.Open();
            string drop = string.Format("DELETE FROM tbUsuario  WHERE IdUsu= {0};", Id);
            db.ExecuteQuery(drop);
            db.Close();
        }

        public void Update(Usuario objUsuario)
        {
            db.Open();
            string srtUpdate = string.Format("UPDATE tbUsuario SET NomeUsu = '{0}', Cargo = '{1}', DataNasc = STR_TO_DATE( '{2}', '%d/%m/%Y %T') WHERE IdUsu ={3} ;", objUsuario.NomeUsu, objUsuario.Cargo, objUsuario.DataNasc, objUsuario.IdUsu);
            db.ExecuteQuery(srtUpdate);
            db.Close();
        }

        public List<Usuario> SelectList()
        {

            string strSelect = "select * from tbUsuario";
            db.Open();
            MySqlDataReader DR = db.ExecuteReadSQL(strSelect);
            //db.Close();
            return ListUsuario(DR);
        }

        private List<Usuario> ListUsuario(MySqlDataReader leitor)
        {
            List<Usuario> usuarios = new List<Usuario>();

            while (leitor.Read())
            {
                var tempUsuario = new Usuario()
                {
                    IdUsu = int.Parse(leitor["IdUsu"].ToString()),
                    NomeUsu = leitor["NomeUsu"].ToString(),
                    Cargo = leitor["Cargo"].ToString(),
                    DataNasc = DateTime.Parse(leitor["DataNasc"].ToString())

                };
                usuarios.Add(tempUsuario);
            }
            leitor.Close();
            db.Close();
            return usuarios;
        }

        public string SelectDado(int id)
        {
            string dado = string.Format("SELECT NomeUsu FROM tbUsuario WHERE idUsu = {0};", id);

            db.Open();
            dado = db.ExecuteScalarSQL(dado);
            db.Close();

            return dado;
        }
    }
}
