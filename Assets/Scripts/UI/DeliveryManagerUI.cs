using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;
    [SerializeField] private Transform deliveryResultUITransform;
    [SerializeField] private DeliveryResultUI deliveryResultUI;

    private bool isFirstTimeUpdatingDeliveryResultUI = true;

    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSpawned += DeliveryManager_OnRecipeSpawned;
        DeliveryManager.Instance.OnRecipeCompleted += DeliveryManager_OnRecipeCompleted;
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed; ;

        UpdateVisual();
    }

    #region TemporaryFix
    //Temporary fix for UI for Delivery result
    private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        if(isFirstTimeUpdatingDeliveryResultUI)
        {
            deliveryResultUITransform.gameObject.SetActive(true);
            deliveryResultUI.UpdateUIAccordingToDeliveryResult(isFirstTimeUpdatingDeliveryResultUI, false);
            Debug.Log("Pehli Baar hua hai");
            isFirstTimeUpdatingDeliveryResultUI = false;
        }
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        if(isFirstTimeUpdatingDeliveryResultUI)
        {
            deliveryResultUITransform.gameObject.SetActive(true);
            deliveryResultUI.UpdateUIAccordingToDeliveryResult(isFirstTimeUpdatingDeliveryResultUI, true);
            Debug.Log("Pehli Baar hua hai");
            isFirstTimeUpdatingDeliveryResultUI = false;
        }
    }
    //Temporary fix for UI for Delivery result
    #endregion TemporaryFix

    private void DeliveryManager_OnRecipeCompleted(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void DeliveryManager_OnRecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach(Transform child in container)
        {
            if (child == recipeTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach(RecipeSO recipeSO in DeliveryManager.Instance.GetWaitingRecipeSOList())
        {
            Transform recipeTransform = Instantiate(recipeTemplate, container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.GetComponent<DeliveryManagerSingleUI>().SetRecipeSO(recipeSO);
        }
    }

}
