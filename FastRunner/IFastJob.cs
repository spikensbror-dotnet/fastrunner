using System.Threading.Tasks;

namespace FastRunner
{
    /// <summary>
    /// A job to be scheduled by FastRunner.
    /// </summary>
    public interface IFastJob
    {
        /// <summary>
        /// Executes the job.
        /// </summary>
        /// <returns>A task that completes once the job is completed.</returns>
        Task Execute();
    }
}
