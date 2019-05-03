using Autofac;
using System;

namespace FastRunner.Autofac
{
    class FastAutofacActivator : IFastJobActivator
    {
        private readonly IComponentContext componentContext;

        public FastAutofacActivator(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public IFastJob Activate(Type jobType)
        {
            return (IFastJob)this.componentContext.Resolve(jobType);
        }
    }
}
