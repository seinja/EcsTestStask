using Leopotam.EcsLite;
using UnityEngine;

public class ButtonCollisionSystem : IEcsRunSystem
{
    private Vector3 _privatePlayerPosition;

    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        var gameData = systems.GetShared<GameData>();

        var playerFilter = world.Filter<ModelPositionComponent>().End();
        var playerPool = world.GetPool<ModelPositionComponent>();

        var buttonFilter = world.Filter<ButtonComponent>().End();
        var buttonPool = world.GetPool<ButtonComponent>();

        foreach (var playerEntity in playerFilter) 
        {
            ref var playerComponent = ref playerPool.Get(playerEntity);
            _privatePlayerPosition = playerComponent.PlayerPosition;
        }

        foreach (var buttonEntity in buttonFilter) 
        {
            ref var buttonComponent = ref buttonPool.Get(buttonEntity);

            var distance = Vector3.Distance(_privatePlayerPosition, buttonComponent.ButtonTransform.position);

            if (distance < gameData.Config.ButtonOffSet)
            {
                buttonComponent.InitialPosition = buttonComponent.DoorTransform.position;
                buttonComponent.IsPressed = true;
            }
            else
            {
                buttonComponent.IsPressed = false;
            }
        }
    }
}
