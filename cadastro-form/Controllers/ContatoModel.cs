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
            string strConn = "Data Source=anexs.com.br;Initial Catalog=BDContato2;UID=sanexs;pwd=Anexs@SQL#2019";
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
            List<Formulario> lista = new List<Formulario>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Contato";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Formulario contato = new Formulario();
                contato.Nome = (string)reader["Nome"];
                contato.Email = (string)reader["Email"];
                contato.Telefone = (string)reader["Telefone"];
                lista.Add(contato);
            }
            return lista;
        }

    }
}