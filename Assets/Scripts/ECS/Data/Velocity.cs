using Unity.Entities;
using Unity.Mathematics;

//[GenerateAuthoringComponent]
public struct Cube : IComponentData
{
    public float Speed;
    public float3 MoveVector;
    public bool Touched;
}
