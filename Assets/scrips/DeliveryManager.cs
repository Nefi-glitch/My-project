using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{

    public event EventHandler OnRecepeSpawned;
    public event EventHandler OnRecepeCompled;
    public event EventHandler OnRecepeSuccess;
    public event EventHandler OnRecepeFailed;





    public static DeliveryManager Instance { get; private set; }
    [SerializeField] private RecepeListSO recepeListSO;



    private List<RecepeSO> waitingRecepeSOList;
    private float spawnRecepeTimer;
    private float spawnRecepeTimerMax = 4f;
    private int waitingRecepeMax = 4;
    private int successfullRecepeAmount;



    private void Awake()
    {
        Instance = this;

        waitingRecepeSOList = new List<RecepeSO>();
    }



    private void Update()
    {
        spawnRecepeTimer -= Time.deltaTime;
        if (spawnRecepeTimer <= 0f)
        {
            spawnRecepeTimer = spawnRecepeTimerMax;

            if (KitchenGameManager.Instace.IsGamePlaying() && waitingRecepeSOList.Count < waitingRecepeMax)
            {
                RecepeSO waitingRecepeSO = recepeListSO.recepeSOList[UnityEngine.Random.Range(0, recepeListSO.recepeSOList.Count)];

                waitingRecepeSOList.Add(waitingRecepeSO);

                OnRecepeSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }


    public void DeliveryRecepe(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingRecepeSOList.Count ; i++)
        {
            RecepeSO waitingRecepeSO = waitingRecepeSOList[i];

            if (waitingRecepeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {
                bool plateContentMatchesRecepe = true;

                foreach (KitchenObjectSO recepekitchenObjectSO in waitingRecepeSO.kitchenObjectSOList)

                {
                    bool ingredientFound = false;
                    foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())

                    {
                        if (plateKitchenObjectSO == recepekitchenObjectSO)
                        {
                            ingredientFound = true;
                            break;
                        }
                    }
                    if (!ingredientFound)
                    {
                        plateContentMatchesRecepe = false;
                    }
                }


                if (plateContentMatchesRecepe)
                {
                    successfullRecepeAmount ++;

                    waitingRecepeSOList.RemoveAt(i);

                    OnRecepeCompled?.Invoke(this, EventArgs.Empty);
                    OnRecepeSuccess?.Invoke(this, EventArgs.Empty);

                    return;
                }
            }
        }
        OnRecepeFailed?.Invoke(this, EventArgs.Empty);

    }


    public List<RecepeSO> GetWaitingRecepeSOList()
    {
        return waitingRecepeSOList;
    }

    public int GetSuccessRecepesAmount()
    {
        return successfullRecepeAmount;
    }
}
