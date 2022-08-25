#if HAVE_UNITASK
using System;
using Cysharp.Threading.Tasks;

namespace Gilzoide.MainThreadTask
{
    public static class MainThreadUniTask
    {
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

        public static async UniTask<T> RunAsync<T>(Func<T> func, PlayerLoopTiming timing = PlayerLoopTiming.Update)
        {
            if (func == null)
            {
                return default;
            }
            await UniTask.Yield(timing);
            return func.Invoke();
        }

        public static void InvokeOnMainThread(this Action action, PlayerLoopTiming timing = PlayerLoopTiming.Update)
        {
            Run(action, timing);
        }

        public static UniTask InvokeOnMainThreadAsync(this Action action, PlayerLoopTiming timing = PlayerLoopTiming.Update)
        {
            return RunAsync(action, timing);
        }

        public static UniTask<T> InvokeOnMainThreadAsync<T>(this Func<T> func, PlayerLoopTiming timing = PlayerLoopTiming.Update)
        {
            return RunAsync(func, timing);
        }
    }
}
#endif