using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {  get; private set; }




    [SerializeField] private AudioClipRefsSO AudioClipRefsSO;



    private void Awake()
    {
        Instance = this;
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



    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }




    public void PLayFootStepsSound(Vector3 position, float volume)
    {
        PlaySound(AudioClipRefsSO.footstep, position, volume);
    }
}
