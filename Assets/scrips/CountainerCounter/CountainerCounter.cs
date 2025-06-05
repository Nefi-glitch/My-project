using System;
using UnityEngine;

public class CountainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {

KitchenObject.SpawnkitchenObject(kitchenObjectSO, player);


            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }

    }
    
}