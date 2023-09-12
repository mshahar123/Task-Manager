using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using WebApi_Tasks.Models;

namespace WebApi_Tasks.Controllers
{
    public class TasksApiController : ApiController
    {
        TasksEntities db = new TasksEntities();

        [System.Web.Http.HttpGet]
       public IHttpActionResult GetTasks()
        {
            List<TasksTable> list = db.TasksTables.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetTasksById(int id)
        {
            var tas = db.TasksTables.Where(model => model.Task_ID == id).FirstOrDefault();
            return Ok(tas);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult TasksInsert(TasksTable t)
        {
            db.TasksTables.Add(t);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult TasksUpdate(TasksTable t)
        {
            db.Entry(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


            //OR



            //var tas = db.TasksTables.Where(model => model.Task_ID == t.Task_ID).FirstOrDefault();
            //if(tas != null)
            //{
            //    tas.Task_ID = t.Task_ID;
            //    tas.Description = t.Description;
            //    tas.Completion_Status = t.Completion_Status;
            //    db.SaveChanges();
            //}
            //else
            //{
            //    return NotFound();
            //}

            return Ok();
        }


        [System.Web.Http.HttpDelete]
        public IHttpActionResult TasksDelete(int id)
        {
            var tas = db.TasksTables.Where(model => model.Task_ID == id).FirstOrDefault();
            db.Entry(tas).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }

    }


}
