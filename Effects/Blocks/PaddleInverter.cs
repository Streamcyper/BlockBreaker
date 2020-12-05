using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleInverter : BreakEffect
{
    private void Start()
    {
        mouseInput = FindObjectOfType<MouseInput>();
    }

    public override void Break()
    {
        mouseInput.ChangeDirection(MouseInput.Directions.Inverted);
    }

    private MouseInput mouseInput;
}