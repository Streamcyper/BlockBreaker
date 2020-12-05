using UnityEngine;

[RequireComponent(typeof(IBreakTrigger))]
public abstract class BreakEffect : MonoBehaviour, IBreakable
{
    public abstract void Break();
}