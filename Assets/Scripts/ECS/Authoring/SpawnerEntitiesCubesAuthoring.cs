using System.Collections;
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
        //referencedPrefabs.AddRange(prefabs);
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {

        //Add many to the prefab with a loop??
        dstManager.AddComponentData(entity, new SpawnerEntitiesCubes{
        //prefab = conversionSystem.GetPrimaryEntity(prefabs[Random.Range(0, prefabs.Length)]),
        redCubePrefab = conversionSystem.GetPrimaryEntity(redCubeprefab),
        blueCubePrefab = conversionSystem.GetPrimaryEntity(blueCubeprefab),
        spawnRay = maxSpawnDistance,
        spawnFrequency = Random.Range(1, 5),
        secondsForNextSpawn = 0f

        });


    

    }
}
