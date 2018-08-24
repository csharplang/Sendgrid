using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace SendGridDotNetCore.Controllers
{
    public class SendEmailController : Controller
    {
        // GET: SendEmail
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> SendMail()
        {
            var result= await Common.Helper.SendEmailUsingSendGrid();
            Thread.Sleep(3000);

            ViewBag.SendGridStatusCode = result.Item1;
            ViewBag.SendGridHeaders = result.Item2.Replace("\r\n", " <***> ");
            ViewBag.SendGridBody = result.Item3.Replace("\r\n", " <***> ");

            return await Task.Run(() => View());
        }



        // GET: SendEmail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SendEmail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SendEmail/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SendEmail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SendEmail/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SendEmail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SendEmail/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}