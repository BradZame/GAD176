using UnityEngine;

public class Security : MonoBehaviour
{
    [SerializeField] protected Transform player; // Reference to the player
    [SerializeField] protected AlarmStatus alarmStatus;  // Reference to the alarm status (ScriptableObject)

    
    // Current alarm status
    private AlarmStatus AlarmStatus
    {
        get { return alarmStatus; }
    }
    
    
    /// <summary>
    /// Allows other classes to check alarm status   
    /// </summary>
    /// <returns></returns>
    public bool IsAlarmTriggered()
    {
        return alarmStatus != null && alarmStatus.alarmTripped;
    }
 
    /// <summary>
    /// Sets the alarm status 
    /// </summary>
    /// <param name="status"></param> True to trigger the alarm & False to disable it 
    public void SetAlarmStatus(bool status)
    {
        if (alarmStatus != null)
        {
            alarmStatus.alarmTripped = status;
        }
    }
    
    
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