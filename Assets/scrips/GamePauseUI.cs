using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button optionsButton;



    private void Awake()
    {
        resumeButton.onClick.AddListener(() =>
        {
            KitchenGameManager.Instace.TogglePauseGame();
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });

        optionsButton.onClick.AddListener(() =>
        {
            OptionsUI.Instance.Show();
        });
    }




    private void Start()
    {
        KitchenGameManager.Instace.OnGamePause += KitcheGameManager_OnGamePause;
        KitchenGameManager.Instace.OnGameUnPause += KitcheGameManager_OnGameUnPause;

        Hide();
    }

    private void KitcheGameManager_OnGameUnPause(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void KitcheGameManager_OnGamePause(object sender, System.EventArgs e)
    {
     Show();
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
