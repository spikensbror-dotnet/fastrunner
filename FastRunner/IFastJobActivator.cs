using System;

namespace FastRunner
{
    /// <summary>
    /// Creates job instances.
    /// </summary>
    public interface IFastJobActivator
    {
        /// <summary>
        /// Creates an instance of the given job type.
        /// </summary>
        /// <param name="jobType">The type of job to create.</param>
        /// <returns>An instance of the job.</returns>
        IFastJob Activate(Type jobType);
    }
}
