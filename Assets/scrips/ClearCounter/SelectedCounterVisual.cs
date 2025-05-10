using System.Runtime.CompilerServices;
using UnityEditor.Search;
using UnityEngine;

public class SelectCounterVisual : MonoBehaviour
{
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterCangedEventArgs e)
    {
        if (e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

      private void Show()
    {
        visualGameObject.SetActive(true);
    }
        private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
