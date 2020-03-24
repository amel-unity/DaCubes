using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
public class SimplePhysicsSystem : SystemBase
{
    const float floor = -3;
    protected override void OnUpdate()
    {

    //    float deltaTime = Time.DeltaTime;
    //    Entities.WithName("ApplyPhysics")
    //        .ForEach((ref Translation position, in Velocity velocity) => 
    //        {
    //            position.Value += velocity.Value * deltaTime;
        
    //        }).Run();

    //    Entities.WithName("CopyTransformToGameObject")
    //        .WithoutBurst()
    //        .ForEach((Transform transform, ref Translation Position) =>
    //        {
    //            transform.position = Position.Value;
    //        }).Run();

    //    Entities.WithName("ApplyGravity")
    //        .ForEach((ref Velocity velocity) =>
    //        {
    //            velocity.Value += (float3) Physics.gravity * deltaTime;
    //        }).Run();

    //    Entities.WithName("ApplyFloorCollision")
    //        .ForEach((ref Translation position, ref Velocity velocity) =>
    //        {
    //            if(position.Value.y < floor + 0.5f)
    //            {
    //                position.Value = floor + 0.5f;
    //                velocity.Value = math.reflect(velocity.Value, math.up()) / 1.25f;
    //            }

    //        }).Run();

    }

}
