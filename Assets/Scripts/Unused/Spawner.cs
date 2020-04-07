using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Random = UnityEngine.Random;

/* public class Spawner : MonoBehaviour
{
    public GameObject SpritePrefab;
    public int count = 100;

    void Awake()
    {
        float a = 0;
        float step = 360f / count;
        for(int i = 0; i < count; i++)
        {
            GameObject spawned = Instantiate(SpritePrefab, transform.position,Quaternion.identity);
            float size = Random.Range(2f, 5f);
            spawned.transform.localScale = new Vector3(size, size, size);

            var velocityComponent = spawned.GetComponent<CubeAuthoring>();
            Vector3 velocity = (Quaternion.Euler(0, 0, a) * math.up())* Random.Range(4f,12f);

            velocityComponent.Speed = velocity;

            var spriteRenderer = spawned.GetComponent<SpriteRenderer>();
            var color = Color.HSVToRGB(Random.value, 0.3f, 1f);
            spriteRenderer.color = color;

            a += step;
        }
    }
} */
