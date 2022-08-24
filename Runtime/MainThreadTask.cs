using System;
using System.Threading.Tasks;
using UnityEngine;
#if HAVE_UNITASK
using Cysharp.Threading.Tasks;
#endif

namespace Gilzoide.MainThreadTask
{
    public static class MainThreadTask
    {
        public static TaskScheduler Scheduler { get; private set; }
        public static TaskFactory Factory { get; private set; }

#if HAVE_UNITASK
        public static void Run(Action action, PlayerLoopTiming timing = PlayerLoopTiming.Update)
        {
            if (action != null)
            {
                UniTask.Post(action, timing);
            }
        }

        public static async UniTask RunAsync(Action action, PlayerLoopTiming timing = PlayerLoopTiming.Update)
        {
            if (action != null)
            {
                await UniTask.Yield(timing);
                action.Invoke();
            }
        }
#else
        public static async void Run(Action action)
        {
            await RunAsync(action);
        }

        public static Task RunAsync(Action action)
        {
            return Factory.StartNew(action);
        }
#endif

        [RuntimeInitializeOnLoadMethod]
        private static void InitializeFactory()
        {
            Scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Factory = new TaskFactory(Scheduler);
        }
    }
}
