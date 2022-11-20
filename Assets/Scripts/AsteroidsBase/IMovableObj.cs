using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovebleObj
{
    Vector2 Position { get; set; }
    Vector2 Velocity { get; set; }
    float Radius { get; set; }
}
