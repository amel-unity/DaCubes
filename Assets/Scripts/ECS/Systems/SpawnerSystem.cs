using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class SpawnerSystem : SystemBase
{
    private EndInitializationEntityCommandBufferSystem endInitializationECBSystem;

    protected override void OnCreate()
    {
		base.OnCreate();
        endInitializationECBSystem = World.GetOrCreateSystem<EndInitializationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
		EntityCommandBuffer.Concurrent ecb = endInitializationECBSystem.CreateCommandBuffer().ToConcurrent();
		float deltaTime = UnityEngine.Time.deltaTime;

		Entities.ForEach((Entity entity, int entityInQueryIndex, ref SpawnerEntitiesCubes spawner, ref LocalToWorld localToWorld) => 
		{
			spawner.secondsToNextSpawn -= deltaTime;
			if(spawner.secondsToNextSpawn >= 0){ return; } //exit, no time to spawn yet

			//queue an instantiate command to the EntityCommandBuffer
			Entity prefabToSpawn = (spawner.randomness.NextFloat() > 0.5f) ? spawner.redCubePrefab : spawner.blueCubePrefab;
            Entity instantiatedPrefab = ecb.Instantiate(entityInQueryIndex, prefabToSpawn);

			//queue a SetComponent command to position the newly created entity at the back of the scene
            float3 RandomOffset = spawner.randomness.NextFloat3Direction() * spawner.randomness.NextFloat() * spawner.spawnRadius; //random.NextFloat3Direction() gives a random unit-long vector3, and random.NextFloat() returns random float between 0 and 1
			ecb.SetComponent(entityInQueryIndex, instantiatedPrefab, new Translation
            {
                Value = new float3 (localToWorld.Position.x + RandomOffset.x, -9, localToWorld.Position.z + RandomOffset.z)
            });

			//update the time to the next entity spawn
			spawner.secondsToNextSpawn += spawner.spawnFrequency;
		}).Schedule();
    }
}
