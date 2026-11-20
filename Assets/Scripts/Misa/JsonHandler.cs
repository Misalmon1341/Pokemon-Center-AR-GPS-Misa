using System;
using System.IO;
using UnityEditorInternal;
using UnityEngine;

public class JsonHandler : MonoBehaviour
{
    public string path;
    public PointsManager pointsManager;

    private void Start()
    {
        LoadFile();
    }

    private void LoadFile()
    {
        if (File.Exists(path))
        {
            string content = File.ReadAllText(path);
            pointsManager = JsonUtility.FromJson<PointsManager>(content);        }
    }

    [ContextMenu("Print Json")]
    public void PrintJsonSample()
    {
        string json = JsonUtility.ToJson(pointsManager, true);
        Debug.Log(json);
    }
}
