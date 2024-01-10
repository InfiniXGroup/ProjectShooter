using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveHandler : MonoBehaviour
{

    [SerializeField] GameObject glove;

    public void ShowGlove(bool active)
    {
        glove.SetActive(active);
    }
}
