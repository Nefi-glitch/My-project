using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliverManagerSinglesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recepeNmaeText;
    [SerializeField] private Transform iconContainer;
    [SerializeField] private Transform iconTemplate;







    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }




    public void SetRecepeSO (RecepeSO recepeSO)
    {
        recepeNmaeText.text = recepeSO.recepeName;



        foreach (Transform child in iconContainer)
        {
            if (child == iconTemplate)continue;
            Destroy(child.gameObject);
        }



        foreach(KitchenObjectSO kitchenObjectSO in recepeSO.kitchenObjectSOList)
        {
            Transform iconTransform = Instantiate(iconTemplate, iconContainer);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<Image>().sprite = kitchenObjectSO.sprite;
        }
    }
}
