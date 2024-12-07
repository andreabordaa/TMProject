namespace TMProject.Models
{
    public class TaskItem{
        public string name { get; set;}
        public DateOnly dueDate { get; set;}
        public Category category{ get; set;}
        public bool isDone { get; set;}

        public TaskItem(string name, DateOnly dueDate, bool isDone, Category category) {
            this.name = name;
            this.dueDate = dueDate;
            this.isDone = isDone;
            this.category = category;
        }

        public void completeTask() {
            isDone = true;
        }
    }
}