using UnityEngine;
using Unity.Entities;
using UnityEngine.UI;


internal class ScoreAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public Text TextValue;
    public int Value;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Score() { TextValue = TextValue, Value = Value });
    }

}
