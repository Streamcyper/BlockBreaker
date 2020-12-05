using Sirenix.OdinInspector;
using UnityEngine;

public class Ball : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] [Required] private Transform startPos;
#pragma warning restore 649


    [SerializeField] private float launchSpeed = 5f;
    [SerializeField] private float launchRandomness = 1f;
#pragma warning disable 649
    [SerializeField] [Required("Assign audio clip")]
    private AudioClip hitAudio;
#pragma warning restore 640
    public Rigidbody2D Rigidbody { get; private set; }

    public void ResetBall() => isPlaying = false;

    public void InMenu(bool inMenu) => this.inMenu = inMenu;

    private void Start()
    {
        GameManager.Instance.OnInMenu += InMenu;
        GameManager.Instance.OnStartGame += ResetBall;

        Rigidbody = GetComponent<Rigidbody2D>();
        SetPosition(startPos.position);
    }

    private void Update()
    {
        if (!isPlaying)
        {
            SetPosition(startPos.position);
            if (!inMenu & Input.GetMouseButtonDown(0)) LaunchBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPlaying)
            AudioSource.PlayClipAtPoint(hitAudio, collision.transform.position, 0.4f);
    }

    private void SetPosition(Vector3 position) => transform.position = position;

    private void LaunchBall()
    {
        Vector2 launchVector = new Vector2(Random.Range(-launchRandomness, launchRandomness), launchSpeed);
        Rigidbody.velocity = launchVector;
        isPlaying = true;
    }

    private bool isPlaying;
    private bool inMenu = true;
}