using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private const int ORDER_RATE_TIME = 4;
    private const int ORDER_TICKET_CAPACITY = 4;

    [SerializeField] private RecipeSettings[] _recipeSettingsArray;

    public static TaskManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        if (Instance != this) Destroy(this.gameObject);
    }

    private List<RecipeSettings> _orderTicketList;
    public event Action<RecipeSettings> OnAddNewOrderTicket;
    public event Action<RecipeSettings> OnRemoveOrderTicket;

    private void Start()
    {
        _orderTicketList = new List<RecipeSettings>();
        StartCoroutine(CreateOrder());
    }

    private IEnumerator CreateOrder()
    {
        while(true)
        {
            yield return new WaitForSeconds(ORDER_RATE_TIME);
            if (_orderTicketList.Count >= ORDER_TICKET_CAPACITY) continue;

            int index = UnityEngine.Random.Range(0, _recipeSettingsArray.Length);
            _orderTicketList.Add(_recipeSettingsArray[index]);

            OnAddNewOrderTicket?.Invoke(_recipeSettingsArray[index]);
        }
    }

    public bool TryHandleDelivery(List<KitchenObjectSettings> kitchenObjectSettingsList)
    {
        foreach(RecipeSettings recipe in _orderTicketList)
        {
            if (kitchenObjectSettingsList.Count != recipe.kitchenObjectSettingsList.Count) continue;

            bool isMatchedRecipe = kitchenObjectSettingsList.Count > 0; 

            foreach(KitchenObjectSettings kitchenObjectSettings in kitchenObjectSettingsList)
            {
                if (recipe.kitchenObjectSettingsList.Contains(kitchenObjectSettings)) continue;

                isMatchedRecipe = false;
            }

            if (!isMatchedRecipe) continue;

            _orderTicketList.Remove(recipe);
            OnRemoveOrderTicket?.Invoke(recipe);
            return true;
        }

        return false;
    }
}