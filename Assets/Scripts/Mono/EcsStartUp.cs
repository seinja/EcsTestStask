using UnityEngine;
using Leopotam.EcsLite;
using Voody.UniLeo.Lite;

public class EcsStartUp : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    [SerializeField] private ConfigurationSO _configuration;

    private void Start()
    {
        _world = new EcsWorld();

        var gameData = new GameData();
        gameData.Config = _configuration;

        _systems = new EcsSystems(_world, gameData);

        _systems.ConvertScene();

        AddAndInitSystems();
    }

    private void Update()
    {
        _systems?.Run();
    }

    private void OnDestroy()
    {
        if (_systems != null) 
        {
            _systems.Destroy();
            _systems = null;
        }

        if (_world != null) 
        {
            _world.Destroy();
            _world = null;
        }
    }

    private void AddAndInitSystems()
    {
        _systems
            .Add(new ModelsCommunicationSystem())
            .Add(new InputSystem())
            .Add(new ModelMoveSystem())
            .Add(new PlayerMoveSystem())
            .Add(new PlayerAnimationSystem())
            .Add(new ButtonCollisionSystem())
            .Add(new DoorOpeningSystem())
            .Init();
    }
}