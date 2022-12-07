using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllerCommdn
{
    public abstract float Control();
}

public class Inverted : ControllerCommdn
{
    
    public override float Control()
    {
        return Input.GetAxisRaw("Vertical") * -1;
    }
}

public class Normal : ControllerCommdn
{
    public override float Control()
    {
        return Input.GetAxisRaw("Vertical");
    }
}
