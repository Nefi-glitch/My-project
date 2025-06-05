using System;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlatesSpawned;
    public event EventHandler OnplatesRemoved;




    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;



    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int platesSpawnAmount;
    private int platesSpawnAmountMax = 4;




    private void Update()
    {
        spawnPlateTimer = Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax) 
        {
            spawnPlateTimer = 0f;

            if (platesSpawnAmount < platesSpawnAmountMax)
            {
                platesSpawnAmount++;

                OnPlatesSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            if (platesSpawnAmount > 0)
            {
                platesSpawnAmount--;

           KitchenObject.SpawnkitchenObject(plateKitchenObjectSO, player);

                OnplatesRemoved?.Invoke(this, EventArgs.Empty); 
            }
        }
    }
}
