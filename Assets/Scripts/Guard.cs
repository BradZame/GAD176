using UnityEngine;

public class Guard : Security
{
    public Rigidbody rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float turnSpeed = 10f;
    
    public override void FixedUpdate()
    {
        if (alarmStatus.alarmTripped == true)
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Vector3 moveDirection = directionToPlayer * speed;

        rb.AddForce(moveDirection);

        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
}