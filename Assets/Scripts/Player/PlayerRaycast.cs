using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
            CheckWhatsInFront();
    }

    
    /// <summary>
    /// Checks what's in front player via raycast
    /// if raycast hits object it logs it in the console  
    /// </summary>
    private void CheckWhatsInFront()
    {
        //Shooting the ray
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = transform.forward;
        RaycastHit hitInfo = new RaycastHit();
        Physics.Raycast(ray, out hitInfo, maxDistance: 3f);
           
        //Returns hitInfo via debug.log 
        if (hitInfo.transform != null)
        {
            Debug.Log(hitInfo.transform.gameObject.name);
        }
    }
}