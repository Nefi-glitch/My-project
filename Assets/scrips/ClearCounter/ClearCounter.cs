using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectOS kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    public void Interact()
    {
        Debug.Log("Interact");
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
        kitchenObjectTransform.localPosition = Vector3.zero;

        Debug.Log(KitchenObjectTransform.GetComponent <KitchenObjectTransform> ().GetKitchenObjectSO().obejctName);
    }
}
