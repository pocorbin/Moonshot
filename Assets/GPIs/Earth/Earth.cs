using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public Canon m_TopCanon;
    public Canon m_RightCanon;
    public Canon m_BottomCanon;
    public Canon m_LeftCanon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckShoot();
    }

    private void CheckShoot()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_TopCanon.Shoot();
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_RightCanon.Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_BottomCanon.Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_LeftCanon.Shoot();
        }
    }
}
