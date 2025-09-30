using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Banana"))
        {
            GameManager.Instance.AddScore(1);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Cherry"))
        {
            GameManager.Instance.AddScore(2);
            Destroy(collision.gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Nếu player rơi khỏi map (ví dụ nền không còn dưới chân)
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            GameManager.Instance.AddScore(-999); // đảm bảo thua
        }
        else if (collision.gameObject.CompareTag("Trap"))
        {
            GameManager.Instance.AddScore(-1);
            // trap có thể tồn tại hoặc không, tùy bạn
            // Destroy(collision.gameObject);
        }
    }
}
