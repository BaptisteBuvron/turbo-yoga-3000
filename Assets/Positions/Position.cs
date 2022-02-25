using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position2
{

    Vector2 headPosition;
    Vector2 leftHandPosition, rightHandPosition;

    public Position2(Vector2 headPosition, Vector2 leftHandPosition, Vector2 rightHandPosition)
    {
        this.headPosition = headPosition;
        this.leftHandPosition = leftHandPosition;
        this.rightHandPosition = rightHandPosition;
    }

}
public class Position3
{

    Vector3 headPosition;
    Vector3 leftHandPosition, rightHandPosition;

    public Position3(Vector3 headPosition, Vector3 leftHandPosition, Vector3 rightHandPosition)
    {
        this.headPosition = headPosition;
        this.leftHandPosition = leftHandPosition;
        this.rightHandPosition = rightHandPosition;
    }

}
