using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectPlayer
{

    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
  

    private KitchenObject kitchenObject;

    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {

            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectPlayer(this);
        }
        else
        {
        kitchenObject.SetKitchenObjectPlayer(player);
        }
        
    }
    public Transform GetKitchenObjectFollowTrasnform()
    {
        return counterTopPoint;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    public KitchenObject GetKitchenObject() {
        return kitchenObject; }

    public void ClearKitchenObejct()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject() { return kitchenObject != null; }
}

