using UnityEngine;

public class Security : MonoBehaviour
{
    [SerializeField] protected Transform player; // Reference to the player
    [SerializeField] protected AlarmStatus alarmStatus;  // Reference to the alarm status (ScriptableObject)


 
    /// <summary>
    /// When game starts set the alarm status to not triggered
    /// </summary>
    public virtual void Start()
    {
        if (alarmStatus != null) // Checks to see if ScriptableObject has been assigned in inspector  
        {
            alarmStatus.alarmTripped = false; 
        }
    }

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    
}