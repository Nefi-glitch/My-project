using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
private Player Player;
    private float footstepTimer;
    private float footstepTimeMax = .1f;





    private void Awake()
    {
        Player = GetComponent<Player>();
    }






    private void Update()
    {
        footstepTimer = Time.deltaTime;
        if (footstepTimer < 0f)
        {
            footstepTimer += footstepTimeMax;



           

            if (Player.IsWalking())
            {
                float volume = 1f;

                SoundManager.Instance.PLayFootStepsSound(Player.transform.position, volume);
            }
        }
    }
}
