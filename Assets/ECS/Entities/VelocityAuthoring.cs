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
    public GameObject drop;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Velocity() { Value = Value });
    }

    //This function will "subscribe" the gameObject (a Prefab) into a conversion mechanism
    //which allows, during ECS gameplay, to instantiate the entity that was created out of this Prefab during conversion
    public void DeclareReferencedPrefabs(List<GameObject> gameObjects)
    {
        gameObjects.Add(drop);
    }
}
