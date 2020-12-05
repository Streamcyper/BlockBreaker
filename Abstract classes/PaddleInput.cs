using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PaddleMovement))]
public abstract class PaddleInput : MonoBehaviour
{
    public abstract Vector3 GetInput();
}