using Unity.Entities;
using Unity.Transforms;

public class CubeMoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.WithName("Move")
<<<<<<< HEAD
		.ForEach((ref Translation position, in Cube cube) =>
		{
			position.Value += cube.MoveVector * cube.Speed * deltaTime;
		}).Run();
=======
             .ForEach((ref Translation position, ref Velocity velocity) =>
             {
                 position.Value += velocity.MoveVector * velocity.Speed * deltaTime;
             }).Run();
>>>>>>> origin/master
    }
}
