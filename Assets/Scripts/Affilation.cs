using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum Affilation
{
    None = 0,

    Player = 1 << 0,
    Demon = 1 << 1,
    Neutral = 1 << 2,

    Everything = int.MaxValue
}
