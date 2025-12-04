using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCounter platesCounter;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform platesVisualPrefab;

    private List<GameObject> platesVisualGameObjectList;
    // Start is called before the first frame update
    private void Awake()
    {
        platesVisualGameObjectList = new List<GameObject>();
    }

    void Start()
    {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;   
    }

    private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(platesVisualPrefab, counterTopPoint);

        float offsetY = 0.1f;
        plateVisualTransform.localPosition = new Vector3(0, offsetY * platesVisualGameObjectList.Count, 0);

        platesVisualGameObjectList.Add(plateVisualTransform.gameObject);
    }
}
