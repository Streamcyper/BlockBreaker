public class NormalMode : GameMode
{
    public override void CheckConditions()
    {
        if (GameManager.Instance.State.Lives <= 0)
            GameManager.Instance.GameLost();
    }

    public override void SetupHooks()
    {
    }
}