using AndaForceExtensions.com.andaforce.arazect.enumerations;

namespace AndaForceExtensions.com.andaforce.arazect.callback
{
    public enum ChainActionStatus
    {
        [EnumExtension.StringValue("Not started")] NotStarted = 0,
        [EnumExtension.StringValue("In progress")] InProgress = 1,
        [EnumExtension.StringValue("Finished successfully")] FinishedSuccessfully = 2,
        [EnumExtension.StringValue("Finished with error")] FinishedWithError = 3
    }
}