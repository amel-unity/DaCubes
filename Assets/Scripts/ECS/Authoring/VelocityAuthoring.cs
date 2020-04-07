using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

[DisallowMultipleComponent]

internal class VelocityAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float speed = 4f;
    public float3 moveVector = new float3(0,0,-1);

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Cube() { Speed = speed, MoveVector = moveVector });
    }

   
}
