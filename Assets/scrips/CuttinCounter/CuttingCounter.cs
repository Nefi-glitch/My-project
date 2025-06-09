using System;
using UnityEngine;

public class CuttingCounter : BaseCounter, IHasProgress
{

    public static event EventHandler OnAnyCut;
    new public static void ResetStaticData()
    {
        OnAnyCut = null;
    }


    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
    public event EventHandler OnCut;

    [SerializeField] private CuttingRecepeSO[] cuttingRecepeArray;

    private int cuttingProgress;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasRecepeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {

                    player.GetKitchenObject().SetKitchenObjectPlayer(this);
                    cuttingProgress = 0;

                    CuttingRecepeSO cuttingRecepeSO = GetCuttingRecepeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        ProgressNormalized = (float)cuttingProgress / cuttingRecepeSO.cuttingProgressMax
                    });
                }
            }
            else
            {

            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                        GetKitchenObject().DestroySelf();
                }
            }
            else
            {
                GetKitchenObject().SetKitchenObjectPlayer(player);
            }


        }
    }
    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject() && HasRecepeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            cuttingProgress++;
            OnCut?.Invoke(this, EventArgs.Empty );
            OnAnyCut?.Invoke(this, EventArgs.Empty );


            CuttingRecepeSO cuttingRecepeSO = GetCuttingRecepeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

            OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
            {
                ProgressNormalized = (float)cuttingProgress / cuttingRecepeSO.cuttingProgressMax
            });

            if (cuttingProgress >= cuttingRecepeSO.cuttingProgressMax)
            {
                KitchenObjectSO outputKitchenObjectSO = GetOuputForInput(GetKitchenObject().GetKitchenObjectSO());

                GetKitchenObject().DestroySelf();

                KitchenObject.SpawnkitchenObject(outputKitchenObjectSO, this);
            }
            
          
        }
    }
    public bool HasRecepeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        CuttingRecepeSO cuttingRecepeSO = GetCuttingRecepeSOWithInput(inputKitchenObjectSO);
        return cuttingRecepeSO != null;
    }
    private KitchenObjectSO GetOuputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        CuttingRecepeSO cuttingRecepeSO = GetCuttingRecepeSOWithInput(inputKitchenObjectSO);
        if (cuttingRecepeSO != null)
        {
            return cuttingRecepeSO.output;
        }
        else
        {
            return null;
        }
    }
    private CuttingRecepeSO GetCuttingRecepeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecepeSO cuttingRecepeSO in cuttingRecepeArray)
        {
            if (cuttingRecepeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecepeSO;
            }
        }
        return null;
    }
}

