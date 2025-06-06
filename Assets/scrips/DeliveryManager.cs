using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private RecepeListSO recepeListSO;



    private List<RecepeSO> waitingRecepeSOList;
    private float spawnRecepeTimer;
    private float spawnRecepeTimerMax = 4f;
    private int waitingRecepeMax = 4;



    private void Awake()
    {
        waitingRecepeSOList = new List<RecepeSO>();
    }



    private void Update()
    {
        spawnRecepeTimer -= Time.deltaTime;
        if (spawnRecepeTimer <= 0f)
        {
            spawnRecepeTimer = spawnRecepeTimerMax;

            if (waitingRecepeSOList.Count < waitingRecepeMax)
            {
                RecepeSO waittingRecepeSO = recepeListSO.recepeSOList[Random.Range(0, recepeListSO.recepeSOList.Count)];
                waitingRecepeSOList.Add(waittingRecepeSO);
            }
        }
    }


    public void DeliveryRecepe(PlateKitchenObeject plateKitchenObeject)
    {
        for (int i = 0; i < waitingRecepeSOList.Count ; i++)
        {
            RecepeSO waitingRecepeSO = waitingRecepeSOList[i];

            if (waitingRecepeSO.kitchenObjectSOList.Count == plateKitchenObeject.GetKitchenObjectSOList().Count)
            {
                bool plateContentMatchesRecepe = true;

                foreach (KitchenObjectSO recepekitchenObjectSO in waitingRecepeSOList.kitchenObjectSOList)
                {


                    bool ingredientFound = false;
                    foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObeject.GetKitchenObjectSOList().kitchenObjectSOList())
                    {
                        if (plateKitchenObjectSO == recepekitchenObjectSO)
                        {
                            ingredientFound = false;
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
                    waitingRecepeSOList.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
