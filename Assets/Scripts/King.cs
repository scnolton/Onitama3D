using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour {

    public void Initilize(Space parentSpace)
    {
        transform.parent = parentSpace.transform;
        transform.localPosition = Vector3.up * .25f;
    }

}
