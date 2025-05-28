using UnityEngine;

public class ClearCounter : MonoBehaviour
{

    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KitchenObject kitchenObject;

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObjectSO != null)
            {
                kitchenObject.SetClearCounter(secondClearCounter);
            }
        }
    }
    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {

            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;
            kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
        }
        else
        {
            Debug.Log(kitchenObject.GetClearCounter());
            kitchenObject.SetClearCounter(secondClearCounter)
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

