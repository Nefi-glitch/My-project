using UnityEngine;

public class Animation : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    [SerializeField] private Player Player;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
        {
        animator.SetBool(IS_WALKING, Player.IsWalking());
    }
}
