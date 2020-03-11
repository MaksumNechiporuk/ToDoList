using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public bool Done { get; set; }
        public bool Important { get; set; }

    }
}