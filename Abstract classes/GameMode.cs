using UnityEngine;

public abstract class GameMode : MonoBehaviour
{
    public abstract void SetupHooks();

    public abstract void CheckConditions();
}