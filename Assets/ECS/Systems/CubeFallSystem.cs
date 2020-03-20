using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class CubeFallSystem : SystemBase
{
    protected override void OnUpdate()
    {

        float deltaTime = Time.DeltaTime;

        Entities.WithName("MoveDown")
           .ForEach((ref Velocity velocity) =>
           {
               if (velocity.ApplyGravity)
               {
                   velocity.Value += (float3)new float3(0, -5, 0) * deltaTime;
               }
           }).Run();
    }
}

