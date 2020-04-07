using Unity.Entities;

public struct SpawnerEntitiesCubes : IComponentData
{
    public Entity redCubePrefab;
    public Entity blueCubePrefab;
    public float spawnRadius;
    public float spawnFrequency;
    public float secondsToNextSpawn;
	public Unity.Mathematics.Random randomness;
}

