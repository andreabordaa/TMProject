namespace TMProject.Models
{
    public class Reminder {
        public string message { get; set; }
        public DateTime notfication { get; set; }
    
        public Reminder(string message, DateTime notfication) {
            this.message = message;
            this.notfication = notfication;
        }

        public void sendNotif() {
            Console.WriteLine($"Reminder: {message} at {notfication}");
        }
    }
}