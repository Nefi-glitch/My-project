using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class GameStartUI : MonoBehaviour
{
    private const string NUMBER_POPUP = "NumberPopUp";



    [SerializeField] private TextMeshProUGUI countdownText;



    private Animator animator;
    private int previousCountdownNumber;



    private void Awake()
    {
        animator = GetComponent<Animator>();
    }




    private void Start()
    {
        KitchenGameManager.Instace.OnsTateGamweChanged += KitchenGameManager_OnsTateGamweChanged;

        Hide();
    }

    private void KitchenGameManager_OnsTateGamweChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instace.IsCountDownToStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }



    private void Update()
    {
        int countDownNumber = Mathf.CeilToInt(KitchenGameManager.Instace.GetCountDownToStartTimer());
        countdownText.text =   countDownNumber.ToString();

        if (previousCountdownNumber != countDownNumber)
        {
            previousCountdownNumber = countDownNumber;  
            animator.SetTrigger(NUMBER_POPUP);
            SoundManager.Instance.PlayCountdownSound();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
      
    }

    
  
    
    
}
