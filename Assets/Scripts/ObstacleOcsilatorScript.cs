using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleOcsilatorScript : MonoBehaviour
{
    const float tau = Mathf.PI * 2;
    private float _cycle;
    [SerializeField] float period = 2f;

    Vector3 startingPosition;
    float movementFactor;
    [SerializeField] Vector3 movementVector;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        Debug.Log("Starting position "+startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) //it is the decided smallest positive number in unity
        {
            return;
        }
        _cycle = Time.time / period;
        float rawSineWave = Mathf.Sin(_cycle * tau);

        movementFactor = (rawSineWave + 1f) / 2f;
        
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
