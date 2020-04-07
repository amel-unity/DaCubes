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
			Entity cubeEntity = Entity.Null;

			//check which is which
            if (gravityApplierGroup.HasComponent(triggerEvent.Entities.EntityA))
            {
                if (cubesData.HasComponent(triggerEvent.Entities.EntityB))
                {
                    cubeEntity = triggerEvent.Entities.EntityB;
                }
            }
			else if (gravityApplierGroup.HasComponent(triggerEvent.Entities.EntityB))
            {
                if (cubesData.HasComponent(triggerEvent.Entities.EntityA))
                {
                    cubeEntity = triggerEvent.Entities.EntityA;
                }
            }

			//do the work (if the cube hasn't been disabled already)
			if (cubeEntity != Entity.Null
				&& !cubesData[cubeEntity].Touched)
			{
				Cube fallingCube = cubesData[cubeEntity];
				fallingCube.MoveVector = new float3(0, -5, 0);
				fallingCube.Touched = true;
				cubesData[cubeEntity] = fallingCube;

				//call Monobehaviour singleton to bridge the gap with Unity UI
				UIManager.Instance.IncrementScore(1);
			}
        }
    }


}
