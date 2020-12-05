using UnityEngine;

public class MouseInput : PaddleInput
{
    public enum Directions
    {
        Normal = 1,
        Inverted = -1
    }

    [SerializeField] private int sensitivity = 2;
    [SerializeField] private int direction = 1;


    public override Vector3 GetInput()
    {
        float input = Input.GetAxisRaw("Horizontal");

        float xPos = input * sensitivity * direction * Time.deltaTime;

        Vector3 moveVector = new Vector3(xPos, 0, 0);

        return moveVector;
    }

    public void ChangeDirection(Directions dir)
    {
        direction = (int) dir;
    }
}