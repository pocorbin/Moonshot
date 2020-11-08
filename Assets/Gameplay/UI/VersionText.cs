using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersionText : MonoBehaviour
{
    private Text mText;
    // Start is called before the first frame update
    void Start()
    {
        mText = GetComponent<Text>();
        mText.text += Application.version;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
