using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct Bounds : IComponentData
{
    public float Radius;
}
public class BoundComponent : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var renderer = GetComponent<Renderer>();
        var bounds = new Bounds()
        {
            Radius = math.max(math.abs(renderer.bounds.extents.x), math.abs(renderer.bounds.extents.y))
        };

        dstManager.AddComponentData(entity, bounds);
    }
}
