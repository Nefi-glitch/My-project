using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecepeSO : ScriptableObject
{
    public List<KitchenObjectSO> kitchenObjectSOList;
    public string recepeName;
}
