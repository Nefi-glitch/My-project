using System;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public event EventHandler OnCut;
    public class OnProgressChangedEventArgs : EventArgs
    {
        public float ProgressNormalized;
    }

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

                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
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
            CuttingRecepeSO cuttingRecepeSO = GetCuttingRecepeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
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

