using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    public bool isOccupied = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = isOccupied ? Color.red : Color.green;
        Gizmos.DrawSphere(transform.position, 0.02f);
    }
}