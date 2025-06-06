using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectPlayer(this);
            }
            else
            {

            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObeject plateKitchenObeject))
                {
                   if ( plateKitchenObeject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    GetKitchenObject().DestroySelf();
                }
                else
                {
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObeject))
                    {
                        if (plateKitchenObeject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else
            {
                GetKitchenObject().SetKitchenObjectPlayer(player);
            }


        }
    }
  
}

