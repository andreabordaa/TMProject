using TMProject;
using TMProject.Models;

class Program{
    static void ShowMenu()
    {
        Console.WriteLine("\n");
        Console.WriteLine("1. Add a Task");
        Console.WriteLine("2. Remove a Task");
        Console.WriteLine("3. Mark a Task as Complete");
        Console.WriteLine("4. View All Tasks");
        Console.WriteLine("5. Exit\n");
        Console.Write("Enter your choice: ");
    }

    static void categoryList()
    {
        Console.WriteLine("Choose a category: ");
        Console.WriteLine("1. To Do");
        Console.WriteLine("2. School");
        Console.WriteLine("3. Work");
        Console.WriteLine("4. Personal");
        Console.Write("Enter your category: ");
    }

    static void createTask(TaskManager manager) {
        Console.WriteLine("Enter task name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter due date (YYYY-MM-dd): ");
        if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly dueDate)) {
            Console.WriteLine("Invalid date format. Task not created.");
            return;
        }
         
         categoryList();

        string choice = Console.ReadLine();
        Category c;        

        switch (choice) 
        {
            case "1":
                c = new Category("To do");
                break;

            case "2":
                c = new Category("School");
                break;
            
            case "3":
                c = new Category("Work");
                break;
            
            case "4":
                c = new Category("Personal");
                break;
            
            default:
                Console.WriteLine("Incorrect selection. Please try again");
                c = new Category("");
                return;
        }

        manager.addTask(new TaskItem(name, dueDate, false, c));
        Console.WriteLine("Task created successfully!");
    }

    static void removeTask(TaskManager manager) {
        if (manager.tasks.Count == 0) {
            Console.WriteLine("No tasks available to remove.");
            return;
        }

        for (int i = 0; i < manager.tasks.Count; i++) {
            Console.Write($"{i + 1}. {manager.tasks[i].name}\n");
        }
        
        Console.WriteLine("Select a task to remove: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < manager.tasks.Count) {

            manager.removeTask(manager.tasks[index]);
            Console.WriteLine("Task removed successfully!");
        } else {
            Console.WriteLine("Incorrect selection.");
        }
    }

    static void completed(TaskManager manager) {
        if (manager.tasks.Count == 0) {
            Console.WriteLine("No tasks available to remove.");
            return;
        }

        for (int i = 0; i < manager.tasks.Count; i++) {
            Console.Write($"{i + 1}. {manager.tasks[i].name}\n");
        }

        Console.WriteLine("Select a task to mark as complete: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < manager.tasks.Count) {
            manager.tasks[index].completeTask();
            Console.WriteLine("Yay! You completed a task!");
        } else {
            Console.WriteLine("Incorrect selection.");
        }
    }

    static void viewTasks(TaskManager manager) {
        manager.displayTasks();
    }
    public static void Main(string[] args) {
        TaskManager manager = new TaskManager();

        Console.WriteLine("\nWelcome to Task Manager !");
        Console.WriteLine("Please select from the following options: \n");

        while (true) {
            ShowMenu();
            string choice = Console.ReadLine();

            switch (choice) 
            {
                case "1":
                    createTask(manager);
                    break;

                case "2":
                    removeTask(manager);
                    break;
                
                case "3":
                    completed(manager);
                    break;
                
                case "4":
                    viewTasks(manager);
                    break;
                
                case "5":
                    Console.WriteLine("Now exiting the program. See you later!");
                    return;

                default:
                    Console.WriteLine("Incorrect selection. Please try again");
                    break;

            }
        }

    }
}