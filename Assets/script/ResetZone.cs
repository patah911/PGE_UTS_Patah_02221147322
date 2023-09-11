using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ResetZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager GameManager = FindObjectOfType<GameManager>();
        ballcontroller ballcontroller = other.gameObject.GetComponent<ballcontroller>();

        if (GameManager != null) {
            GameManager.Miss();
        } else if (ballcontroller != null) {
            ballcontroller.Resetballcontroller();
        }
    }

}
