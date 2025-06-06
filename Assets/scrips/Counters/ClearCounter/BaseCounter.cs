using System;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectPlayer
{
    public static event EventHandler OnAnyObjectPlaceHere;


    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;
    public virtual void Interact (Player player)
   {
        Debug.LogError ("BaseCounter.Interact();");
   }
    public virtual void InteractAlternate(Player player)
    {
       // Debug.LogError("BaseCounter.InteractAlternate();");
    }
    public Transform GetKitchenObjectFollowTrasnform()
    {
        return counterTopPoint;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;

        if (kitchenObject != null)
        {
            OnAnyObjectPlaceHere?.Invoke(this, EventArgs.Empty);
        }
        
    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObejct()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject() { return kitchenObject != null; }
}
