using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenFar : MonoBehaviour
{
    private const int DISTANCE_TO_DESTROY = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistanceFromOrigin();
    }

    private void CheckDistanceFromOrigin()
    {
        if(Vector2.Distance(this.transform.position, Vector2.zero) > DISTANCE_TO_DESTROY)
        {
            Destroy(this.gameObject);
        }
    }
}
