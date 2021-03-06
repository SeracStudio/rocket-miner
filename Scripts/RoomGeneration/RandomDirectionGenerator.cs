﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirectionGenerator
{
    private class WeightedDirection
    {
        public Direction direction;
        public int weight;

        public WeightedDirection(Direction direction, int weight)
        {
            this.direction = direction;
            this.weight = weight;
        }
    }

    private readonly List<WeightedDirection> directions;
    private int totalWeight;

    public RandomDirectionGenerator()
    {
        directions = new List<WeightedDirection>();
    }

    public RandomDirectionGenerator(Dictionary<Direction, int> weightedDirections)
    {
        directions = new List<WeightedDirection>();
        ReplaceDirectionSet(weightedDirections);
    }

    public void ReplaceDirectionSet(Dictionary<Direction, int> weightedDirections)
    {
        directions.Clear();
        foreach (var weightedDir in weightedDirections)
        {
            directions.Add(new WeightedDirection(weightedDir.Key, weightedDir.Value));
        }
        UpdateTotalWeight();
    }

    private void UpdateTotalWeight()
    {
        totalWeight = 0;
        foreach (var direction in directions)
        {
            totalWeight += direction.weight;
        }
    }

    public virtual Direction Generate()
    {
        int position = Random.Range(0, totalWeight);

        foreach (var direction in directions)
        {
            if (position < direction.weight)
            {
                return direction.direction;
            }
            position -= direction.weight;
        }

        return Direction.SOUTH;
    }
}


