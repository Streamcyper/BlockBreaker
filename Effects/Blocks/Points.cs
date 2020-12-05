using UnityEngine;

public class Points : BreakEffect
{
    [SerializeField] private int points = 1;

    public override void Break() => GameManager.Instance.AddPoints(points);
}