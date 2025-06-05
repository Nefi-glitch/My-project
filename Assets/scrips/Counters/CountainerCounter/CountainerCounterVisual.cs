using UnityEngine;

public class CountainerCounterVisual : MonoBehaviour
{
    private const string OPEN_CLOSED = "openClosed";

    [SerializeField] private CountainerCounter countainerCounter;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        countainerCounter.OnPlayerGrabbedObject += CountainerCounter_OnPlayerGrabbedObject;
    }

    private void CountainerCounter_OnPlayerGrabbedObject(object sender, System.EventArgs e)
    {
        animator.SetTrigger(OPEN_CLOSED);
    }
}
