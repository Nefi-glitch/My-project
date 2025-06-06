using System;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObeject plateKitchenObeject;
    [SerializeField] private Transform iconTemplate;



    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        plateKitchenObeject.OnIngredientAdded += PlateKitchenObeject_OnIngredientAdded;
    }

    private void PlateKitchenObeject_OnIngredientAdded(object sender, PlateKitchenObeject.OnIngredientAddedEventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == iconTemplate) continue;
            Destroy (child.gameObject);
        }
        foreach (KitchenObjectSO kitchenObjectSO in plateKitchenObeject.GetKitchenObjectSOList())
        {
          Transform iconTransform = Instantiate(iconTemplate, transform);
            iconTemplate.gameObject.SetActive (true);
            iconTransform.GetComponent<PlateIconsUI>().SetKitchenObejctSO(kitchenObjectSO);
        }
    }

    private void SetKitchenObejctSO(KitchenObjectSO kitchenObjectSO)
    {
    
    }
}
