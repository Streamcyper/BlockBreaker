using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Portal : MonoBehaviour
{
    [Required("Needs a destination portal assigned")] [SerializeField] [Tooltip("Destination portal")]
    private Portal destination;

    private Vector3 destinationPortalLocation;

    [HideInInspector] public bool isReadyToTeleport = true;

    private void Start()
    {
        destinationPortalLocation = destination.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (isReadyToTeleport)
            collider.transform.position = destinationPortalLocation;
        destination.isReadyToTeleport = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isReadyToTeleport = true;
    }

#pragma warning disable IDE0051 // Remove unused private members
    [Button(Name = "FindPortal")]
    [HideIf("Destination")]
    private void FindPortal()
    {
        Debug.Log("Looking for destination!");
        Portal[] portals = FindObjectsOfType<Portal>();
        Debug.Log($"Found {portals.Length}");
        if (portals.Length > 2)
        {
            Debug.Log("More than two portals. Can not set up automatically");
            return;
        }

        int i = 1;
        foreach (Portal portal in portals)
        {
            portal.destination = portals[i];
            i++;
            i %= 2;
        }
    }
#pragma warning restore IDE0051 // Remove unused private members
}