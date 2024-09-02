using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderTicketHolderUI : MonoBehaviour
{
    [SerializeField] private OrderTicketUIController _orderTicketUI;
    private List<OrderTicketUIController> _orderTicketUIList;

    private void Start()
    {
        _orderTicketUIList = new List<OrderTicketUIController>();

        TaskManager.Instance.OnAddNewOrderTicket += (recipeSetting) =>
        {
            OrderTicketUIController orderTicketClone = Instantiate(_orderTicketUI, this.transform);
            orderTicketClone.Init(recipeSetting);

            _orderTicketUIList.Add(orderTicketClone);
        };

        TaskManager.Instance.OnRemoveOrderTicket += (recipeSetting) =>
        {
            OrderTicketUIController orderTicket = _orderTicketUIList.Find(orderTicket => orderTicket.RecipeSetting == recipeSetting);
            _orderTicketUIList.Remove(orderTicket);

            Destroy(orderTicket.gameObject);
        };
    }
}
