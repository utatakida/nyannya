using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGUI : MonoBehaviour
{
    public RectTransform m_rectTransform = null;
    // Start is called before the first frame update
    void Start()
    {
        m_rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (syatihokoCon.win == true)
        {
            m_rectTransform.localPosition += new Vector3(-10, 0, 0);
        }
    }
}
