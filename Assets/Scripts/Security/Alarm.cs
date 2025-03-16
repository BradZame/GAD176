using UnityEngine;

public class Alarm : Security
{
    [SerializeField] private Light securityLight; // Reference to the light
    [SerializeField] private float flashingRate = 0.2f; // How fast the light flashes 
    [SerializeField] private AudioSource alarmSound; // Reference to the sound of the alarm
    [SerializeField] private float minVolumeDistance = 10f; // How close you have to be to hear the alarm
    [SerializeField] private float maxVolumeDistance = 100f; // How far away the alarm can be heard 

    private float lastFlashTime; // Time between the light flashes 
   
    public override void Update()
    {
        base.Update();

        if (IsAlarmTriggered())  // Check if the alarm has been tripped  in the ScriptableObject
        {
            if (Time.time - lastFlashTime >= flashingRate) 
            {
                securityLight.enabled = !securityLight.enabled; // Toggle light on/off
                lastFlashTime = Time.time; // Updates the lastFlashTime bool 
            }

            float playerToAlarmDistance = (player.position - transform.position).magnitude; // Calculates the distance from player to the alarm  
            float alarmVolume = Mathf.InverseLerp(minVolumeDistance, maxVolumeDistance, playerToAlarmDistance); // Adjust the alarm based on distance 
            alarmSound.volume = 1 - alarmVolume; // Alarm volume that decreses as player gets further away 

            if (!alarmSound.isPlaying) // if alarm is not playing, PLay the alarm 
            {
                alarmSound.Play(); 
            }
        }
      
        else
        {
            securityLight.enabled = false; // Turn off the light 
            if (alarmSound.isPlaying)
            {
                alarmSound.Stop(); // Stop alarm if its playing 
            }
        }
    }
}