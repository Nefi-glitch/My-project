using UnityEngine;

public class ClearCounter : MonoBehaviour
{
 
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform tomatoPrefab;

    public void Interact()
    {
       Debug.Log("Interact");

       Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
       kitchenObjectTransform.localPosition = Vector3.zero;
    }
}
