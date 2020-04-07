using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class RotationSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        Entities.WithName("Rotate")
             .ForEach((ref Rotation rotation, in Triangle triangle) =>
             {
                 rotation.Value = math.mul(
                   rotation.Value,
                   quaternion.AxisAngle(new float3(0.0f, 0.0f, Random.Range(-1, 1)), Random.Range(5, 10) * deltaTime));
             }).Run();
    }
}
