using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class Dot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DotweenRotator.Instance.StopRotation();
    }
}
