# Main Thread Task
[Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)/[UniTask](https://github.com/Cysharp/UniTask)-based
Main Thread dispatcher classes, no `GameObject`s attached.


## Features
- Simple to use: call `MainThreadTask.Run` and that's it, your action will run on the Main Thread!
- `async` method `MainThreadTask.RunAsync`, so you can `await` for execution to complete
- [TaskScheduler](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.taskscheduler)
  and [TaskFactory](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.taskfactory)
  used for running Tasks on the Main Thread are available
- UniTask-based implementation in `MainThreadUniTask` class, conditionally compiled if UniTask is
  detected in project
- `System.Action` extension methods `InvokeOnMainThread` and `InvokeOnMainThreadAsync`
- No `GameObject`s
- Simple implementations with around 50 lines of code each


## How to install
Either:

- Install via [Unity Package Manager](https://docs.unity3d.com/Manual/upm-ui-giturl.html)
  using the following URL:

```
https://github.com/gilzoide/unity-main-thread-task.git#1.0.0
```

- Copy the implementation file [Runtime/MainThreadTask.cs](Runtime/MainThreadTask.cs) and/or [Runtime/MainThreadUniTask.cs](Runtime/MainThreadUniTask.cs) to your project.
  
  If using UniTask, either remove the `#if/#endif` lines from `MainThreadUniTask.cs` or define `HAVE_UNITASK` in your project's scripting define symbols.