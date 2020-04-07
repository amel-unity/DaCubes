using Unity.Entities;
using Unity.Transforms;

public class CubeMoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        Entities.WithName("Move")
             .ForEach((ref Translation position, ref Velocity velocity) =>
             {
                 velocity.Value += velocity.MoveVector * deltaTime;
                 position.Value += velocity.Value * deltaTime;
             }).Run();
    }
}
