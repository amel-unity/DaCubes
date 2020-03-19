using System.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using Random= Unity.Mathematics.Random;
using Time = UnityEngine.Time;

//Should stop using JobComponentSystem and use SystemBase instead
public class SpawnerSystem : JobComponentSystem
{
    private EndInitializationEntityCommandBufferSystem endInitializationEntityCommandBufferSystem;

    protected override void OnCreate()
    {
        endInitializationEntityCommandBufferSystem = World.GetOrCreateSystem<EndInitializationEntityCommandBufferSystem>();
    }

    private struct SpawnerJob : IJobForEachWithEntity<SpawnerEntitiesCubes, LocalToWorld>
    {
        private EntityCommandBuffer.Concurrent entityCommandBuffer;
        private readonly float deltaTime;
        private Random random;

        //Constructor, everything passed here will be passed to the job schedule
        public SpawnerJob(EntityCommandBuffer.Concurrent entityCommandBuffer, Random random, float deltaTime)
        {
            this.entityCommandBuffer = entityCommandBuffer;
            this.random = random;
            this.deltaTime = deltaTime;
        }
        public void Execute(Entity entity, int index, ref SpawnerEntitiesCubes spawner, ref LocalToWorld localToWorld)
        {
            spawner.secondsForNextSpawn -= deltaTime;

            if(spawner.secondsForNextSpawn >= 0){ return; }

            spawner.secondsForNextSpawn += spawner.spawnFrequency;

            Entity instance = entityCommandBuffer.Instantiate(index, spawner.prefab);
            entityCommandBuffer.SetComponent(index, instance, new Translation
            {
                //random.NextFloat3Direction() gives a random vector3 and random.NextFloat() returns random float between 0 and 1
                Value = localToWorld.Position + random.NextFloat3Direction() * random.NextFloat() * spawner.spawnRay
            }); 
        }
    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var SpawnerJob = new SpawnerJob(
            endInitializationEntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent(),
            new Random((uint)UnityEngine.Random.Range(0, int.MaxValue)),
            Time.DeltaTime
        );

        JobHandle jobHandle = SpawnerJob.Schedule(this, inputDeps);

        endInitializationEntityCommandBufferSystem.AddJobHandleForProducer(jobHandle);

        return jobHandle;

        /* Job.WithCode(() =>
     {
         new SpawnerJob(
                     endInitializationEntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent(),
                     new Random((uint)UnityEngine.Random.Range(0, int.MaxValue)),
                     Time.DeltaTime);     
     }).Run();
     */
    }

}
