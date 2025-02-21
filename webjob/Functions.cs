using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace webjob
{
    public class Functions
    {

        [FunctionName("ScheduledFunction")]
        [NoAutomaticTrigger]
        public static void ScheduledFunction(int id, ILogger logger)
        {
            try
            {
                Console.WriteLine(string.Format("Function executed at: {0} for id {1}", DateTime.Now, id));
                Thread.Sleep(1 * 60 * 1000);
                Console.WriteLine("Exiting function on success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while running webjob function: " + ex.Message);
                Console.WriteLine("Stack trace: " + ex.StackTrace);
            }
        }
    }
}
