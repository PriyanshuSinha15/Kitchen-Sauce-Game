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
        platesCounter.OnPlateGrabbed += PlatesCounter_OnPlateGrabbed;
    }

    private void PlatesCounter_OnPlateGrabbed(object sender, PlatesCounter.OnPlateGrabbedEventArgs e)
    {
        GameObject platesVisualGameObject = platesVisualGameObjectList[platesVisualGameObjectList.Count - 1];
        platesVisualGameObjectList.Remove(platesVisualGameObject);
        platesVisualGameObject.SetActive(false);
    }

    private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(platesVisualPrefab, counterTopPoint);

        float offsetY = 0.1f;
        plateVisualTransform.localPosition = new Vector3(0, offsetY * platesVisualGameObjectList.Count, 0);

        platesVisualGameObjectList.Add(plateVisualTransform.gameObject);
    }
}
