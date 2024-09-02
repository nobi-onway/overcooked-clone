using UnityEngine;
using UnityEngine.UI;

public class RecipeUIController : MonoBehaviour
{
    [SerializeField] private Image _icon; 
    public void SetData(KitchenObjectSettings kitchenObjectSettings)
    {
        _icon.sprite = kitchenObjectSettings.processedSprite;
    }
}
