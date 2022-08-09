using Leopotam.EcsLite;
using UnityEngine;

public class DoorOpeningSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        var gameData = systems.GetShared<GameData>();

        var filter = world.Filter<ButtonComponent>().End();
        var buttonPool = world.GetPool<ButtonComponent>();

        foreach (var buttonEntity in filter) 
        {
            ref var buttonComponet = ref buttonPool.Get(buttonEntity);

            if (buttonComponet.IsPressed) 
            {
                var transform = buttonComponet.DoorTransform;
                transform.Translate(-Vector3.right * gameData.Config.DoorOpeningSpeed * Time.deltaTime);
            }
        }
    }
}