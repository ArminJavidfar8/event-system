using EventSystem.Abstraction;
using EventSystem.Core;
using EventSystem.Extension;

namespace EventSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestEventSystem();
        }

        private static void TestEventSystem()
        {
            RegisterSampleEvents();
            BroadcastSampleEvents();
        }

        #region Broadcast sample events
        private static void BroadcastSampleEvents()
        {
            IEventService eventSystem = EventService.Instance;

            eventSystem.BroadcastEvent(EventTypes.OnEnemyDied, "The Giant");
            eventSystem.BroadcastEvent(EventTypes.OnBoosterUsed, "Potion");
            eventSystem.BroadcastEvent(EventTypes.OnScreenTapped, 100, 550);
        }
        #endregion

        #region Register sample events
        private static void RegisterSampleEvents()
        {
            IEventService eventSystem = EventService.Instance;

            eventSystem.RegisterEvent<string>(EventTypes.OnEnemyDied, EnemyDied);
            eventSystem.RegisterEvent<string>(EventTypes.OnBoosterUsed, BoosterUsed);
            eventSystem.RegisterEvent<float, float>(EventTypes.OnScreenTapped, ScreenTapped);
        }

        private static void ScreenTapped(float x, float y)
        {
            Console.WriteLine($"Screen tapped at position: {x}, {y}");
        }

        private static void BoosterUsed(string boosterName)
        {
            Console.WriteLine($"Booster used. Booster name: {boosterName}");
        }

        private static void EnemyDied(string enemyName)
        {
            Console.WriteLine($"Enemy died. Enemy name: {enemyName}");
        }
        #endregion
    }
}