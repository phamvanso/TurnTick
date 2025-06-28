using ChienNT;
using UnityEngine;

public class HandCollisionDetector : MonoBehaviour
{
    public DotController parentDotController;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == parentDotController.gameObject)
            return;

        parentDotController.StopRotationOnCollision(other.gameObject);
    }
}
