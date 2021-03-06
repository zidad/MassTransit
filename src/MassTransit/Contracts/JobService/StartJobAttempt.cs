namespace MassTransit.Contracts.JobService
{
    using System;
    using System.Collections.Generic;


    public interface StartJobAttempt
    {
        /// <summary>
        /// The job identifier
        /// </summary>
        Guid JobId { get; }

        /// <summary>
        /// Identifies this attempt to run the job
        /// </summary>
        Guid AttemptId { get; }

        /// <summary>
        /// Zero if the job is being started for the first time, otherwise, the number of previous failures
        /// </summary>
        int RetryAttempt { get; }

        /// <summary>
        /// The service address where the job can be started
        /// </summary>
        Uri ServiceAddress { get; }

        /// <summary>
        /// The instance address of the assigned job slot instance
        /// </summary>
        Uri InstanceAddress { get; }

        /// <summary>
        /// The job, as an object dictionary
        /// </summary>
        IDictionary<string, object> Job { get; }
    }
}
