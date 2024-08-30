using System;

public interface IIngredientTracker
{
    public event Action<KitchenObjectSettings> OnIngredientChange;
}
