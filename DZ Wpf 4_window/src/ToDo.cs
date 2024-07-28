using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Wpf_4_window.src
{
    public class ToDo
    {
        public string TitleToDo { get; set; }
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }
        public ToDo(string title, DateTime date, string description)
        { this.TitleToDo = title; this.Date = date; this.Description = description; this.Done = false; }

        


    }
}
