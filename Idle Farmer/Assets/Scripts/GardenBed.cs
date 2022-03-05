using UnityEngine;

public class GardenBed : MonoBehaviour
{
    private Wheat _wheat;

    public Wheat Wheat => _wheat;

    public void SetWheat(Wheat wheat)
    {
        _wheat = wheat;       
    }
}
