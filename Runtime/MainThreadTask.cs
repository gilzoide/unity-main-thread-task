using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Gilzoide.MainThreadTask
{
    public static class MainThreadTask
    {
        public static TaskScheduler Scheduler { get; private set; }
        public static TaskFactory Factory { get; private set; }

        public static async void Run(Action action)
        {
            await RunAsync(action);
        }

        public static Task RunAsync(Action action)
        {
            return Factory.StartNew(action);
        }

        [RuntimeInitializeOnLoadMethod]
        private static void InitializeFactory()
        {
            Scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Factory = new TaskFactory(Scheduler);
        }
    }
}
