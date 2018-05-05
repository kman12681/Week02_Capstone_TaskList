using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02_TaskList
{
    class Task
    {      
        public string TeamMember { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completion { get; set; } 

        public Task(string teamMember, string taskDescription, DateTime dueDate, bool completion)
        {
            TeamMember = teamMember;
            TaskDescription = taskDescription;
            //DueDate = DateTime.Parse(dueDate);   // DateTime.Now.AddDays(14);
            Completion = false;           

        }

        

    }
}
