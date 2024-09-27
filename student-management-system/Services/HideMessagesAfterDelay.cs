using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace student_management_system.Services
{
    public class HideMessagesAfterDelay
    {
        
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public string UpdateSuccessMessage { get; set; }
        public string UpdateErrorMessage { get; set; }
        public string Message { get; set; }

        
        public async Task HideMessageAfterDelay(int milliSecond)
        {
            await Task.Delay(milliSecond); // Delay for 5 seconds

            // Reset all messages to null
            SuccessMessage = null;
            ErrorMessage = null;
            UpdateSuccessMessage = null;
            UpdateErrorMessage = null;
            Message = null;
            //refreshUI?.Invoke();
        }
    }
}
