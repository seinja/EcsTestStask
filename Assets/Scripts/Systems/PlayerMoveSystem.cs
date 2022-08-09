using UnityEngine;
using Leopotam.EcsLite;

public class PlayerMoveSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        var gameData = systems.GetShared<GameData>();

        var filter = world.Filter<PlayerComponent>().Inc<ModelPositionComponent>().End();

        var modelComponetPool = world.GetPool<PlayerComponent>();
        var directionComponentPool = world.GetPool<ModelPositionComponent>();

        foreach (var entity in filter)
        {
            ref var modelComponent = ref modelComponetPool.Get(entity);
            ref var directionComponet = ref directionComponentPool.Get(entity);

            var transform = modelComponent.PlayerTransform;
            var modelTransform = modelComponent.ModelTransform;

            var speed = gameData.Config.PlayerMoveSpeed * Time.deltaTime;
            var rotationSpeed = gameData.Config.PlayerRotationSpeed * Time.deltaTime;

            modelComponent.IsMoving = directionComponet.OffSet.magnitude > gameData.Config.MovingOffSet;

            if (!modelComponent.IsMoving) return;

            transform.Translate(directionComponet.OffSet.normalized * speed);
            var rotation = Quaternion.LookRotation(directionComponet.OffSet.normalized, Vector3.up);
            modelTransform.rotation = Quaternion.RotateTowards(modelTransform.rotation, rotation, rotationSpeed);
        }
    }
}