public class Requiered : BreakEffect
{
    public override void Break() => GameManager.Instance.RemoveBlock(gameObject);

    private void Start() => GameManager.Instance.AddBlock(gameObject);
}