using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02_TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("OUR COMPANY'S TASK LIST");
            Console.WriteLine("_____________________________________________________________________________\n");
            List<Task> OurTaskList = new List<Task>();
            int count = OurTaskList.Count;

            OurTaskList.Add(new Task("Gaston", "Collate papers", DateTime.Parse("05/10/18"), "incomplete"));
            OurTaskList.Add(new Task("Jafar", "TPS reports", DateTime.Parse("05/14/18"), "incomplete"));
            OurTaskList.Add(new Task("Ursula", "Fill pez dispensers", DateTime.Parse("05/12/18"), "incomplete"));
            OurTaskList.Add(new Task("Scar", "Feed fish", DateTime.Parse("05/07/18"), "incomplete"));
            OurTaskList.Add(new Task("Iago", "Grind coffee beans", DateTime.Parse("05/09/18"), "incomplete"));

            bool program = true;
            while (program)
            {
                int num = Menu();

                if (num == 1)
                {
                    CurrentList(OurTaskList);
                }
                else if (num == 2)
                {
                    AddTask(OurTaskList);
                }
                else if (num == 3)
                {
                    DeleteTask(OurTaskList);
                }
                else if (num == 4)
                {
                    MarkTaskComplete(OurTaskList);
                }
                else
                {
                    program = Quit();
                }
            }
            Console.WriteLine();
            Console.WriteLine("This program will now end.");
            Console.WriteLine();
            Console.ReadLine();
               
        }

        public static int Menu()
        {
            Console.WriteLine();
            Console.WriteLine("1. List Tasks");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Mark Task complete/incomplete");
            Console.WriteLine("5. Quit");
            Console.WriteLine();

            while (true)
            {
                Console.Write(">> What would you like to do?: ");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int num);

                if (!success)
                {
                    Console.WriteLine();
                    Console.WriteLine("That wasn't a number");
                }
                else if (!(num > 0 && num < 6))
                {
                    Console.WriteLine();
                    Console.WriteLine("That option doesn't exist");
                }
                else
                {
                    return num;
                }
            }
        }

        public static void CurrentList(List<Task> list)
        {
            int count = 1;
            Console.WriteLine();
            Console.WriteLine("Complete/Incomplete\tDue Date\tTeam Member\tDescription");
            Console.WriteLine("_____________________________________________________________________________");

            foreach (Task item in list)
            {
                Console.WriteLine($"{count++}. {item.Completion}\t\t{item.DueDate}\t{item.TeamMember}\t\t{item.TaskDescription}");
            }
            Console.WriteLine("_____________________________________________________________________________");

        }

        public static void CurrentListSingle(List<Task> list, int index)
        {
            int count = index + 1;

            Console.WriteLine($"{count}. {list[index].Completion}\t\t{list[index].DueDate}\t{list[index].TeamMember}\t\t{list[index].TaskDescription}");

        }

        public static void AddTask(List<Task> list)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------ADD TASK----------------------------------");

            bool whileBool = true;            
            while (whileBool)
            {
                Console.WriteLine();
                Console.Write("Add Team Member: ");
                string newTeamMember = Console.ReadLine();
                Console.Write("Task Description: ");
                string newTask = Console.ReadLine();
                DateTime dt = ValidDate();
                string newCompletion = "incomplete";
                list.Add(new Task(newTeamMember, newTask, dt, newCompletion));
                if(!AddAnother())
                {
                    whileBool = false;
                }                
            }
        }

        public static DateTime ValidDate()
        {
            while (true)
            {
                DateTime dt;
                Console.Write("Due date: ");
                string newDate = Console.ReadLine();

                if (!DateTime.TryParse(newDate, out dt))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid date. Enter dd/mm/yyyy");
                    continue;
                }
                else
                {
                    return dt;
                }
            }

        }

        public static bool AddAnother()

        {while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Add another?");
                Console.WriteLine();
                Console.Write("(y/n): ");
                string response = Console.ReadLine().ToLower();                
                //Console.WriteLine();
                if (response == "y")
                {
                    return true;
                }
                else if (response != "n")
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid Entry.\n");
                }
                else
                {
                    return false;
                }
            }
        }

        public static void DeleteTask(List<Task> list)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------DELETE TASK---------------------------------");
            CurrentList(list);
            Console.WriteLine();
            Console.Write("Which task would you like to delete?: ");
            string choice = Console.ReadLine();
            int index = ValidateDeletion(choice, list);
            index--;

            if (ConfirmDeletion(index, list))
            {
                list.RemoveAt(index);
            }
        }
        public static int ValidateDeletion(string input, List<Task> list)
        {
            int number;
            while (true)
            {
                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine();
                    Console.Write($"Invalid input. Enter a number between 1 - {list.Count}: ");
                    input = Console.ReadLine();
                }
                else if (number < 1 || number > list.Count)
                {
                    Console.WriteLine();
                    Console.Write($"Invalid input. Enter a number between 1 - {list.Count}: ");
                    input = Console.ReadLine();
                }
                else
                {
                    return number--;
                }
            }

        }
        public static bool ConfirmDeletion(int index, List<Task> list)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Delete this?");
                Console.WriteLine();                
                CurrentListSingle(list, index);                
                Console.WriteLine();
                Console.Write("(y/n): ");
                string response = Console.ReadLine().ToLower();
                if (response == "y")
                {
                    Console.WriteLine();
                    Console.WriteLine("Task deleted.");
                    return true;
                }
                else if (response != "n")
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid entry.");

                }
                else
                {
                    return false;
                }
            }
        }

        public static void MarkTaskComplete(List<Task> list)
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------MARK TASK----------------------------------");
            CurrentList(list);
            Console.WriteLine();
            Console.Write("Which task would you like to mark?: ");
            string choice = Console.ReadLine();
            int index = ValidateMarkTask(choice, list);
            index--;

            if (ConfirmMarkTask(index, list))
            {
                list[index].Completion = "complete";
            }
            else
            {
                list[index].Completion = "incomplete";
            }
        }
        public static int ValidateMarkTask(string input, List<Task> list)
        {
            int number;
            while (true)
            {
                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine();
                    Console.Write($"Invalid input. Enter a number between 1 - {list.Count}: ");
                    input = Console.ReadLine();
                }
                else if (number < 1 || number > list.Count)
                {
                    Console.WriteLine();
                    Console.Write($"Invalid input. Enter a number between 1 - {list.Count}: ");
                    input = Console.ReadLine();
                }
                else
                {
                    return number--;
                }
            }

        }
        public static bool ConfirmMarkTask(int index, List<Task> list)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Mark this complete (c) or incomplete (i)\n");
                CurrentListSingle(list, index);
                Console.WriteLine();
                Console.Write("(c/i): ");
                string response = Console.ReadLine().ToLower();
                if (response == "c")
                {
                    Console.WriteLine();
                    Console.WriteLine("Task marked complete.\n");
                    return true;
                }
                else if (response != "i")
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid entry.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Task marked incomplete.");
                    return false;
                }
            }
        }

        public static bool Quit()
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Are you sure you want to quit? (y/n): ");
                string response = Console.ReadLine().ToLower();

                if (response == "n")
                {
                    return true;
                }
                else if (response == "y")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid entry.");
                }
            }
            
        }
    }
}

