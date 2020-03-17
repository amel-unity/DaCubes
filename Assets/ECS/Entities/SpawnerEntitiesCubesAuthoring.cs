using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


public class SpawnerEntitiesCubesAuthoring : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    public GameObject prefab;
    public float maxSpawnDistance;

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(prefab);
        //referencedPrefabs.AddRange(prefabs);
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {

        //Add many to the prefab?? for loop??
        dstManager.AddComponentData(entity, new SpawnerEntitiesCubes{
        //prefab = conversionSystem.GetPrimaryEntity(prefabs[Random.Range(0, prefabs.Length)]),
        prefab = conversionSystem.GetPrimaryEntity(prefab),
        spawnRay = maxSpawnDistance,
        spawnFrequency = Random.Range(1, 3),
        secondsForNextSpawn = 0f

        });
        
    }
}
