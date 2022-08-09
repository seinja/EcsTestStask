using UnityEngine;

[CreateAssetMenu(menuName = "Create game congif", fileName = "Game config", order = 0)]
public class ConfigurationSO : ScriptableObject
{
    public float DoorOpeningSpeed = 3f;
    public float DoorOffSet = 4f;

    public float PlayerMoveSpeed = 3.5f;
    public float PlayerRotationSpeed = 350f;
}
