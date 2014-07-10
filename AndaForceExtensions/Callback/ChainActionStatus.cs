using System;
using AndaForceUtils.Enumerations;

namespace AndaForceUtils.Callback
{
   [Obsolete("Doesn't work yet, please don't use", true)]
    public enum ChainActionStatus
    {
        [EnumerationExtension.StringValue("Not started")] NotStarted = 0,
        [EnumerationExtension.StringValue("In progress")] InProgress = 1,
        [EnumerationExtension.StringValue("Finished successfully")] FinishedSuccessfully = 2,
        [EnumerationExtension.StringValue("Finished with error")] FinishedWithError = 3
    }
}