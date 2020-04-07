using Unity.Entities;
using Unity.Mathematics;

//[GenerateAuthoringComponent]
public struct Velocity : IComponentData
{
    public float Speed;
    public float3 MoveVector;
    public bool Touched;
}
