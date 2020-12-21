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

    public static Direction Reverse(Direction direction)
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
                return Direction.NORTH;
            default:
                return direction;
        }
    }

    public static Direction ClockWiseRotation(Direction direction)
    {
        switch (direction)
        {
            case Direction.NORTH:
                return Direction.EAST;
            case Direction.WEST:
                return Direction.NORTH;
            case Direction.EAST:
                return Direction.SOUTH;
            case Direction.SOUTH:
                return Direction.WEST;
            default:
                return direction;
        }
    }

    public static Direction CounterClockWiseRotation(Direction direction)
    {
        switch (direction)
        {
            case Direction.NORTH:
                return Direction.WEST;
            case Direction.WEST:
                return Direction.SOUTH;
            case Direction.EAST:
                return Direction.NORTH;
            case Direction.SOUTH:
                return Direction.EAST;
            default:
                return direction;
        }
    }

    public static List<Direction> GetAll()
    {
        return Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();
    }

    public static List<Direction> GetAll(List<Direction> excluding)
    {
        List<Direction> allDirections = GetAll();

        foreach(var dir in excluding)
        {
            allDirections.Remove(dir);
        }

        return allDirections;
    }

    public static Direction GetRandom()
    {
        switch (UnityEngine.Random.Range(0, 4))
        {
            case 0:
                return Direction.NORTH;
            case 1:
                return Direction.WEST;
            case 2:
                return Direction.EAST;
            case 3:
            default:
                return Direction.SOUTH;
        }
    }

    public static Direction GetRandom(IEnumerable<Direction> possible)
    {
        if (possible.Count() == 0) return GetRandom();

        return possible.ElementAt(UnityEngine.Random.Range(0, possible.Count()));     
    }
}