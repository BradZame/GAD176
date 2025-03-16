using UnityEngine;

public class Alarm : Security
{
    [SerializeField] private Light securityLight;
    [SerializeField] private float flashingRate = 0.2f;
    [SerializeField] private AudioSource alarmSound;
    [SerializeField] private float minVolumeDistance = 10f;
    [SerializeField] private float maxVolumeDistance = 100f;

    private float lastFlashTime;
   
    public override void Update()
    {
        base.Update();

        if (alarmStatus.alarmTripped)
        {
            if (Time.time - lastFlashTime >= flashingRate)
            {
                securityLight.enabled = !securityLight.enabled;
                lastFlashTime = Time.time;
            }

            float playerToAlarmDistance = (player.position - transform.position).magnitude;
            float alarmVolume = Mathf.InverseLerp(minVolumeDistance, maxVolumeDistance, playerToAlarmDistance);
            alarmSound.volume = 1 - alarmVolume;

            if (!alarmSound.isPlaying)
            {
                alarmSound.Play();
            }
        }
      
        else
        {
            securityLight.enabled = false;
            if (alarmSound.isPlaying)
            {
                alarmSound.Stop();
            }
        }
    }
}