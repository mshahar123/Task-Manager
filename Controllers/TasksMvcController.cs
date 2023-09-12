using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApi_Tasks.Models;

namespace WebApi_Tasks.Controllers
{
    public class TasksMvcController : Controller
    {
        // GET: TasksMvc
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<TasksTable> tasks_tables = new List<TasksTable>();
            client.BaseAddress = new Uri("https://localhost:44305/api/TasksApi");
            var response = client.GetAsync("TasksApi");
            response.Wait();

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List< TasksTable>> ();
                display.Wait();
                tasks_tables = display.Result;

            }
            return View(tasks_tables);
        }

        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(TasksTable tas)
        {

            client.BaseAddress = new Uri("https://localhost:44305/api/TasksApi");
            var response = client.PostAsJsonAsync<TasksTable>("TasksApi", tas);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View("create");
        }


        public ActionResult Details(int id)
        {
            TasksTable tas = null;
            client.BaseAddress = new Uri("https://localhost:44305/api/TasksApi");
            var response = client.GetAsync("TasksApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<TasksTable>();
                display.Wait();
                tas = display.Result;

            }
            return View(tas);
        }

        public ActionResult Edit(int id)
        {
            TasksTable tas = null;
            client.BaseAddress = new Uri("https://localhost:44305/api/TasksApi");
            var response = client.GetAsync("TasksApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<TasksTable>();
                display.Wait();
                tas = display.Result;

            }
            return View(tas);
        }

        [HttpPost]
        public ActionResult Edit(TasksTable t)
        {
            client.BaseAddress = new Uri("https://localhost:44305/api/TasksApi");
            var response = client.PutAsJsonAsync<TasksTable>("TasksApi", t);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            TasksTable tas = null;
            client.BaseAddress = new Uri("https://localhost:44305/api/TasksApi");
            var response = client.GetAsync("TasksApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<TasksTable>();
                display.Wait();
                tas = display.Result;

            }
            return View(tas);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44305/api/TasksApi");
            var response = client.DeleteAsync("TasksApi/"+ id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View("Delete");
        }
    }
}