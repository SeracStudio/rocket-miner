using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Operation
{
    ADD,
    SUBTRACT,
    MULTIPLY,
    DIVIDE
}

public class OperationFunc
{
    public static int IntSolve(Operation operation, int firstOperand, int secondOperand)
    {
        switch (operation)
        {
            case Operation.ADD:
                return firstOperand + secondOperand;
            case Operation.SUBTRACT:
                return firstOperand - secondOperand;
            case Operation.MULTIPLY:
                return firstOperand * secondOperand;
            case Operation.DIVIDE:
                return firstOperand / secondOperand;

        }
        return firstOperand;
    }

    public static float FloatSolve(Operation operation, float firstOperand, float secondOperand)
    {
        switch (operation)
        {
            case Operation.ADD:
                return firstOperand + secondOperand;
            case Operation.SUBTRACT:
                return firstOperand - secondOperand;
            case Operation.MULTIPLY:
                return firstOperand * secondOperand;
            case Operation.DIVIDE:
                return firstOperand / secondOperand;

        }
        return firstOperand;
    }
}
