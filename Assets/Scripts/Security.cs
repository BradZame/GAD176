using UnityEngine;

public class Security : MonoBehaviour
{
    public Transform player;
    public AlarmStatus alarmStatus;


 

    public virtual void Start()
    {
        if (alarmStatus != null)
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