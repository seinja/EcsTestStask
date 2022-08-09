using Leopotam.EcsLite;
using UnityEngine;

public class DoorOpeningSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        var filter = world.Filter<ButtonComponent>().End();
        var buttonPool = world.GetPool<ButtonComponent>();

        foreach (var buttonEntity in filter) 
        {
            ref var buttonComponet = ref buttonPool.Get(buttonEntity);

            if (buttonComponet.IsPressed) 
            {
                var currentDoorOffSetDistance = Vector3.Distance
                (buttonComponet.DoorTransform.position,
                buttonComponet.InitialPosition);

                var transform = buttonComponet.DoorTransform;
                transform.Translate(-Vector3.right * 5f * Time.deltaTime);
            }
        }
    }
}
