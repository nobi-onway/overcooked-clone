using System.Collections.Generic;
using UnityEngine;

public class IngredientsIndicator : MonoBehaviour
{
    [SerializeField] private Transform _ingredientHolder;
    [SerializeField] private IngredientIcon _ingredientPrefab;

    private CanvasGroup _canvasGroup;

    private List<IngredientIcon> _ingredientList;
    private IIngredientTracker _ingredientTracker;
    private void Start()
    {
        _ingredientList = new List<IngredientIcon>();
        _ingredientTracker = GetComponentInParent<IIngredientTracker>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;

        _ingredientTracker.OnIngredientChange += (setting) =>
        {
            if (setting == null) { ClearIngredientList(); return; }

            IngredientIcon ingredientIconClone = Instantiate(_ingredientPrefab, _ingredientHolder.transform);
            ingredientIconClone.Init(setting.sprite);

            _ingredientList.Add(ingredientIconClone);
            _canvasGroup.alpha = 1;
        };
    }

    private void ClearIngredientList()
    {
        foreach(IngredientIcon ingredient in _ingredientList)
        {
            Destroy(ingredient.gameObject);
        }

        _ingredientList.Clear();
        _canvasGroup.alpha = 0;
    }
}
