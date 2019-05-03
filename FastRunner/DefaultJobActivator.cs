using System;

namespace FastRunner
{
    class DefaultJobActivator : IFastJobActivator
    {
        public IFastJob Activate(Type jobType)
        {
            return (IFastJob)Activator.CreateInstance(jobType);
        }
    }
}
