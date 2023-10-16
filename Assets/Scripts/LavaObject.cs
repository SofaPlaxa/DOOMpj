using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaObject : MonoBehaviour
{
    void OnCharacterStay(PlayerController controller)
    {
        print($"LavaCharacterStay: {controller.name}");
    }
    void OnCharacterExit()
    {
        print("On char exit");
    }
    void OnCharacterEnter()
    {
        print("On char enter");
    }
}
