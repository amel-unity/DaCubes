using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]

internal class VelocityAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float Speed = 4f;
    public float3 MoveVector = new float3(0,0,-1);
    public bool Touched = false;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Velocity() { Speed = Speed, MoveVector = MoveVector, Touched = Touched });
    }

   
}
