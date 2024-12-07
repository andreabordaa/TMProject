namespace TMProject.Models
{
    public class TaskManager{
        public List <TaskItem> tasks { get; private set; }

        public TaskManager() {
            tasks = new List <TaskItem>();
        }

        public void addTask(TaskItem task) {
            tasks.Add(task);
        }

        public void removeTask(TaskItem task) {
            tasks.Remove(task);
        }

        public void displayTasks() {
            if (tasks.Count == 0) {
                Console.WriteLine("No tasks available.");
                return;
            }
            foreach (TaskItem task in tasks) {
                Console.WriteLine($"{task.name} \t {task.dueDate}");
            }
        }
    }
}