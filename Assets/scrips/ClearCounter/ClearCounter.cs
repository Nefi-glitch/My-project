using UnityEngine;

public class ClearCounter : MonoBehaviour
{

    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private KitcehnObject kitcehnObject;

    public void Interact()
    {
        if (kitcehnObject == null)
        {

            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;

            kitcehnObject = kitchenObjectTransform.GetComponent<KitcehnObject>();
            kitcehnObject.SetClearCounter(this);
        }
        else
        {
            Debug.Log(kitcehnObject.GetClearCounter());
        }
        
    }
}
