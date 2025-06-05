using UnityEngine;

[CreateAssetMenu()]
public class FryingRecepeSO : ScriptableObject
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float fryingTimerMax;
}
