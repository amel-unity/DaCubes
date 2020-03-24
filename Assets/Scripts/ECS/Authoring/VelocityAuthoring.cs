using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]

internal class VelocityAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float3 Value;
    public float3 MoveVector = new float3(0,0,-1);

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Velocity() { Value = Value, MoveVector =MoveVector});
    }

   
}
