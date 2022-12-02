using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBoundary : MonoBehaviour
{
    //variables to control border locations
    private float northBound = 4.3f;
    private float eastBound = 16.3f;
    private float southBound = -6.0f;
    private float westBound = 24.7f;

    // Update is called once per frame
    void Update()
    {
        ConstrainObjectPosition();
    }

    //prevent gameobject from escaping edges of map
    void ConstrainObjectPosition()
    {
        if (gameObject.tag == "Ghost")
        {
            //constrain object from going too far north by resetting their position
            if (transform.position.x > northBound)
            {
                transform.position = new Vector3(northBound, transform.position.y, transform.position.z);
            }
            //restrain object from going too far south by resetting their position
            if (transform.position.x < southBound)
            {
                transform.position = new Vector3(southBound, transform.position.y, transform.position.z);
            }
            //constrain object from going too far east by resetting their position
            if (transform.position.z < eastBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, eastBound);
            }
            //restrain object from going too far west by resetting their position
            if (transform.position.z > westBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, westBound);
            }
        }
    }
}
