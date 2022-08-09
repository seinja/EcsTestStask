using Leopotam.EcsLite;

public class PlayerAnimationSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        var filter = world.Filter<PlayerComponent>().Inc<AnimationComponent>().End();

        var animationPool = world.GetPool<AnimationComponent>();
        var playerPool = world.GetPool<PlayerComponent>();

        foreach (var entity in filter) 
        {
            ref var animationComponent = ref animationPool.Get(entity);
            ref var playerComponent = ref playerPool.Get(entity);

            animationComponent.Animator.SetBool("IsMoving", playerComponent.IsMoving);
        }
    }
}
