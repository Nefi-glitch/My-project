using UnityEngine;

[CreateAssetMenu()]
public class BurningRecepeSO : ScriptableObject
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float burningTimerMax;
}
