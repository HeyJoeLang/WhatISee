using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CurvedUI
{
    public class CUI_AnimateCurvedFillOnStart : MonoBehaviour
    {
        CurvedUISettings set;
        void Start()
        {
            set = this.GetComponent<CurvedUISettings>();
        }

        void Update()
        {
            //30.23234f
            //set.RingFill = Mathf.PerlinNoise(Time.time * 100, Time.time * 100) * 0.15f;
        }
    }
}
