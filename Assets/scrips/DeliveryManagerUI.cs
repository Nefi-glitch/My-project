using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform recepeTemplate;



    private void Awake()
    {
        recepeTemplate.gameObject.SetActive(false);
    }



    private void Start()
    {
        DeliveryManager.Instance.OnRecepeSpawned += DeliveryManager_OnRecepeSpawned;
        DeliveryManager.Instance.OnRecepeCompled += DeliveryManager_OnRecepeCompled;

        UpdateVisual();
    }

    private void DeliveryManager_OnRecepeCompled(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void DeliveryManager_OnRecepeSpawned(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }





    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == recepeTemplate) continue;
            Destroy(child.gameObject);
        }



        foreach (RecepeSO recepeSO in DeliveryManager.Instance.GetWaitingRecepeSOList())
        {
            Transform recepeTransform =  Instantiate(recepeTemplate, container);
            recepeTransform.gameObject.SetActive(true);
            recepeTransform.GetComponent<DeliverManagerSinglesUI>().SetRecepeSO(recepeSO);
        }
    }


    
           

}
