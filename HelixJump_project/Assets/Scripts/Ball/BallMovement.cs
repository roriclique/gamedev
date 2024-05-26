using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator animator;

    [Header("Fall")]
    [SerializeField] private float fallHeight;
    [SerializeField] private float fallSpeedDefault;
    [SerializeField] private float fallSpeedMax;
    [SerializeField] private float fallSpeedAññeleration;

    private float fallSpeed;
    private float floorY;

    private void Start()
    {
        enabled = false;
    }

    private void Update()
    {
        if (transform.position.y > floorY)
        {
            transform.Translate(0, -fallSpeed * Time.deltaTime, 0);

            if (fallSpeed < fallSpeedMax)
            {
                fallSpeed += fallSpeedAññeleration * Time.deltaTime;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, floorY, transform.position.z);
            enabled = false;
        }
    }

    public void Jump()
    {
        animator.enabled = true;
        fallSpeed = fallSpeedDefault;
    }

    public void Fall(float startFloorY)
    {
        animator.enabled = false;
        enabled = true;

        floorY = startFloorY - fallHeight;
    }

    public void Stop()
    {
        animator.enabled = false;
    }
}
