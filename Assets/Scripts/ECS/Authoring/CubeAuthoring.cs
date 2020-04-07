using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

[DisallowMultipleComponent]
internal class CubeAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float3 moveDirection = new float3(0, 0, -1);
	public float speed;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Cube() { Speed = speed, MoveVector = moveDirection});
    }
}
