using UnityEngine;
using System;

[Serializable]
public struct PlayerComponent
{
    public Transform PlayerTransform;
    public Transform ModelTransform;
    public bool IsMoving;
}
