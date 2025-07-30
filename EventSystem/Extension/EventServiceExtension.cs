using System;
using YekGames.EventService.Abstraction;

namespace YekGames.EventService.Extension
{
    // Example of an extension to Event System. Developers can create their own specific extension class to manage events in a type-safe and readable manner.
    
    public enum EventTypes
    {
        None,
        OnUserClickedForward,
        OnUserShot,
        OnLevelStarted,
        OnLevelFinished,
        OnScoreChanged,
        OnDied,
    }

    public static class EventServiceExtension
    {
        public static void RegisterEvent(this IEventService eventSystem, EventTypes eventType, Action action)
        {
            eventSystem.RegisterEvent((int)eventType, action);
        }

        public static void RegisterEvent<T1>(this IEventService eventSystem, EventTypes eventType, Action<T1> action)
        {
            eventSystem.RegisterEvent((int)eventType, action);
        }

        public static void RegisterEvent<T1, T2>(this IEventService eventSystem, EventTypes eventType, Action<T1, T2> action)
        {
            eventSystem.RegisterEvent((int)eventType, action);
        }

        public static void RegisterEvent<T1, T2, T3>(this IEventService eventSystem, EventTypes eventType, Action<T1, T2, T3> action)
        {
            eventSystem.RegisterEvent((int)eventType, action);
        }

        public static void RegisterEvent<T1, T2, T3, T4>(this IEventService eventSystem, EventTypes eventType, Action<T1, T2, T3, T4> action)
        {
            eventSystem.RegisterEvent((int)eventType, action);
        }

        public static void UnRegisterEvent(this IEventService eventSystem, EventTypes eventType, Action action)
        {
            eventSystem.UnRegisterEvent((int)eventType, action);
        }

        public static void UnRegisterEvent<T1>(this IEventService eventSystem, EventTypes eventType, Action<T1> action)
        {
            eventSystem.UnRegisterEvent<T1>((int)eventType, action);
        }

        public static void UnRegisterEvent<T1, T2>(this IEventService eventSystem, EventTypes eventType, Action<T1, T2> action)
        {
            eventSystem.UnRegisterEvent((int)eventType, action);
        }

        public static void UnRegisterEvent<T1, T2, T3>(this IEventService eventSystem, EventTypes eventType, Action<T1, T2, T3> action)
        {
            eventSystem.UnRegisterEvent((int)eventType, action);
        }

        public static void UnRegisterEvent<T1, T2, T3, T4>(this IEventService eventSystem, EventTypes eventType, Action<T1, T2, T3, T4> action)
        {
            eventSystem.UnRegisterEvent((int)eventType, action);
        }

        public static void BroadcastEvent(this IEventService eventSystem, EventTypes eventType)
        {
            eventSystem.BroadcastEvent((int)eventType);
        }

        public static void BroadcastEvent<T1>(this IEventService eventSystem, EventTypes eventType, T1 param1)
        {
            eventSystem.BroadcastEvent<T1>((int)eventType, param1);
        }

        public static void BroadcastEvent<T1, T2>(this IEventService eventSystem, EventTypes eventType, T1 param1, T2 param2)
        {
            eventSystem.BroadcastEvent((int)eventType, param1, param2);
        }

        public static void BroadcastEvent<T1, T2, T3>(this IEventService eventSystem, EventTypes eventType, T1 param1, T2 param2, T3 param3)
        {
            eventSystem.BroadcastEvent((int)eventType, param1, param2, param3);
        }

        public static void BroadcastEvent<T1, T2, T3, T4>(this IEventService eventSystem, EventTypes eventType, T1 param1, T2 param2, T3 param3, T4 param4)
        {
            eventSystem.BroadcastEvent((int)eventType, param1, param2, param3, param4);
        }
    }
}
