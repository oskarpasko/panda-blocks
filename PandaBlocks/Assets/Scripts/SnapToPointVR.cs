using UnityEngine;
using Oculus.Interaction;

public class SnapToPointVR : MonoBehaviour
{
    public float snapRange = 0.1f;

    private OVRGrabbable grabbable;
    private Rigidbody rb;

    private void Awake()
    {
        grabbable = GetComponent<OVRGrabbable>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (grabbable != null && !grabbable.isGrabbed)
        {
            TrySnap();
        }
    }

    private void TrySnap()
    {
        SnapPoint closestSnap = null;
        float closestDistance = Mathf.Infinity;

        foreach (SnapPoint sp in FindObjectsOfType<SnapPoint>())
        {
            if (sp.isOccupied)
                continue;

            float distance = Vector3.Distance(transform.position, sp.transform.position);
            if (distance < closestDistance && distance < snapRange)
            {
                closestDistance = distance;
                closestSnap = sp;
            }
        }

        if (closestSnap != null)
        {
            SnapTo(closestSnap);
        }
    }

    private void SnapTo(SnapPoint sp)
    {
        transform.position = sp.transform.position;
        transform.rotation = sp.transform.rotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        sp.isOccupied = true;
    }
}