using UnityEngine;
using Leopotam.EcsLite;

public class PlayerMoveSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        var filter = world.Filter<PlayerComponent>().Inc<ModelPositionComponent>().End();

        var modelComponetPool = world.GetPool<PlayerComponent>();
        var directionComponentPool = world.GetPool<ModelPositionComponent>();

        foreach (var entity in filter)
        {
            ref var modelComponent = ref modelComponetPool.Get(entity);
            ref var directionComponet = ref directionComponentPool.Get(entity);

            var transform = modelComponent.PlayerTransform;
            var modelTransform = modelComponent.ModelTransform;

            var speed = 5f * Time.deltaTime;
            var rotationSpeed = 400f * Time.deltaTime;

            modelComponent.IsMoving = directionComponet.OffSet.magnitude > 0.1f;

            if (!modelComponent.IsMoving) return;

            transform.Translate(directionComponet.OffSet.normalized * speed);
            var rotation = Quaternion.LookRotation(directionComponet.OffSet.normalized, Vector3.up);
            modelTransform.rotation = Quaternion.RotateTowards(modelTransform.rotation, rotation, rotationSpeed);
        }
    }
}
