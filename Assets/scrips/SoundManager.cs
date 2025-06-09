using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private const string PLAYER_SOUND_EFFECTS_VOLUME = "soundEffectsVolume";


    public static SoundManager Instance {  get; private set; }




    [SerializeField] private AudioClipRefsSO AudioClipRefsSO;


    private float volume = 1f;



    private void Awake()
    {
        Instance = this;

        volume = PlayerPrefs.GetFloat(PLAYER_SOUND_EFFECTS_VOLUME, 1f);
    }




    private void Start()
    {
        DeliveryManager.Instance.OnRecepeSuccess += DeliveyManager_OnRecepeSuccess;
        DeliveryManager.Instance.OnRecepeFailed += DeliveyManager_OnRecepeFailed;
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        Player.Instance.OnPickSomething += Player_OnPickSomething;
        BaseCounter.OnAnyObjectPlaceHere += BaseCounter_OnAnyObjectPlaceHere;
        TrashCounter.OnAnyObjectTrashed += TrashCounter_OnAnyObjectTrashed;
    }

    private void TrashCounter_OnAnyObjectTrashed(object sender, System.EventArgs e)
    {
       TrashCounter trashCounter = sender as TrashCounter;
        PlaySound(AudioClipRefsSO.objectDrop, trashCounter.transform.position);
    }

    private void BaseCounter_OnAnyObjectPlaceHere(object sender, System.EventArgs e)
    {
      BaseCounter baseCounter = sender as BaseCounter;
        PlaySound(AudioClipRefsSO.objectDrop, baseCounter.transform.position);
    }

    private void Player_OnPickSomething(object sender, System.EventArgs e)
    {
        PlaySound(AudioClipRefsSO.objectPickup, Player.Instance.transform.position);
    }

    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e)
    {
       CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(AudioClipRefsSO.chop, cuttingCounter.transform.position);
    }

    private void DeliveyManager_OnRecepeFailed(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(AudioClipRefsSO.deliveryFail, deliveryCounter.transform.position);
    }

    private void DeliveyManager_OnRecepeSuccess(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(AudioClipRefsSO.deliverySuccess, deliveryCounter.transform.position);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }



    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplayer = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplayer * volume);
    }




    public void PLayFootStepsSound(Vector3 position, float volume)
    {
        PlaySound(AudioClipRefsSO.footstep, position, volume);
    }



    public void PlayCountdownSound()
    {
        PlaySound(AudioClipRefsSO.warning, Vector3.zero);
    }



    public void PlayWarningSound(Vector3 position)
    {
        PlaySound(AudioClipRefsSO.warning, position);
    }




    public void ChangedVolume()
    {
        volume += 1f;

        if (volume > 1f)
        {
            volume = 0;
        }

        PlayerPrefs.SetFloat(PLAYER_SOUND_EFFECTS_VOLUME, volume);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return volume;
    }
}
