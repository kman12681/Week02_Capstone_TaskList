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
            List<Task> OurTaskList = new List<Task>();
            int count = OurTaskList.Count;

            OurTaskList.Add(new Task("TeamMember1", "TaskDescription1", DateTime.Parse("05/04/18"), false));
            OurTaskList.Add(new Task("TeamMember2", "TaskDescription2", DateTime.Parse("05/04/18"), false));
            OurTaskList.Add(new Task("TeamMember3", "TaskDescription3", DateTime.Parse("May 4, 2018"), false));
            OurTaskList.Add(new Task("TeamMember4", "TaskDescription4", DateTime.Parse("05/05/2018"), false));
            OurTaskList.Add(new Task("TeamMember5", "TaskDescription5", DateTime.Parse("05/04/18"), false));

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
                    MarkTaskComplete();
                }
                else
                {
                    program = Quit();
                }
            }

            Console.WriteLine("Goodbye!");
        }

        public static int Menu()
        {

            Console.WriteLine("1. List Tasks");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Mark task complete");
            Console.WriteLine("5. Quit");
            Console.WriteLine();

            while (true)
            {
                Console.Write("What would you like to do?");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int num);

                if (!success)
                {
                    Console.WriteLine("That wasn't a number");
                }
                else if (!(num > 0 && num < 6))
                {
                    Console.WriteLine("That option doesn't exist");
                }
                else
                {
                    return num;
                }

            }

        }

        public static void CurrentList(List<Task> CurrentList)
        {

            foreach (Task item in CurrentList)
            {
                Console.WriteLine($"{item.TeamMember}, {item.TaskDescription}, {item.DueDate}");
            }

        }

        public static void AddTask(List<Task> taskList)
        {

            bool whileBool = true;
            string response = "";
            while (whileBool)
            {
                Console.WriteLine("Ok! Let's add a task");
                Console.WriteLine();
                Console.Write("Add Team Member: ");
                string newTeamMember = Console.ReadLine();
                Console.Write("Task Description: ");
                string newTask = Console.ReadLine();
                Console.Write("Due date: ");
                string newDate = Console.ReadLine();
                DateTime dt;
                DateTime.TryParse(newDate, out dt);
                taskList.Add(new Task(newTeamMember, newTask, dt, false));
                Console.WriteLine("Add another?");
                response = Console.ReadLine();
                if (response == "quit")
                    whileBool = false;
            }

        }

        public static void DeleteTask(List<Task> currentList)
        {

            Console.Write("Which task would you like to delete?");
            string choice = Console.ReadLine();
            int index = ValidateDeletion(choice, currentList);
            index--;

            if (ConfirmDelete(index, currentList))
            {
                currentList.RemoveAt(index);
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
        public static bool ConfirmDelete(int index, List<Task> list)
        {
            while (true)
            {
                Console.WriteLine($"Delete {list[index].TeamMember}?");
                string response = Console.ReadLine().ToLower();
                if (response == "y")
                {
                    Console.WriteLine("Task deleted.");
                    return true;
                }
                else if (response != "n")
                {
                    Console.WriteLine("Invalid entry.");
                }
                else
                {
                    return false;
                }
            }
        }
        public static void MarkTaskComplete()
        {

        }

        public static bool Quit()
        {
            while (true)
            {

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
                    Console.WriteLine("Invalid entry.");
                }

            }

        }


















    }
}

