using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler<OnPlateGrabbedEventArgs> OnPlateGrabbed;

    public class OnPlateGrabbedEventArgs : EventArgs
    {
        public int platesSpawnedAmount;
    }

    [SerializeField] KitchenObjectSO plateKitchenObjectSO;

    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    [SerializeField] private int platesSpawnedAmount;
    private int platesSpawnedAmountMax = 4;
    
    // Update is called once per frame
    void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if(spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0f;
            
            if(platesSpawnedAmount < platesSpawnedAmountMax)
            {
                platesSpawnedAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if(platesSpawnedAmount > 0)
        {
            KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);
            platesSpawnedAmount--;
            OnPlateGrabbed?.Invoke(this, new OnPlateGrabbedEventArgs
            {
                platesSpawnedAmount = platesSpawnedAmount
            });
        }
    }
}
