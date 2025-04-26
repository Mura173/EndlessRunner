
    using UnityEngine;
using UnityEngine.SceneManagement;

public class player_data : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneDistance = 3f;
    public float sideSpeed = 10f;

    public float jumpForce = 8f;
    public float gravity = 20f;
    public float slideDuration = 1.0f;
    private float originalHeight;
    private bool isSliding = false;

    private int desiredLane = 1;
    private Vector3 moveDirection;
    private CharacterController controller;

    bool alive = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalHeight = controller.height;
    }

    private void FixedUpdate()
    {
        if (!alive) return;
    }

    void Update()
    {
        // Movimento para frente sempre
        moveDirection.z = forwardSpeed;

        // Input lateral
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane > 2) desiredLane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane < 0) desiredLane = 0;
        }

        // Determina posição da faixa
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;

        // Movimento lateral suave
        Vector3 moveTo = Vector3.Lerp(transform.position, targetPosition, sideSpeed * Time.deltaTime);
        moveDirection.x = (moveTo - transform.position).x / Time.deltaTime;

        // Checa se está no chão
        if (controller.isGrounded)
        {
            moveDirection.y = -1f; // mantém colado no chão

            // Pulo
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }

            // Deslizar
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                if (!isSliding)
                    StartCoroutine(Slide());
            }
        }
        else
        {
            // Aplicando gravidade
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Aplica movimento
        controller.Move(moveDirection * Time.deltaTime);
    }

    // Corrotina para deslizar
    private System.Collections.IEnumerator Slide()
    {
        isSliding = true;
        controller.height = originalHeight / 2f;
        controller.center = new Vector3(0, controller.height / 2f, 0);

        yield return new WaitForSeconds(slideDuration);

        controller.height = originalHeight;
        controller.center = new Vector3(0, originalHeight / 2f, 0);
        isSliding = false;
    }

    public void Die()
    {
        alive = false;
        //Restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}