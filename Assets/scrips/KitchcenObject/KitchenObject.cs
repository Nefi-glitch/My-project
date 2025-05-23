using UnityEngine;

public class KitcehnObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public  KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }
}
