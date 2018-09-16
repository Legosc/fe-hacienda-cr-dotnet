using System.Net.Http;
using System.Security.Claims;
using System.Web.Mvc;
using CRLibre.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CRLibre.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            List<MenuView> menu = new List<MenuView>
            {
                new MenuView {name= "Listar", icon= "info", url= "/contact" },
                new MenuView {name = "Crear", icon = "address-book", url = "/contact/create" }
            };
            ViewBag.menu = menu;

            base.OnActionExecuting(filterContext);
        }
        private static readonly HttpClient client = new HttpClient();
        // GET: Contact

        public ActionResult Index()
        {
            var claims = User.Identity as ClaimsIdentity;
            IEnumerable<Contact> contactos;
            var response = client.GetAsync(string.Format("http://apiclientes.vitechd.com/api/clientes?userName={0}&sessionKey={1}", User.Identity.Name, claims.FindFirst(ClaimTypes.Hash).Value)).Result;
            var responseString =  response.Content.ReadAsStringAsync().Result;
            try
            {
                contactos = JsonConvert.DeserializeObject<IEnumerable<Contact>>(responseString);
            }
            catch (System.Exception)
            {
                JObject jObject = JObject.Parse(responseString);
                if (jObject["success"].Value<bool>() == false)
                {
                    if ((string)jObject["msg"][0]["code"] == "-303")
                    {
                        Response.Redirect("/Login/Logoff", true);
                    }
                    else
                    {
                        throw;
                    }
                }
                contactos = null;
            }
            
            return View(contactos);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
