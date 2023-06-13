using System;
using bModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using bDB;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace AppSexta.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        Usuario objUsuario2 = new Usuario();
        Banco bd2 = new Banco();
        List<Usuario> ListUsuario = new List<Usuario>();

        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Select()
        {
            List<Usuario> usuarios = usuarioDAO.SelectList();
            return View(usuarios);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuarioDAO.Insert(usuario);
                return RedirectToAction("Select"); 
            }

            return View(usuario);
        }
    }
}
