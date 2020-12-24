using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public int pathWidth, pathDepth, lateralRatio;
    [Range(0, 100)]
    public int branchingRatio;

    private MapController RUNNING;
    private MapGenerator mapGenerator;
    private MapRenderer mapRenderer;

    private void Awake()
    {
        RUNNING = this;

        mapGenerator = new MapGenerator(pathWidth, pathDepth, lateralRatio, branchingRatio);
        mapRenderer = GetComponent<MapRenderer>();

        mapRenderer.UpdateMap(mapGenerator.NewMap());
        mapRenderer.LoadMap();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            mapRenderer.UpdateMap(mapGenerator.NewMap());
            mapRenderer.LoadMap();
        }
    }
}
