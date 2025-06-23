using UnityEngine;

public class Dot : MonoBehaviour
{
    private void OnMouseDown()
    {
        Clock clock = FindObjectOfType<Clock>();
        gameObject.tag="Player";
        if (clock != null)
        {
            clock.OnDotClicked(transform);
        }
    }
}