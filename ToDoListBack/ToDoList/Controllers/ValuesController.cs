using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ToDoList.Entities;

namespace ToDoList.Controllers
{
   [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET api/values
        public IEnumerable<ToDo> Get()
       {
            var list = context.ToDo.ToList();
          
            return list;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
     
        public void Post(string label)
        {
            var todo = new ToDo() { Done = false, Important = false, Label = label };
            context.ToDo.Add(todo);
            context.SaveChanges();
        }
        [HttpPost]
        [Route("api/values/SetImportant")]
        public void SetImportant(int id)
        {
            var todo = context.ToDo.SingleOrDefault(e => e.Id == id);

            todo.Important = !todo.Important;
          
            context.SaveChanges();
        }
        [HttpPost]
        [Route("api/values/SetDone")]
        public void SetDone(int id)
        {
            var todo = context.ToDo.SingleOrDefault(e => e.Id == id);

            todo.Done = !todo.Done;
            
            context.SaveChanges();
        }
        public void Put(int id,  bool important,bool done)
        {
            var todo = context.ToDo.SingleOrDefault(e => e.Id == id);

            todo.Important = important;
            todo.Done = done;
            context.SaveChanges();
        }
        // DELETE api/values/5
        public void Delete(int id)
        {
            var todo = context.ToDo.SingleOrDefault(e => e.Id == id);
            if (todo != null)
            {
                context.ToDo.Remove(todo);
                context.SaveChanges();
            }
        }
    }
}
