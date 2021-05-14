using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public AnimationCurve bobCurve;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + bobCurve.Evaluate((Time.time % bobCurve.length)), transform.position.z);
    }
}
