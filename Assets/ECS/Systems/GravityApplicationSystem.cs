using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Collections;

public class GravityApplicationSystem : JobComponentSystem
{
    private BuildPhysicsWorld buildPhysicsWorld;
    private StepPhysicsWorld stepPhysicsWorld;

    protected override void OnCreate()
    {
        buildPhysicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>();
        stepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();
    }

    //protected override JobHandle OnUpdate(JobHandle inputDeps)
    //{
    //    throw new System.NotImplementedException();
    //}

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var applicationJob = new ApplicationJob
        {
            gravityApplierGroup = GetComponentDataFromEntity<GravityApplier>(),
            velocityGroup = GetComponentDataFromEntity<Velocity>()
        };
        var appJob = applicationJob.Schedule(stepPhysicsWorld.Simulation, ref buildPhysicsWorld.PhysicsWorld, inputDeps);
        appJob.Complete();
        return appJob;
    }

    private struct ApplicationJob : ITriggerEventsJob
    {
        //Query for the components we care about (as in ECS, we do stuff based on the components)
        [ReadOnly]  public ComponentDataFromEntity<GravityApplier> gravityApplierGroup;
        public ComponentDataFromEntity<Velocity> velocityGroup;

        //This function will be called every time there is a trigger collision in the game
        public void Execute(TriggerEvent triggerEvent)
        {
            if (gravityApplierGroup.HasComponent(triggerEvent.Entities.EntityA))
            {
                if (velocityGroup.HasComponent(triggerEvent.Entities.EntityB))
                {
                    Velocity velocity = velocityGroup[triggerEvent.Entities.EntityB];
                    velocity.ApplyGravity = true;
                    velocityGroup[triggerEvent.Entities.EntityB] = velocity;
                }
            }

            if (gravityApplierGroup.HasComponent(triggerEvent.Entities.EntityB))
            {
                if (velocityGroup.HasComponent(triggerEvent.Entities.EntityA))
                {
                    Velocity velocity = velocityGroup[triggerEvent.Entities.EntityA];
                    velocity.ApplyGravity = true;
                    velocityGroup[triggerEvent.Entities.EntityA] = velocity;
                }
            }
        }
    }


}
