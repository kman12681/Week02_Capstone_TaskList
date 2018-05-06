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
        public string DueDate { get; set; }
        public string Completion { get; set; }
        

        public Task(string teamMember, string taskDescription, DateTime dueDate, string completion)
        {
            TeamMember = teamMember;
            TaskDescription = taskDescription;
            DueDate = String.Format("{0:MM/dd/yyyy}", dueDate);
            Completion = completion;
            
        }



    }
}
