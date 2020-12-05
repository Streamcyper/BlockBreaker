using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : BreakEffect
{
    [SerializeField] [Tooltip("The ammount of lives you want to give/take from the player when block is broken.")]
    private int lives = 1;

    public override void Break()
    {
        GameManager.Instance.AddLives(lives);
    }
}