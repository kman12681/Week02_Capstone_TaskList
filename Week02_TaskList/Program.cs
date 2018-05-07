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
            OurTaskList.Add(new Task("Scar", "Feed fish", DateTime.Parse("05/16/18"), "incomplete"));
            OurTaskList.Add(new Task("Iago", "Grind coffee beans", DateTime.Parse("05/09/18"), "incomplete"));

            bool program = true;
            while (program)
            {
                int num = Menu();

                if (num == 1)
                {
                    if (OurTaskList.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("*There are currently no tasks*");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        CurrentList(OurTaskList);
                    }
                }
                else if (num == 2)
                {
                    AddTask(OurTaskList);
                }
                else if (num == 3)
                {
                    if (OurTaskList.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("*There are no tasks to edit*");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        EditTask(OurTaskList);
                    }
                }
                else if (num == 4)
                {
                    if (OurTaskList.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("*There are no tasks to delete*");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        DeleteTask(OurTaskList);
                    }
                }
                else if (num == 5)
                {
                    if (OurTaskList.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("*There are no tasks to mark*");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        MarkTaskComplete(OurTaskList);
                    }
                }
                else if (num == 6)
                {
                    if (OurTaskList.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("*There are no tasks to show*");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write("Which task # do you want to see?: ");
                        string input = Console.ReadLine();

                        bool whileBool = true;
                        while (whileBool)
                        {
                            if (!int.TryParse(input, out int number))
                            {
                                Console.WriteLine();
                                Console.Write($">> Invalid input. Enter a number between 1 - {OurTaskList.Count}: ");
                                input = Console.ReadLine();
                            }
                            else if (number < 1 || number > OurTaskList.Count)
                            {
                                Console.WriteLine();
                                Console.Write($">> Invalid input. Enter a number between 1 - {OurTaskList.Count}: ");
                                input = Console.ReadLine();
                            }
                            else
                            {
                                number--;
                                Console.WriteLine();
                                CurrentListSingle(OurTaskList, number);
                                Console.WriteLine();
                                Console.WriteLine(">> Press any key to return to the main menu.");
                                Console.ReadKey();
                                whileBool = false;
                            }
                        }
                    }
                }
                else if (num == 7)
                {
                    ShowDateBefore(OurTaskList);
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
            Console.WriteLine("3. Edit Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Mark Task complete/incomplete");
            Console.WriteLine("6. Show Single Task");
            Console.WriteLine("7. Check Dates");
            Console.WriteLine("8. Quit");
            Console.WriteLine();

            while (true)
            {
                Console.Write(">> What would you like to do?: ");
                string input = Console.ReadLine();
                bool success = int.TryParse(input, out int num);

                if (!success)
                {
                    Console.WriteLine();
                    Console.WriteLine("*That wasn't a number*");
                    Console.WriteLine();
                }
                else if (!(num > 0 && num < 9))
                {
                    Console.WriteLine();
                    Console.WriteLine("*That option doesn't exist*");
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
            Console.WriteLine("---------------------------------CURRENT LIST--------------------------------");
            Console.WriteLine();
            Console.WriteLine("Complete/Incomplete\tDue Date\tTeam Member\tDescription");
            Console.WriteLine();

            foreach (Task item in list)
            {
                Console.WriteLine($"{count++}. {item.Completion}\t\t{item.DueDate}\t{item.TeamMember}\t\t{item.TaskDescription}");
            }
            Console.WriteLine("_____________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine(">> Press any key to return to the main menu.");
            Console.ReadKey();

        }
        public static void CurrentListNoHeader(List<Task> list)
        {
            int count = 1;

            Console.WriteLine();

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
                Console.Write(">> Add Team Member: ");
                string newTeamMember = Console.ReadLine();
                Console.Write(">> Task Description: ");
                string newTask = Console.ReadLine();
                DateTime dt = ValidDate();
                string newCompletion = "incomplete";
                list.Add(new Task(newTeamMember, newTask, dt, newCompletion));
                if (!AddAnother())
                {
                    whileBool = false;
                }
            }
        }
        public static bool AddAnother()

        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(">> Add another task?");
                Console.WriteLine();
                Console.Write(">> (y/n): ");
                string response = Console.ReadLine().ToLower();
                //Console.WriteLine();
                if (response == "y")
                {
                    return true;
                }
                else if (response != "n")
                {
                    Console.WriteLine();
                    Console.WriteLine("*Invalid Entry*\n");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(">> Press any key to return to the main menu.\n");
                    Console.ReadKey();
                    return false;
                }
            }
        }
        public static DateTime ValidDate()
        {
            while (true)
            {
                DateTime dt;
                Console.Write(">> Due date: ");
                string newDate = Console.ReadLine();

                if (!DateTime.TryParse(newDate, out dt))
                {
                    Console.WriteLine();
                    Console.WriteLine("*Invalid date. Enter mm/dd/yyyy*");
                    continue;
                }
                else
                {
                    return dt;
                }
            }

        }

        public static void EditTask(List<Task> list)
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------EDIT TASK----------------------------------");
            CurrentListNoHeader(list);
            Console.WriteLine();
            Console.Write(">> Which task # would you like to edit?: ");

            string choice = Console.ReadLine();
            int index = ValidateEdit(choice, list);
            index--;

            EditPart(list, index);

        }
        public static void EditPart(List<Task> list, int index)
        {
            string response = "";
            Console.WriteLine();
            CurrentListSingle(list, index);
            Console.WriteLine();
            bool whileBool = true;
            while (whileBool)

            {
                Console.Write(">> Choose category to edit: \"Due date\" (date), \"Team Member\" (name), \"Description\" (task), or (exit) if no more changes: ");
                response = Console.ReadLine();

                if (response == "date")
                {
                    Console.WriteLine();
                    DateTime dt = ValidDate();
                    list[index].DueDate = String.Format("{0:M/dd/yyyy}", dt);
                    Console.WriteLine();
                    Console.WriteLine($"[Due date changed to: \"{list[index].DueDate}\"]");
                    Console.WriteLine();
                    CurrentListSingle(list, index);
                    Console.WriteLine();
                }
                else if (response == "name")
                {
                    Console.WriteLine();
                    Console.Write(">> Enter new name: ");
                    list[index].TeamMember = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine($"[Team member changed to: \"{list[index].TeamMember}\"]");
                    Console.WriteLine();
                    CurrentListSingle(list, index);
                    Console.WriteLine();
                }
                else if (response == "task")
                {
                    Console.WriteLine();
                    Console.Write(">> Enter new description: ");
                    list[index].TaskDescription = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine($"[Task description changed to: \"{list[index].TaskDescription}\"]");
                    Console.WriteLine();
                    CurrentListSingle(list, index);
                    Console.WriteLine();
                }
                else if (response != "exit")
                {
                    Console.WriteLine();
                    Console.WriteLine("*Invalid entry*");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(">> Press any key to return to the main menu.");
                    Console.ReadKey();
                    whileBool = false;
                }
            }
        }
        public static int ValidateEdit(string input, List<Task> list)
        {
            int number;
            while (true)
            {
                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine();
                    Console.Write($">> Invalid input. Enter a number between 1 - {list.Count}: ");
                    input = Console.ReadLine();
                }
                else if (number < 1 || number > list.Count)
                {
                    Console.WriteLine();
                    Console.Write($">> Invalid input. Enter a number between 1 - {list.Count}: ");
                    input = Console.ReadLine();
                }
                else return number;
            }
        }

        public static void DeleteTask(List<Task> list)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------DELETE TASK---------------------------------");
            CurrentListNoHeader(list);
            Console.WriteLine();
            Console.Write(">> Which task # would you like to delete?: ");
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
                    Console.Write($">> Invalid input. Enter a number between 1 - {list.Count}: ");
                    input = Console.ReadLine();
                }
                else if (number < 1 || number > list.Count)
                {
                    Console.WriteLine();
                    Console.Write($">> Invalid input. Enter a number between 1 - {list.Count}: ");
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
                    Console.WriteLine("[Task deleted]");
                    Console.WriteLine();
                    Console.WriteLine(">> Press any key to return to the main menu.");
                    Console.ReadKey();
                    return true;
                }
                else if (response != "n")
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid entry.");

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(">> Press any key to return to the main menu.");
                    Console.ReadKey();
                    return false;
                }
            }
        }

        public static void MarkTaskComplete(List<Task> list)
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------MARK TASK----------------------------------");
            CurrentListNoHeader(list);
            Console.WriteLine();
            Console.Write(">> Which task would you like to mark?: ");
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
                    Console.Write($">> Invalid input. Enter a number between 1 - {list.Count}: ");
                    input = Console.ReadLine();
                }
                else if (number < 1 || number > list.Count)
                {
                    Console.WriteLine();
                    Console.Write($">> Invalid input. Enter a number between 1 - {list.Count}: ");
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
                Console.Write(">> (c/i): ");
                string response = Console.ReadLine().ToLower();
                if (response == "c")
                {
                    Console.WriteLine();
                    Console.WriteLine("[Task marked complete]\n");
                    Console.WriteLine(">> Press any key to return to the main menu.");
                    Console.ReadKey();
                    return true;
                }
                else if (response != "i")
                {
                    Console.WriteLine();
                    Console.WriteLine("*Invalid entry*");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("[Task marked incomplete]\n");
                    Console.WriteLine(">> Press any key to return to the main menu.");
                    Console.ReadKey();
                    return false;
                }
            }
        }

        public static DateTime ValidDateDate()
        {
            while (true)
            {
                DateTime dt;
                Console.WriteLine();
                Console.Write(">> Enter date to check: ");
                string newDate = Console.ReadLine();

                if (!DateTime.TryParse(newDate, out dt))
                {
                    Console.WriteLine();
                    Console.WriteLine("*Invalid date. Enter mm/dd/yyyy*");
                    continue;
                }
                else return dt;
            }
        }
        public static void ShowDateBefore(List<Task> list)
        {
            int count = 1;
            DateTime dt1 = ValidDateDate();

            Console.WriteLine();
            Console.WriteLine("The following tasks are due before that date:");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine();

            for (int i = 0; i < list.Count; i++)
            {
                int result = DateTime.Compare(dt1, list[i].CompareDate);
                if (result > 0)
                {
                    Console.WriteLine($"{count++}. {list[i].Completion}\t\t{list[i].DueDate}\t{list[i].TeamMember}\t\t{list[i].TaskDescription}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
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


