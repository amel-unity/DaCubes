using System.Collections;
using System.Collections.Generic;

using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using Random= Unity.Mathematics.Random;
using Time = UnityEngine.Time;
using UnityEngine;

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
            Entity prefabToSpawn = (random.NextFloat() > 0.5f) ? spawner.redCubePrefab : spawner.blueCubePrefab;
            Entity instantiatedPrefab = entityCommandBuffer.Instantiate(index, prefabToSpawn);

            //random.NextFloat3Direction() gives a random vector3 and random.NextFloat() returns random float between 0 and 1
            float3 RandomOffset =  random.NextFloat3Direction() * random.NextFloat() * spawner.spawnRay;

            entityCommandBuffer.SetComponent(index, instantiatedPrefab, new Translation
            {
                Value = new float3 (localToWorld.Position.x + RandomOffset.x, -9, localToWorld.Position.z + RandomOffset.z)
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
