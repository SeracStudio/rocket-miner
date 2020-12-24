using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject north, west, east, south;
    private GameObject GetWallPosition(Direction direction)
    {
        switch (direction)
        {
            case Direction.NORTH:
                return north;
            case Direction.WEST:
                return west;
            case Direction.EAST:
                return east;
            case Direction.SOUTH:
            default:
                return south;
        }
    }

    public void RemoveWall(Direction direction)
    {
        foreach (Transform wallPos in GetWallPosition(direction).transform)
        {
            Destroy(wallPos.gameObject);
        }
    }
}
