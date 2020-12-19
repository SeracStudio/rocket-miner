using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Direction
{
    NORTH,
    WEST,
    EAST,
    SOUTH
}

public class DirectionFunc
{
    public static Vector3 GetVector(Direction direction)
    {
        switch (direction)
        {
            case Direction.NORTH:
                return Vector3.forward;
            case Direction.WEST:
                return Vector3.left;
            case Direction.EAST:
                return Vector3.right;
            case Direction.SOUTH:
                return Vector3.back;
            default:
                return Vector3.zero;
        }
    }

    public static Direction Inverse(Direction direction)
    {
        switch (direction)
        {
            case Direction.NORTH:
                return Direction.SOUTH;
            case Direction.WEST:
                return Direction.EAST;
            case Direction.EAST:
                return Direction.WEST;
            case Direction.SOUTH:
            default:
                return Direction.NORTH;
        }
    }

    public static List<Direction> GetAll()
    {
        return Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();
    }
}