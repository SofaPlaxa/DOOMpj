using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAim : MonoBehaviour
{
    [SerializeField] Image aimImage;
 
   public bool canShoot { get; set; }

    private void Update()
    {
        aimImage.color = canShoot ? Color.red : Color.white;
    }
}
