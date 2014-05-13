using System;
using AndaForceExtensions.com.andaforce.arazect.enumerations;

namespace AndaForceExtensions.com.andaforce.arazect.callback
{
    public abstract class AbstractCallbackChainElement
    {
        public ChainActionStatus Status { get; protected set; }
        public Exception Exception { get; protected set; }
        public bool AllowParallel { get; protected set; }
        internal int ParallelChainId;

        protected AbstractCallbackChainElement(bool allowParallel = false, int parallelChainId = 0)
        {
            AllowParallel = allowParallel;
            ParallelChainId = parallelChainId;
        }

        public virtual void PerformOperation()
        {
            try
            {
                MarkFinished();
            }
            catch(Exception e)
            {
                MarkError(e);
            }
        }

        protected void MarkFinished()
        {
            Status = ChainActionStatus.FinishedSuccessfully;
        }

        protected void MarkError(Exception e)
        {
            Status = ChainActionStatus.FinishedWithError;
            Exception = e;
        }

        public String GetStatusString()
        {
            return Status.GetStringValue();
        }
    }
}