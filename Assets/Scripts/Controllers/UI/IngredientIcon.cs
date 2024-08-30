using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IngredientIcon : MonoBehaviour
{
    [SerializeField] private Image _icon;
    public void Init(Sprite sprite)
    {
        _icon.sprite = sprite;
    }
}
