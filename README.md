# Event System

A lightweight and flexible event broadcasting system for C# applications, designed to facilitate decoupled communication between different parts of your codebase. This system provides a simple way to register and unregister event listeners, and broadcast events with or without parameters.
# Features

- **Decoupled Communication**: Easily send and receive notifications without direct dependencies between components.
- **Generic Event Handling**: Supports events with up to four generic parameters (`Action<T1>`, `Action<T1, T2>`, etc.).
- **Integer-based Event IDs**: Events are identified by simple integer IDs, offering flexibility.
- **Extension Method Support**: Includes an example extension that allows using enum types for event identification, enhancing readability and type safety.
- **Simple API**: Intuitive methods for registering, unregistering, and broadcasting events.

# How to Use

## Basic Setup  
First, you'll need an instance of the `EventService` (the core implementation of the Event System). You can use dependency injection or simply create a new instance.
```csharp
using YekGames.EventService.Abstraction;
using YekGames.EventService.Core;

public class MyGameManager
{
    private readonly IEventService _eventService;

    public MyGameManager()
    {
        _eventService = new EventService();
    }
}
```
# Creating and Using Custom Event Extensions

While the core `EventService` uses integer IDs, it's highly recommended to create custom extension classes with enum types for better readability, maintainability, and compile-time type safety. This allows you to define meaningful event names instead of magic numbers. (Like `EventServiceExtension` class in project files)

## Define your enum for Event Types  
Create a public enum that lists all the specific events your application will use. This can be placed in its own file or within your extension class file.
```csharp
// Example: In a file named EventTypes.cs or within your extension namespace
public enum GameEventTypes
{
    None,
    OnPlayerSpawned,
    OnEnemyDestroyed,
    OnScoreChanged,
    OnGameOver,
    OnLevelComplete,
}

```
## Create a Static Extension Class  
Create a static class to house your extension methods. This class should be public and typically resides in a namespace accessible to your project.
```csharp
using System;
using YekGames.EventService.Abstraction;

namespace YourGame.Events.Extensions
{
    public static class EventSystemExtensions
    {
        // Register methods
        public static void RegisterEvent(this IEventService eventSystem, GameEventTypes eventType, Action action)
        {
            eventSystem.RegisterEvent((int)eventType, action);
        }

        public static void RegisterEvent<T1>(this IEventService eventSystem, GameEventTypes eventType, Action<T1> action)
        {
            eventSystem.RegisterEvent((int)eventType, action);
        }

        // ... (add overloads for T1, T2, T3, T4 as needed, similar to the IEventService interface)

        // UnRegister methods
        public static void UnRegisterEvent(this IEventService eventSystem, GameEventTypes eventType, Action action)
        {
            eventSystem.UnRegisterEvent((int)eventType, action);
        }

        public static void UnRegisterEvent<T1>(this IEventService eventSystem, GameEventTypes eventType, Action<T1> action)
        {
            eventSystem.UnRegisterEvent<T1>((int)eventType, action);
        }

        // ... (add overloads for T1, T2, T3, T4 as needed)

        // Broadcast methods
        public static void BroadcastEvent(this IEventService eventSystem, GameEventTypes eventType)
        {
            eventSystem.BroadcastEvent((int)eventType);
        }

        public static void BroadcastEvent<T1>(this IEventService eventSystem, GameEventTypes eventType, T1 param1)
        {
            eventSystem.BroadcastEvent<T1>((int)eventType, param1);
        }

        // ... (add overloads for T1, T2, T3, T4 as needed)
    }
}
```
## Using Your Custom Extension  
Once your extension class is defined, you can simply register, unregister and broadcast events using your enum type.
```csharp
using System;
using YekGames.EventService.Abstraction;
using YekGames.EventService.Core;
using YourGame.Events.Extensions;

public class PlayerController
{
    private readonly IEventService _eventService;

    public PlayerController(IEventService eventService)
    {
        _eventService = eventService;
    }

    public void AddScore(int amount)
    {
        // Broadcasting an event with parameters using your custom enum
        _eventService.BroadcastEvent(GameEventTypes.OnScoreChanged, amount);
    }

    public void OnDestroy()
    {
        // Unregistering an event using your custom enum
        _eventService.UnRegisterEvent<int>(GameEventTypes.OnScoreChanged, UpdateScoreDisplay);
    }
}
```

```csharp
using UnityEngine;
using YekGames.EventService.Abstraction;
using YekGames.EventService.Extension;

public class ScoreUI : MonoBehaviour
{
    private IEventService _eventService;

    public void Initialize(IEventService eventService)
    {
        _eventService = eventService;

        _eventService.RegisterEvent<int>(EventTypes.OnScoreChanged, ScoreChanged);
    }

    private void ScoreChanged(int newScore)
    {
        Debug.Log($"Score updated to: {newScore}");
    }
}
```

### Unregistering Events:
It's crucial to unregister events when they are no longer needed to prevent memory leaks and unexpected behavior.
