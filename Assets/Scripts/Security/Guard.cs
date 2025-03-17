using UnityEngine;

public class Guard : Security
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float chaseSpeed = 10f; // Guards chasing speed
    [SerializeField] private float turnSpeed = 10f; // Guards rotation speed when facing player
    [SerializeField] private float slowDownSpeed = 0.95f; // Slows guard down over time 
   

    /// <summary>
    /// Check if alarm has been triggered
    /// if triggered, guard will chase the player
    /// </summary>
    public override void FixedUpdate()
    {
        if (IsAlarmTriggered()) // // Check if the alarm has been tripped  in the ScriptableObject
        {
            ChasePlayer();
        }
    }

    /// <summary>
    /// Rotates guard & starts chasing player 
    /// </summary>
    private void ChasePlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized; // Calculate the direction to the player
        Vector3 moveDirection = directionToPlayer * chaseSpeed; // Move to player

        rb.AddForce(moveDirection); // Moves towards player 


        rb.linearVelocity = new Vector3 //Reduces speed on the X,Y,Z axes
        (
            rb.linearVelocity.x * slowDownSpeed,
            rb.linearVelocity.y * slowDownSpeed,
            rb.linearVelocity.z * slowDownSpeed
        );

        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer); // Calculate the rotation needed to face the player 
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime); // Rotate to face the player
    }
}