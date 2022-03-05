using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    [SerializeField] private List<GardenBed> _gardenBeds;

    [SerializeField] private Wheat _wheat;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        foreach (var _gardenBed in _gardenBeds)
        {
            Sowing(_gardenBed);
        }
    }

    private void Sowing(GardenBed gardenBed)
    {
        var wheat = Instantiate(_wheat, gardenBed.transform.position, Quaternion.identity);

        gardenBed.SetWheat(wheat);
    }
}
