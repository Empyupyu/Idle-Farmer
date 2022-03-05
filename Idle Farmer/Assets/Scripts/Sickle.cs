using UnityEngine;

public class Sickle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var wheat = other.GetComponent<Wheat>();

        if(wheat != null)
        {
            wheat.Harvesting();
        }
    }
}
