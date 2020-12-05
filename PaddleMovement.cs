using UnityEngine;

[RequireComponent(typeof(PaddleInput))]
public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private float boundsMin = 0.5f;
    [SerializeField] private float boundsMax = 15.5f;


    public void Start()
    {
        input = GetComponent<PaddleInput>();
        GameManager.Instance.OnInMenu += InMenu;
    }

    private void Update()
    {
        if (!inMenu)
            MovePaddle();
    }

    private void MovePaddle()
    {
        Vector3 inputPos = input.GetInput();
        Vector3 currentPos = transform.position;

        float newXPos = Mathf.Clamp(currentPos.x + inputPos.x, boundsMin, boundsMax);

        Vector3 newPos = new Vector3(newXPos, currentPos.y, currentPos.z);

        transform.position = newPos;
    }

    public void InMenu(bool inMenu)
    {
        this.inMenu = inMenu;
    }

    private PaddleInput input;
    private bool inMenu = true;
}