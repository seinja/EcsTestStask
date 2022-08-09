using Leopotam.EcsLite;
using UnityEngine;

public class ModelMoveSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        var filter = world.Filter<ModelPositionComponent>().Inc<InputComponent>().End();

        var modelPool = world.GetPool<ModelPositionComponent>();
        var inputPool = world.GetPool<InputComponent>();

        foreach (var entity in filter) 
        {
            ref var modelComponent = ref modelPool.Get(entity);
            ref var inputComponent = ref inputPool.Get(entity);

            var targetDestination = new Vector3(inputComponent.Input.x, modelComponent.PlayerPosition.y, inputComponent.Input.z);

            var offSet = targetDestination - modelComponent.PlayerPosition;

            modelComponent.OffSet = offSet;
        }
    }
}
