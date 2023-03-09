using MySql.Data.MySqlClient;
using ProjetoLivraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivraria.Dados
{
    public class AcLivro
    {
        Conexao con = new Conexao();
        
        public void inserirLivro(ModLivro cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbLivro(nomeLivro, codAutor) values (@nomeLivro, @codAutor)"
                , con.MyConectarBD()); // @: PARAMETRO

            cmd.Parameters.Add("@nomeLivro", MySqlDbType.VarChar).Value = cm.nomeLivro;
            cmd.Parameters.Add("@codAutor", MySqlDbType.VarChar).Value = cm.codAutor;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<ModLivro> mostrarLivro() 
        {
            List<ModLivro> listalivros = new List<ModLivro>();
            MySqlCommand cmd = new MySqlCommand("select tbLivro.codLivro, tbLivro.nomeLivro,tbAutor.nomeAutor from tbLivro inner join tbAutor on tbLivro.codAutor = tbAutor.codAutor;", con.MyConectarBD());

        }
    }
}