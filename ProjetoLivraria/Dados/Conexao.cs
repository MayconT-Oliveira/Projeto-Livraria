using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivraria.Dados
{
    public class Conexao
    {
        MySqlConnection cn = new MySqlConnection("Server=localhost; Port= 3306; DataBase=bdLivraria; User=root; pwd=12345678");
        public static string msg;

        public MySqlConnection MyConectarBD() 
        {
            try
            {
                cn.Open();
            }
            catch(Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }
        public MySqlConnection MyDesConectarBD() 
        {
            try
            {
                cn.Close();
            }
            catch(Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }
    }
}