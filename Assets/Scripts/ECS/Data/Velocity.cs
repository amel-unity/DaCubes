using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

//[GenerateAuthoringComponent]
public struct Velocity : IComponentData
{
    public float3 Value;
    public float3 MoveVector;
}
