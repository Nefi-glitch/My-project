using UnityEngine;

public interface IKitchenObjectPlayer 
{
    public Transform GetKitchenObjectFollowTrasnform();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();


    public void ClearKitchenObejct();

    public bool HasKitchenObject();
}
