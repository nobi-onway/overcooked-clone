using UnityEngine;

[CreateAssetMenu()]
public class KitchenObjectSettings : ScriptableObject
{
    public Transform visualPrefab;
    public string objectName;
    public Sprite sprite;
    public int Id => name.GetHashCode();
}
