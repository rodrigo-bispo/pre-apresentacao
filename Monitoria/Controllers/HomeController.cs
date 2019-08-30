using Microsoft.AspNet.Identity;
using Monitoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Monitoria.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Aluno()
        {
            return View();
        }
        public ActionResult Professor()
        {
            return View();
        }
        public ActionResult Logar()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logar(Usuario u)
        {
            // esta action trata o post (login)
            if (ModelState.IsValid) //verifica se é válido
            {
                using (MonitoriaEntities4 dc = new MonitoriaEntities4())
                {
                    var v = dc.Usuarios.Where(a => a.Perfil.Equals(u.Perfil) && a.Senha.Equals(u.Senha)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["EmailLogado"] = v.Perfil.ToString();
                        return View("Lockout");
                    }

                }
                return View(u);
            }
            Session["ID"] = u.ID;
            Session["Perfil"] = u.Perfil;

            if (Session["Perfil"].ToString() == "Null")
            {
                return View("Lockout");
            }

            if (Session["Perfil"].ToString() == "ADMIN")
            {
                return RedirectToAction("Index", "Home");
            }

            if (Session["Perfil"].ToString() == "Aluno")
            {
                return RedirectToAction("Aluno", "Home");
            }

            if (Session["Perfil"].ToString() == "Professor")
            {
                return RedirectToAction("Professor", "Home");
            }

            if (Session["Perfil"].ToString() == "null")
            {
                return RedirectToAction("Logar");
            }
            else
            {
                return RedirectToAction("Logar", u);
            }
        }



        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(Usuario _usuario)
        {
            if (ModelState.IsValid)
            {
                using (MonitoriaEntities4 dc = new MonitoriaEntities4())
                {
                    //verifica duplicidade
                    if (!UsuarioDAL.VerificaEmail(_usuario.Email))
                    {
                        dc.Usuarios.Add(_usuario);
                        dc.SaveChanges();
                        ModelState.Clear();
                        _usuario = null;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Email já cadastrado.";
                    }
                }
            }
            return View(_usuario);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    //    public string Login(string user)
    //    {
    //        FormsAuthentication.SignOut();

    //        var roles = "";

    //        if (user.Equals("fulano", StringComparison.InvariantCultureIgnoreCase))
    //            roles = "Admin,Manager";


    //        if (user.Equals("sicrano", StringComparison.InvariantCultureIgnoreCase))
    //            roles = "Admin";

    //        if (user.Equals("Beltrano", StringComparison.InvariantCultureIgnoreCase))
    //            roles = "Admin,User,Manage";

    //        if (user.Equals("Aluno", StringComparison.InvariantCultureIgnoreCase))
    //            roles = "User";


    //        var authTicket = new FormsAuthenticationTicket(

    //          1,
    //          user,
    //          DateTime.Now,
    //          DateTime.Now.AddDays(1),
    //          false,
    //          roles,
    //          "/");

    //        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
    //        Response.Cookies.Add(cookie);

    //        return "Ok";

    //    }

    //    // qualquer usuário autenticado pode acessar

    //    [Authorize]
    //    public string ActionProtegida()
    //    {
    //        return "Ok";
    //    }

    //    // usuários autenticados com a Role Admin
    //    // podem acessar
    //    [Authorize(Roles = "Admin")]
    //    public string ActionProtegidaParaAdmin()
    //    {
    //        return "Ok";
    //    }

    //    // usuário autenticados com a Role Admin OU
    //    // com a Role Manager podem acessar
    //    [Authorize(Roles = "Admin,Manager,User")]
    //    public string ActionProtegidaParaAdminOuManager()
    //    {
    //        return "Ok";
    //    }



    //    // usuários autenticado com a Role Admin E
    //    // com a Role Manager podem acessar

    //    [Authorize(Roles = "Admin")]
    //    [Authorize(Roles = "Manager")]
    //    public string ActionProtegidaParaAdminEManager()
    //    {
    //        return "Ok";
    //    }


    //    // usuários autenticados com a Role Admin
    //    // E TAMBEM pelo menos uma das Roles Manager Ou User
    //    // podem acessar
    //    [Authorize(Roles = "Admin")]
    //    [Authorize(Roles = "Manager,User")]
    //    public string ActionProtegidaParaAdminManagerOuAdminUser()
    //    {
    //        return "Ok";

    //    }

    }


}
