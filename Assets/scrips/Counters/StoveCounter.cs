using System;
using System.Collections;
using UnityEngine;
using static CuttingCounter;

public class StoveCounter : BaseCounter, IHasProgress
{

    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs
    {
        public State state;
    }
    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burned,
    }



    [SerializeField] private FryingRecepeSO[] fryingRecepeSOArray;
    [SerializeField] private BurningRecepeSO[] burningRecepeSOArray;



    private State state;
    private float fryingTimer;
    private FryingRecepeSO fryingRecepeSO;
    private float burningTimer;
    private BurningRecepeSO burningRecepeSO;


    private void Start()
    {
        state = State.Idle;
    }
    private void Update()
    {
        if (HasKitchenObject())
        {
            switch (state)
            {


                case State.Idle:
                    break;

                case State.Frying:
                    fryingTimer += Time.deltaTime;


                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        ProgressNormalized = fryingTimer / fryingRecepeSO.fryingTimerMax
                    });



                    if (fryingTimer > fryingRecepeSO.fryingTimerMax)
                    {

                        GetKitchenObject().DestroySelf();

                        KitchenObject.SpawnkitchenObject(fryingRecepeSO.output, this);

                        state = State.Fried;
                        burningTimer = 0f;
                        burningRecepeSO = GetBurningRecepeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                        OnStateChanged?.Invoke(this,new OnStateChangedEventArgs
                        {
                           state = state
                        });
                    }
                    break;


                case State.Fried:
                    burningTimer += Time.deltaTime;


                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        ProgressNormalized = burningTimer / burningRecepeSO.burningTimerMax
                    });



                    if (burningTimer > burningRecepeSO.burningTimerMax)
                    {

                        GetKitchenObject().DestroySelf();

                        KitchenObject.SpawnkitchenObject(burningRecepeSO.output, this);

                        state = State.Burned;
                        burningTimer = 0f;
                    }

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        ProgressNormalized = 0f
                    });
                    break;


                case State.Burned:

                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                    {
                        state = state
                    });

                    break;
            }
        }

    }





    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasRecepeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {

                    player.GetKitchenObject().SetKitchenObjectPlayer(this);
                    fryingRecepeSO = GetFryingRecepeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                    state = State.Frying;
                    fryingTimer = 0f;

                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                    {
                        state = state
                    });

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                       ProgressNormalized = fryingTimer / fryingRecepeSO.fryingTimerMax
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

                state = State.Idle;
                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                {
                    state = state
                });


                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                {
                    ProgressNormalized = 0f
                });
            }


        }
    }
    public bool HasRecepeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecepeSO fryingRecepeSO = GetFryingRecepeSOWithInput(inputKitchenObjectSO);
        return fryingRecepeSO != null;
    }
    private KitchenObjectSO GetOuputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecepeSO fryingRecepeSO = GetFryingRecepeSOWithInput(inputKitchenObjectSO);
        if (fryingRecepeSO != null)
        {
            return fryingRecepeSO.output;
        }
        else
        {
            return null;
        }
    }
    private FryingRecepeSO GetFryingRecepeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (FryingRecepeSO fryingRecepeSO in fryingRecepeSOArray)
        {
            if (fryingRecepeSO.input == inputKitchenObjectSO)
            {
                return fryingRecepeSO;
            }
        }
        return null;
    }

    private BurningRecepeSO GetBurningRecepeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (BurningRecepeSO burningRecepeSO in burningRecepeSOArray)
        {
            if (burningRecepeSO.input == inputKitchenObjectSO)
            {
                return burningRecepeSO;
            }
        }
        return null;
    }
}
