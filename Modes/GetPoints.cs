using Sirenix.OdinInspector;

public class GetPoints : GameMode
{
    [ValidateInput("MoreThanZero", "Must be more than 0")]
    public int pointsToGet;

    public override void CheckConditions()
    {
        if (GameManager.Instance.State.Score >= pointsToGet)
            GameManager.Instance.GameWon();
    }

    public override void SetupHooks()
    {
    }

    private bool MoreThanZero(int value) => value > 0;
}