using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalStraightMovingWall : MonoBehaviour
{
    Transform Object;
    [SerializeField] float period = 2f;
    [SerializeField] [Range(0, 1)] float movementFactor;
    [SerializeField] Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        Object = GetComponent<Transform>();
        startingPosition = Object.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSineWav = Mathf.Sin(cycles * tau);
        if(rawSineWav <= Mathf.Epsilon){
            return;
        }
        movementFactor = (rawSineWav + 1f) / 12f;
        Object.position = startingPosition + new Vector3(0,(movementFactor * 90),0);
    }
}
