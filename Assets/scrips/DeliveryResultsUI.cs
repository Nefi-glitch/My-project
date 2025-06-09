using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultsUI : MonoBehaviour
{
    private const string POPUP = "PopUp";



    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI messegeText;
    [SerializeField] private Color successColor;
    [SerializeField] private Color failedColor;
    [SerializeField] private Sprite successSprite;
    [SerializeField] private Sprite failSprite;


    private Animator animator;



    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecepeSuccess += DliveryMnager_OnRecepeSuccess;
        DeliveryManager.Instance.OnRecepeFailed += DeliveryManager_OnRecepeFailed; 

        gameObject.SetActive(false);
    }

    private void DeliveryManager_OnRecepeFailed(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        backgroundImage.color = failedColor;
        iconImage.sprite = failSprite;
        messegeText.text = "DELIVERY\nFAILED";
    }

    private void DliveryMnager_OnRecepeSuccess(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);

        animator.SetTrigger(POPUP);
        backgroundImage.color = successColor;
        iconImage.sprite = successSprite;
        messegeText.text = "DELIVERY\nSUCCESS";
    }
}
