using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AddLives(-1);
        FindObjectOfType<Ball>().ResetBall();
        FindObjectOfType<MouseInput>().ChangeDirection(MouseInput.Directions.Normal);
    }
}