using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recepeDeliveredText;



        private void Start()
        {
            KitchenGameManager.Instace.OnsTateGamweChanged += KitchenGameManager_OnsTateGamweChanged;

            Hide();
        }

        private void KitchenGameManager_OnsTateGamweChanged(object sender, System.EventArgs e)
        {
            if (KitchenGameManager.Instace.IsGameOver())
            {
                Show();

                recepeDeliveredText.text = DeliveryManager.Instance.GetSuccessRecepesAmount().ToString();
            }
            else
            {
                Hide();
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
