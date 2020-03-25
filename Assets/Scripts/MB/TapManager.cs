using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

//use a system for this
/*
public class TapManager : ComponentSystem
{
    protected override void OnUpdate()
    {

         if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 screenPos = Input.GetTouch(0).position;
            screenPos.z = 12f;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            //right part of the screen to control red saber and other 
            //EntityManager thing to update the entity (auth script in demo)
        }

    }
}
*/