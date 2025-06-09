using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{

    public static OptionsUI Instance { get; private set; }



    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI MusicffectsText;
    [SerializeField] private TextMeshProUGUI MoveUpText;
    [SerializeField] private TextMeshProUGUI MoveDownText;
    [SerializeField] private TextMeshProUGUI MoveLeftText;
    [SerializeField] private TextMeshProUGUI MoveRightText;
    [SerializeField] private TextMeshProUGUI InteractText;
    [SerializeField] private TextMeshProUGUI InteractAlternateText;
    [SerializeField] private TextMeshProUGUI PauseUpText;
    [SerializeField] private Transform pressToRebindKeyTransform;







    private void Awake()
    {
        Instance = this;
        soundEffectsButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangedVolume();
            UpdateVisual();
        });

        musicButton.onClick.AddListener(() =>
        {MusciManagerUI.Instance.ChangedVolume();
        });


        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });





        moveUpButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Up); });
        moveDownButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Down); });
        moveLeftButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Left); });
        moveRightButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Right); });
        interactButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.interact); });
        interactAlternateButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.interactAlterante); });
        pauseButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Pause); });

    }

    private void Start()
    {
        KitchenGameManager.Instace.OnGameUnPause += KitchenGameManager_OnGameUnPause;

        UpdateVisual();
        HidePressToRebindKey();
        Hide();
    }

    private void KitchenGameManager_OnGameUnPause(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEffectsText.text = "Sond Effects:" + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        soundEffectsText.text = "Music:" + Mathf.Round(MusciManagerUI.Instance.GetVolume() * 10f);


        MoveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        MoveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        MoveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        MoveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        InteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.interact);
        InteractAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.interactAlterante);
        PauseUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);

    }




    public void Show()
    {
        gameObject.SetActive(true);
    }




    public void Hide()
    {
        gameObject.SetActive(false);
    }




    private void ShowPressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }


    private void HidePressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(false);
    }



    private void RebindBinding (GameInput.Binding binding)
    {
        ShowPressToRebindKey();
        GameInput.Instance.RebinBinding(binding, () =>
        {
            HidePressToRebindKey();
            UpdateVisual();
        });
    }
}


