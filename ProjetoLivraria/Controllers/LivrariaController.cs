using MySql.Data.MySqlClient;
using ProjetoLivraria.Dados;
using ProjetoLivraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLivraria.Controllers
{
    public class LivrariaController : Controller
    {
        // GET: Livraria
        public ActionResult Index()
        {
            return View();
        }

        // Carrega a lista com os autores
        public void CarregaAutores()
        {
            List<SelectListItem> autores = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Database=bdLivraria; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbAutor where sta=1", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    autores.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.autores = new SelectList(autores, "Value", "Text");
        }

        public ActionResult CadLivro()
        {
            CarregaAutores();
            return View();
        }

        AcLivro ac = new AcLivro(); // instanciando as classes
        ModLivro mod = new ModLivro(); // instanciando as classes

        public ActionResult ConfCadLivro(FormCollection frm)
        {
            mod.nomeLivro = frm["txtNmLivro"];
            mod.codAutor = Request["autores"];
            ac.inserirLivro(mod);
            return View();
        }

        public void CarregaLivros()
        {
            List<SelectListItem> livros = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Database=bdLivraria; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select tbLivro.codLivro, tbLivro.nomeLivro,tbAutor.nomeAutor from tbLivro inner join tbAutor on tbLivro.codAutor = tbAutor.codAutor;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    livros.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.autores = new SelectList(livros, "Value", "Text");
        }

        public ActionResult SelLivro()
        {
            CarregaLivros();
            return View();
        }

    }
}