using Polly.Retry;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proz_DesktopApplication.HelperServices
{
    public static class PollyPolicyRegistry
    {
        public static AsyncRetryPolicy CreateDefaultRetryPolicy()
        {
            return Policy //This is Polly’s main tool to build retry rules.
                  .Handle<Exception>() //  This says: "Retry only if any Exception happens" (any error, like internet not working, or SMTP server not found). You can also handle specific exceptions
                .WaitAndRetryForeverAsync(  //WaitAndRetryAsync is a method that that will retry after a period of time pass (you can use a lot of methods but i think this is the best one. This method will take parameters up to 3 parameters.
                  
                    sleepDurationProvider: attempt => TimeSpan.FromSeconds(5), //This line tells Polly how long to wait before each retry. sleepDurationProvider: This is the name of a setting that Polly wants.Polly says: "Hey, tell me how long I should wait between retries." So, we're giving it a rule: sleepDurationProvider. attempt => ... is a This is a lambda expression, which is a short way of writing a function, it means "For each retry attempt, do something.". BTW attempt means we are in the retry number what ? like if this was our first time to retry then it will be 1, if it's second then it will be 2 etc.. so in short it means "When Polly gives me the retry attempt number, I’ll give it back a time to wait.".  Math.Pow(x, y) means: "x to the power of y". So Math.Pow(2, attempt) gives us: 1st attempt: 2¹ = 2 seconds, 2nd attempt: 2² = 4 seconds and finally 3rd attempt: 2³ = 8 seconds. So all this line means "For each retry attempt, wait 2^attempt seconds before trying again."
                      onRetry: (exception, delay) =>
                      {
                          Console.WriteLine($"Retry after {delay} due to {exception.GetType().Name}");
                      });
        }
    }
}
