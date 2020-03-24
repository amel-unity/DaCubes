using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


public struct SpawnerEntitiesCubes : IComponentData
{
    public Entity redCubePrefab;
    public Entity blueCubePrefab;
    public float spawnRay;
    public float spawnFrequency;
    public float secondsForNextSpawn;
}

