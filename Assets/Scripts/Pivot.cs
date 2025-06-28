using DG.Tweening;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    private CircleCollider2D CircleCollider; 
    void Start()
    {
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnMouseDown()
    {
        if (CircleCollider != null)
        {
            CircleCollider.enabled = false;
        }
        DotweenRotator.Instance.StartRotation();
    }
}