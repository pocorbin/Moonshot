using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StardustCounterCollider : MonoBehaviour
{
    public StardustCounter m_StardustCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Stardust.STARDUST_TAG)
        {
            Stardust dust = collision.GetComponent<Stardust>();
            m_StardustCounter.IncreaseStardustCount(dust.value);
            dust.GetComponent<ParticleSystem>().Stop();
        }
    }
}
