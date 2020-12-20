using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardPathGenerator : RandomDirectionGenerator
{
    public Direction forward;
    private bool isLocked;
    public int forwardChance, lateralChance;

    public ForwardPathGenerator(Direction forward, int forwardChance, int lateralChance) : base()
    {
        this.forward = forward;
        this.forwardChance = forwardChance;
        this.lateralChance = lateralChance;

        Dictionary<Direction, int> weightedDirections = new Dictionary<Direction, int>()
        {
            { forward, forwardChance},
            { DirectionFunc.ClockWiseRotation(forward), lateralChance },
            { DirectionFunc.CounterClockWiseRotation(forward), lateralChance }
        };

        ReplaceDirectionSet(weightedDirections);
    }

    public void Lock(Direction lateralLockDirection)
    {
        if (isLocked) return;
        isLocked = true;

        ReplaceDirectionSet(new Dictionary<Direction, int>() {
            { forward, forwardChance },
            { lateralLockDirection, lateralChance }
        });
    }

    public void Reset()
    {
        if (!isLocked) return;
        isLocked = false;

        ReplaceDirectionSet(new Dictionary<Direction, int>()
        {
            { forward, forwardChance},
            { DirectionFunc.ClockWiseRotation(forward), lateralChance },
            { DirectionFunc.CounterClockWiseRotation(forward), lateralChance }
        });
    }

    public override Direction Generate()
    {
        Direction newDirection = base.Generate();
        if (newDirection != forward)
        {
            Lock(newDirection);
        }
        else
        {
            Reset();
        }
        return newDirection;
    }
}

