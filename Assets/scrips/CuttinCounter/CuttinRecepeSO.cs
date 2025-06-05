using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecepeSO : ScriptableObject
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public int cuttingProgressMax;
}
