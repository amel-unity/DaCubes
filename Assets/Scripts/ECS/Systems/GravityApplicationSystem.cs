using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Collections;
using Unity.Mathematics;

public class GravityApplicationSystem : JobComponentSystem
{
    private BuildPhysicsWorld buildPhysicsWorld;
    private StepPhysicsWorld stepPhysicsWorld;

    protected override void OnCreate()
    {
        buildPhysicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>();
        stepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var applicationJob = new ApplicationJob
        {
            gravityApplierGroup = GetComponentDataFromEntity<GravityApplier>(),
            cubesData = GetComponentDataFromEntity<Cube>(),
            score = UIManager.Instance.GetScoreValue()
        };
        var jobHandle = applicationJob.Schedule(stepPhysicsWorld.Simulation, ref buildPhysicsWorld.PhysicsWorld, inputDeps);
        jobHandle.Complete();
        //UnityEngine.Debug.Log("the score" + applicationJob.score);
        return jobHandle;
    }

    private struct ApplicationJob : ITriggerEventsJob
    {
        //Query for the components we care about (as in ECS, we do stuff based on the components)
        [ReadOnly]  public ComponentDataFromEntity<GravityApplier> gravityApplierGroup;
        public ComponentDataFromEntity<Cube> cubesData;
        public int score;

        //This function will be called every time there is a trigger collision in the game
        public void Execute(TriggerEvent triggerEvent)
        {
            if (gravityApplierGroup.HasComponent(triggerEvent.Entities.EntityA))
            {
                if (cubesData.HasComponent(triggerEvent.Entities.EntityB))
                {
                    Cube velocity = cubesData[triggerEvent.Entities.EntityB];
                    velocity.MoveVector = new float3(0,-100,0);
                    if (!cubesData[triggerEvent.Entities.EntityB].Touched) {
                        UIManager.Instance.IncrementScore(1);
                        velocity.Touched = true;
                    }
                    cubesData[triggerEvent.Entities.EntityB] = velocity;

                }
            }

            if (gravityApplierGroup.HasComponent(triggerEvent.Entities.EntityB))
            {
                if (cubesData.HasComponent(triggerEvent.Entities.EntityA))
                {
                    Cube velocity = cubesData[triggerEvent.Entities.EntityA];
                    velocity.MoveVector = new float3(0, -100, 0);
                    if (!cubesData[triggerEvent.Entities.EntityB].Touched)
                    {
                        UIManager.Instance.IncrementScore(1);
                        velocity.Touched = true;
                    }
                    cubesData[triggerEvent.Entities.EntityA] = velocity;
                }
            }
        }
    }


}
