using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KladScript : MonoBehaviour
{
    public bool kladPlatform;

    public GameObject klad;

    private void Update()
    {
        klad.SetActive(kladPlatform);
    }
}
