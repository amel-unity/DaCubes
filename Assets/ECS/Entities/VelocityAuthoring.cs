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

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Velocity() { Value = Value });
    }

   
}
