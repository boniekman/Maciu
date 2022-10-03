using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject turretPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable{ get{ return isPlaceable; } }

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(turretPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
