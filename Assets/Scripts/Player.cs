using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    private float movement = 0f;

    private Rigidbody2D rb;

    void Start()
    {
        if (!TryGetComponent(out rb))
        {
            Debug.LogError("Rigidbody2D missing on Player!");
        }
    }

    void Update()
    {
        // Handle input using the new Input System
        float direction = 0f;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
            {
                direction = -1f;
            }
            else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
            {
                direction = 1f;
            }
        }
        
        movement = direction * movementSpeed;

        // Game Over Check - Reload scene if fallen below camera
        if (Camera.main != null && transform.position.y < Camera.main.transform.position.y - 10f)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.x = movement;
        rb.linearVelocity = velocity;
        
        // Screen Wrapping
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPos.x > 1) transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, viewportPos.y, viewportPos.z));
        else if (viewportPos.x < 0) transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1, viewportPos.y, viewportPos.z));
    }
}
