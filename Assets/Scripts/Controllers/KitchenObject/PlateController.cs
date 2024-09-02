using System;
using System.Collections.Generic;
using UnityEngine;
public class PlateController : KitchenObjectController, IContainableObject, IChangableVisual, IIngredientTracker
{
    [SerializeField] private List<KitchenObjectSettings> _containableKitchenObjectSettingsList;

    private List<KitchenObjectSettings> _currentContainedKitchenObjectList = new List<KitchenObjectSettings>();

    public int VisualIndex { get; private set; }

    public List<KitchenObjectSettings> Ingredient { get; private set; }
    public event Action<KitchenObjectSettings> OnIngredientChange;

    public event Action<int> OnVisualChange;

    protected override void SetActivated(bool isActivated)
    {
        IsActivated = isActivated;
    }

    public override void Reset()
    {
        SetActivated(false);
    }

    public override void ReturnToPool()
    {
        SetActivated(true);
        _currentContainedKitchenObjectList.Clear();
        SetVisual(-1);
        OnIngredientChange?.Invoke(null);
        InvokeReturnToPoolAction();
    }

    public bool TryContainObject(IKitchenObject kitchenObject)
    {
        if (!kitchenObject.IsProcessed) return false;

        KitchenObjectSettings kitchenSettings = kitchenObject.GetData();

        if (_currentContainedKitchenObjectList.Contains(kitchenSettings)) return false;
        if (!_containableKitchenObjectSettingsList.Contains(kitchenSettings)) return false;
        
        _currentContainedKitchenObjectList.Add(kitchenSettings);
        SetVisual(_containableKitchenObjectSettingsList.FindIndex(setting => setting.Id == kitchenSettings.Id));
        OnIngredientChange?.Invoke(kitchenSettings);

        return true;
    }

    private void SetVisual(int visualIndex)
    {
        VisualIndex = visualIndex;
        OnVisualChange?.Invoke(visualIndex);
    }

    public List<KitchenObjectSettings> GetContainedKitchenObject()
    {
        return _currentContainedKitchenObjectList;
    }
}
