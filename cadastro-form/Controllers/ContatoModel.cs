using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using TesteFabio.Models;

namespace cadastro_form.Controllers
{
    public class ContatoModel : IDisposable
    {
        private SqlConnection connection;

        public ContatoModel()
        {
            string strConn = "Data Source=localhost;Initial Catalog=BDContato;Integrated Security=true";
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Formulario contato)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Contato VALUES (@nome, @email, @telefone)";

            cmd.Parameters.AddWithValue("@nome", contato.Nome);
            cmd.Parameters.AddWithValue("@email", contato.Email);
            cmd.Parameters.AddWithValue("@telefone", contato.Telefone);

            cmd.ExecuteNonQuery();
        }

        public List<Formulario> Read()
        {
            return null;
        }
    }
}