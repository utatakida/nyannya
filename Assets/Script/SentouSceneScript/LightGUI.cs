using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGUI : MonoBehaviour
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
        if (syatihokoCon.win == 1)
        {
            m_rectTransform.localPosition += new Vector3(0, 3, 0);
        }
        if (nyankojyouCon.Lose == 1)
        {
            m_rectTransform.localPosition += new Vector3(0, 3, 0);
        }
    }
}
