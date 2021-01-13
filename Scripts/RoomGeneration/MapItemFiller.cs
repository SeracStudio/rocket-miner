using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItemFiller : MonoBehaviour
{
    public List<BaseItem> itemPool, engItemPool, jpItemPool;
    public List<BaseItem> specificItems;

    private int floor = 0;

    public void FillMapWithItems(Dictionary<Vector3, MapRoom> map)
    {
        foreach (MapRoom room in map.Values)
        {
            if (room.type == RoomType.TREASURE)
            {
                //room.item = specificItems[floor];
                room.item = itemPool[Random.Range(0, itemPool.Count)];
                itemPool.Remove(room.item);
            }
        }
        floor++;
    }
}
