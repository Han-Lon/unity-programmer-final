using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private float yBound = -6;

    private float m_direction;
    public float direction
    {
        get { return m_direction; }
        set
        {
            if (value != -1 && value != 1)
            {
                Debug.LogError("Units can only have directions of 1 or -1");
            }
            else
            {
                m_direction = value;
            }
        }
    }

    // Destroy unit objects if they fall out of bounds
    protected virtual void DetermineOutOfBounds()
    {
        if (transform.position.y < yBound)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Update()
    {
        // ALL children of the Unit class need to check if they're out of bounds
        DetermineOutOfBounds();
    }
}
