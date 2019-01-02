﻿namespace Microsoft.Hpc.Scheduler.Session.ServiceContainer
{
    using System;

    using Microsoft.Hpc.Scheduler.Session.Internal;

    // TODO: change to industry level service container
    public static class SessionServiceContainer
    {
        private static ISchedulerAdapter schedulerAdapterInstance;

        // TODO: provide default implementation
        public static ISchedulerAdapter SchedulerAdapterInstance {
            get
            {
                if (schedulerAdapterInstance == null)
                {
                    throw new NullReferenceException($"{nameof(schedulerAdapterInstance)} is null");
                }

                return schedulerAdapterInstance;
            }
            set
            {
                if (schedulerAdapterInstance != null)
                {
                    throw new InvalidOperationException($"{nameof(schedulerAdapterInstance)} is already set");
                }

                schedulerAdapterInstance = value;
            }
        }
    }
}
