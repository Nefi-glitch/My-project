using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCounter platesCounter;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform platesVisaulPrefab;


    private List<GameObject> platesVisualObjectList;

    private void Awake()
    {
        platesVisualObjectList = new List<GameObject>();
    }
    private void Start()
    {
        platesCounter.OnPlatesSpawned += PlatesCounter_OnPlatesSpawned;
        platesCounter.OnplatesRemoved += PlatesCounter_OnplatesRemoved;
    }

    private void PlatesCounter_OnplatesRemoved(object sender, System.EventArgs e)
    {
        GameObject platesGamesObject = platesVisualObjectList[platesVisualObjectList.Count - 1];
        platesVisualObjectList.Remove(platesGamesObject);
        Destroy(platesGamesObject);
    }

    private void PlatesCounter_OnPlatesSpawned(object sender, System.EventArgs e)
    {
        Transform platesVisualTransform = Instantiate(platesVisaulPrefab, counterTopPoint);

        float plateOffsetY = .1f;
        platesVisualTransform.localPosition = new Vector3(0, plateOffsetY * platesVisualObjectList.Count, 0);

        platesVisualObjectList.Add(platesVisualTransform.gameObject);
    }
}
