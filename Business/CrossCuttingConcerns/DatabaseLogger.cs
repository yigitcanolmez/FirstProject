namespace Business.CrossCuttingConcerns
{
    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Veritabanına loglama yapıldı.");
        }
    }
}
