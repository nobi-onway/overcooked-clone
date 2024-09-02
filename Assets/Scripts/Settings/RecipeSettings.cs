using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu()]
public class RecipeSettings : ScriptableObject
{
    public string recipeName;
    public int Id => recipeName.GetHashCode();
    public List<KitchenObjectSettings> kitchenObjectSettingsList;
}
