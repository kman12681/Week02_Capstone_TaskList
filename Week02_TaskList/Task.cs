using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02_TaskList
{
    class Task
    {
        private string teamMember;
        private string taskDescription;
        private string dueDate;
        private string completion;
        private DateTime compareDate;

        public string TeamMember { get => teamMember; set => teamMember = value; }
        public string TaskDescription { get => taskDescription; set => taskDescription = value; }
        public string DueDate { get => dueDate; set => dueDate = value; }
        public string Completion { get => completion; set => completion = value; }
        public DateTime CompareDate { get => compareDate; set => compareDate = value; }

        public Task(string teamMember, string taskDescription, DateTime dueDate, string completion)
        {
            TeamMember = teamMember;
            TaskDescription = taskDescription;
            DueDate = String.Format("{0:MM/dd/yyyy}", dueDate);
            Completion = completion;
            compareDate = dueDate;
            
            
        }

        
    }
}
