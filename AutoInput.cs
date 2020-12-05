using UnityEngine;

public class AutoInput : PaddleInput
{
    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    public override Vector3 GetInput()
    {
        Vector3 pos = new Vector3(ball.transform.position.x - transform.position.x, 0, 0);
        return pos;
    }

    private Ball ball;
}