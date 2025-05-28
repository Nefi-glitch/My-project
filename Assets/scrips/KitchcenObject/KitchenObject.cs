using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public  KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this.clearCounter != null) 
        { 
            this.clearCounter.ClearKitchenObejct();
        }
        this.clearCounter = clearCounter;

        if (clearCounter.HasKitchenObject())
        {
            Debug.LogError("counter already has kitchenobject");
        }
        clearCounter.SetKitchenObject(this);

        this.clearCounter = clearCounter;
        transform.parent = clearCounter.GetKitchenObjectFollowTrasnform();

        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}
