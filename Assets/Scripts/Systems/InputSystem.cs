using Leopotam.EcsLite;
using UnityEngine;

public class InputSystem : IEcsRunSystem
{
    private Vector3 _targetDestination;
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        var filter = world.Filter<InputComponent>().End();

        var inputPool = world.GetPool<InputComponent>();

        SetTargetDestination();

        foreach (var entity in filter) 
        {
            ref var inputComponent = ref inputPool.Get(entity);
            inputComponent.Input = _targetDestination;
        }
    }

    private void SetTargetDestination()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        var mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mousePosition, out RaycastHit hit)) 
        {
            if (!hit.collider.gameObject.CompareTag(Constants.GroundTag)) return;

            _targetDestination = hit.point;
        }
    }
}
