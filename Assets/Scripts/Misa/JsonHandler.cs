using System;
using System.IO;
using UnityEditorInternal;
using UnityEngine;

public class JsonHandler : MonoBehaviour
{
    public PointsManager pointsManager;
    public POIManager  poiManager;
    public GameObject dataPrefab;
    private void Start()
    {
        LoadFile();
    }

    public void LoadFile()
    {
            TextAsset mytxtData = (TextAsset)Resources.Load("points");
            string content = mytxtData.text;
            pointsManager = JsonUtility.FromJson<PointsManager>(content);

            poiManager.pois.Clear();
            for (int i = 0; i < pointsManager.points.Length; i++)
            {
                POIData newPOIData = new POIData();
                newPOIData.prefab = dataPrefab;
                newPOIData.latitude = double.Parse(pointsManager.points[i].latitude);
                newPOIData.longitude = double.Parse(pointsManager.points[i].longitude);
                poiManager.pois.Add(newPOIData);
            }
        
        
    }

    [ContextMenu("Print Json")]
    public void PrintJsonSample()
    {
        string json = JsonUtility.ToJson(pointsManager, true);
        Debug.Log(json);
    }
}
