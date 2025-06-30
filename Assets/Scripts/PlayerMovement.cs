using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public float horizontalSpeed = 3f;
    private Vector2 movementInput;
    private int score = 0;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        Vector3 horizontalMove = new Vector3(movementInput.x, 0, 0);
        transform.Translate(horizontalMove * Time.deltaTime * horizontalSpeed, Space.World);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score++;
            Debug.Log("Puan: " + score);
        }
    }
}
