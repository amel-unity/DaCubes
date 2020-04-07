using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Random = UnityEngine.Random;

/* public class SpawnerCube : MonoBehaviour
{
    public GameObject[] CubePrefabs;
    public int count = 100;
    private int i = 0;
    private float step, a = 0;

    void Start()
    {
        StartCoroutine("SpawnCubs");
        step = 360f / count;
    }
    IEnumerator SpawnCubs()
    {
        while (true)
        {
            if (i < count)
            {
                for (int i = 0; i < 2; ++i)
                {
                    Vector3 SpawnPosition = new Vector3(Random.Range(-10f,10f), Random.Range(-20f,20f), transform.position.z);
                    GameObject spawned = Instantiate(CubePrefabs[Random.Range(0,CubePrefabs.Length)], SpawnPosition, Quaternion.identity);
                 
                    var velocityComponent = spawned.GetComponent<CubeAuthoring>();
                    float3 velocity = (Quaternion.Euler(0, 0, a) * new float3(0, 0, -1)) * Random.Range(0, 10f);
<<<<<<< HEAD
                    velocityComponent.Velocity = velocity;
=======
                    //velocityComponent.Value = velocity;
>>>>>>> origin/master

                    a += step;
                }
                yield return new WaitForSeconds(Random.Range(1, 3));
                ++i;
            }
            else break;
        }
    }


    void Awake()
    {
        float a = 0;
        float step = 360f / count;
        for(int i = 0; i < count; i++)
        {
            GameObject spawned = Instantiate(CubePrefab, transform.position,Quaternion.identity);
            //float size = Random.Range(2f, 5f);
            //spawned.transform.localScale = new Vector3(size, size, size);

            var velocityComponent = spawned.GetComponent<VelocityAuthoring>();
            float3 velocity = (Quaternion.Euler(0, 0, a) * new float3 (0,0,1)) * Random.Range(-1f, 8f);
            velocityComponent.Value = velocity;

            //var spriteRenderer = spawned.GetComponent<SpriteRenderer>();
            //var color = Color.HSVToRGB(Random.value, 0.3f, 1f);
            //spriteRenderer.color = color;

            a += step;
        } 
    }

}
 */