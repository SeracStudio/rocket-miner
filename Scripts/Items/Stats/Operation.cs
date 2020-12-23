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
        return operation switch
        {
            Operation.ADD => firstOperand + secondOperand,
            Operation.SUBTRACT => firstOperand - secondOperand,
            Operation.MULTIPLY => firstOperand * secondOperand,
            Operation.DIVIDE => firstOperand / secondOperand,
            _ => firstOperand,
        };
    }

    public static float FloatSolve(Operation operation, float firstOperand, float secondOperand)
    {
        return operation switch
        {
            Operation.ADD => firstOperand + secondOperand,
            Operation.SUBTRACT => firstOperand - secondOperand,
            Operation.MULTIPLY => firstOperand * secondOperand,
            Operation.DIVIDE => firstOperand / secondOperand,
            _ => firstOperand,
        };
    }
}
