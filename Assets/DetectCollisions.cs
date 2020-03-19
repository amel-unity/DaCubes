using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using RaycastHit = Unity.Physics.RaycastHit;

/*
public class DetectCollisions : SystemBase
{
    public DetectCollisions()
    {
    }

    public Entity Raycast(float3 RayFrom, float3 RayTo)
    {
        var physicsWorldSystem = World.GetExistingSystem<Unity.Physics.Systems.BuildPhysicsWorld>();
        var collisionWorld = physicsWorldSystem.PhysicsWorld.CollisionWorld;
        RaycastInput input = new RaycastInput()
        {
            Start = RayFrom,
            End = RayTo,
            Filter = new CollisionFilter()
            {
                BelongsTo = ~0u,
                CollidesWith = ~0u, // all 1s, so all layers, collide with everything
                GroupIndex = 0
            }
        };

        RaycastHit hit = new RaycastHit();
        bool haveHit = collisionWorld.CastRay(input, out hit);
        if (haveHit)
        {
            
            // see hit.Position
            // see hit.SurfaceNormal
            Entity e = physicsWorldSystem.PhysicsWorld.Bodies[hit.RigidBodyIndex].Entity;
            return e;
        }
        return Entity.Null;
    }

    protected override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}
*/