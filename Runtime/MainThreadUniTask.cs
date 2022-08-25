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
    }
}
#endif