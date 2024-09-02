using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderTicketUIController : MonoBehaviour
{
    private const int WIDTH_OFFSET = 80;

    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private Transform _recipeUIHolder;
    [SerializeField] private RecipeUIController _recipeUIPrefab;

    public RecipeSettings RecipeSetting { get; private set; }

    public void Init(RecipeSettings recipe)
    {
        RecipeSetting = recipe;

        _title.text = recipe.recipeName;
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(WIDTH_OFFSET * recipe.kitchenObjectSettingsList.Count, rectTransform.sizeDelta.y);

        foreach (KitchenObjectSettings kitchenObjectSetting in recipe.kitchenObjectSettingsList)
        {
            RecipeUIController recipeUIClone = Instantiate(_recipeUIPrefab, _recipeUIHolder);
            recipeUIClone.SetData(kitchenObjectSetting);
        }
    }
}
