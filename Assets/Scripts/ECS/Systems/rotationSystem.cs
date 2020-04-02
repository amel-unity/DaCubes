using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Random = UnityEngine.Random;
public class rotationSystem : SystemBase
{
    protected override void OnUpdate()
    {

        float deltaTime = Time.DeltaTime;
        Entities.WithName("Rotate")
             .ForEach((ref Rotation rotation, in Triangle triangle) =>
             {
                 float rotationThisFrame = deltaTime * Random.Range(3,10);
                 var q = quaternion.AxisAngle(new float3(0.0f, 0.0f, Random.Range(-1, 1)), rotationThisFrame);
                 rotation.Value = math.mul(q, rotation.Value);

             }).Run();
    }
}
