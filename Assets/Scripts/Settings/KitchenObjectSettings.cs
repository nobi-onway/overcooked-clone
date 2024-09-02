using UnityEngine;

[CreateAssetMenu()]
public class KitchenObjectSettings : ScriptableObject
{
    public Transform prefab;
    public string objectName;
    public Sprite sprite;
    public Sprite processedSprite;
    public int Id => name.GetHashCode();
}
