using UnityEngine;
using System;

[Serializable]
public struct ButtonComponent
{
    public Transform DoorTransform;
    public Transform ButtonTransform;

    [HideInInspector] public Vector3 InitialPosition;
    [HideInInspector] public bool IsPressed;
}
