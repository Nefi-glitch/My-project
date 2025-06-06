using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class GameStartUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;





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
        countdownText.text = Mathf.Ceil (KitchenGameManager.Instace.GetCountDownToStartTimer()).ToString(); 
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
