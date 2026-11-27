using Mapbox.BaseModule.Data.Vector2d;
using Mapbox.BaseModule.Map;
using Mapbox.BaseModule.Utilities;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class POIData
{
    public GameObject prefab;
    public double latitude;
    public double longitude;
}

public class POIManager : MonoBehaviour
{
    MapboxMap mapInstance;
    public MapBehaviourCore mapCore;
    public List<POIData> pois = new List<POIData>();
    public JsonHandler handler;
    private void Awake()
    {
        mapCore.Initialized += CreatePOIs;
    }

    private void CreatePOIs(MapboxMap map)
    {
        mapInstance = map;
        handler.LoadFile();
        IntancePoints();
    }

    private void IntancePoints()
    {
        foreach (POIData data in pois)
        {
            LatitudeLongitude coordinates =
                new LatitudeLongitude(data.latitude, data.longitude);

            Vector3 position =
                mapInstance.MapInformation.ConvertLatLngToPosition(coordinates);

            GameObject poi =
                Instantiate(data.prefab, mapInstance.UnityContext.MapRoot);

            poi.transform.localPosition = position;
        }
    }
}