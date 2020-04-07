using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


public class SpawnerEntitiesCubesAuthoring : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    public GameObject redCubeprefab, blueCubeprefab;
    public float maxSpawnDistance;

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(redCubeprefab);
        referencedPrefabs.Add(blueCubeprefab);
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        //Add many to the prefab with a loop??
        dstManager.AddComponentData(entity, new SpawnerEntitiesCubes {
			redCubePrefab = conversionSystem.GetPrimaryEntity(redCubeprefab),
			blueCubePrefab = conversionSystem.GetPrimaryEntity(blueCubeprefab),
			spawnRadius = maxSpawnDistance,
			spawnFrequency = Random.Range(1, 5),
			secondsToNextSpawn = 0f,
			randomness = new Unity.Mathematics.Random(1)
        });
    }
}
