using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconUI : MonoBehaviour
{
    [SerializeField] PlateKitchenObject plateKitchenObject;

    private void Start()
    {
        plateKitchenObject.OnIngredientsAdded += PlateKitchenObject_OnIngredientsAdded;
    }

    private void PlateKitchenObject_OnIngredientsAdded(object sender, PlateKitchenObject.OnIngredientsAddedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}
