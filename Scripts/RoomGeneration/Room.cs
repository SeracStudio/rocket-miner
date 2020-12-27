using UnityEngine;

public class Room : MonoBehaviour
{
    public SpawnObject north, west, east, south;
    private SpawnObject GetWallPosition(Direction direction)
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
        GetWallPosition(direction).Hide();
    }
}
