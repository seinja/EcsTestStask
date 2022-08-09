using Leopotam.EcsLite;

public class ModelsCommunicationSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        var filter = world.Filter<PlayerComponent>().Inc<ModelPositionComponent>().End();

        var playerPool = world.GetPool<PlayerComponent>();
        var modelPool = world.GetPool<ModelPositionComponent>();

        foreach(var entity in filter) 
        {
            ref var playerComponent = ref playerPool.Get(entity);
            ref var modelComponent = ref modelPool.Get(entity);

            modelComponent.PlayerPosition = playerComponent.PlayerTransform.position;
        }
    }
}
