using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectPlayer kitchenObjectPlayer;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetKitchenObjectPlayer(IKitchenObjectPlayer kitchenObjectPlayer)
    {
        if (this.kitchenObjectPlayer != null)
        {
            this.kitchenObjectPlayer.ClearKitchenObejct();
        }
        this.kitchenObjectPlayer = kitchenObjectPlayer;

        if (kitchenObjectPlayer.HasKitchenObject())
        {
            Debug.LogError(" kitchenObjectPlayer already has kitchenobject");
        }
        kitchenObjectPlayer.SetKitchenObject(this);

        this.kitchenObjectPlayer = kitchenObjectPlayer;
        transform.parent = kitchenObjectPlayer.GetKitchenObjectFollowTrasnform();

        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectPlayer GetKitchenObjectPlayer()
    {
        return kitchenObjectPlayer;
    }
    public void DestroySelf()
    {
        kitchenObjectPlayer.ClearKitchenObejct();

        Destroy(gameObject);
    }


    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject)
        {

        if (this is PlateKitchenObject)
        {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        }
        else
        {
            plateKitchenObject = null;
            return false;
        }
    }

    
    




    public static KitchenObject SpawnkitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenObjectPlayer kitchenObjectPlayer)
    {

        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>(); 
        kitchenObject.SetKitchenObjectPlayer(kitchenObjectPlayer);

        return kitchenObject;
    }
}


