using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
//use a system for this

public class TapManager : SystemBase
{
    protected override void OnUpdate()
    {

        Rect Leftbounds = new Rect(0, 0, Screen.width / 2, Screen.height);
        Rect Rightbounds = new Rect(Screen.width / 2, 0, Screen.width, Screen.height);


        Vector3 screenPos = Input.mousePosition;
        screenPos.z = 12f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        //for test on pc (no multitouch though :v)
        if (Input.GetMouseButton(0) && Rightbounds.Contains(Input.mousePosition))
        {
            Debug.Log("Right!");
            Entities.WithName("MoveSaberRed")
              .ForEach((ref Translation position, in RedSaber redSaber) =>
              {
                  position.Value = worldPos;
              }).Run();
        }
        else if (Input.GetMouseButton(0) && Leftbounds.Contains(Input.mousePosition))
        {
            Debug.Log("Left!");
            Entities.WithName("MoveSaberBlue")
            .ForEach((ref Translation position, in BlueSaber blueSaber) =>
            {
                position.Value = worldPos;
            }).Run();
        }

    }
}




//For the mobile devices
//if (Input.GetTouch(0).phase == TouchPhase.Began
//    && Leftbounds.Contains(Input.GetTouch(0).position))
//{
//    Debug.Log("Left!");
//}



//if (Input.touchCount > 0)
//{
//    Debug.Log("Touching");
//    if (Input.GetTouch(0).phase == TouchPhase.Began)
//    {
//        Vector3 screenPos = Input.GetTouch(0).position;
//        screenPos.z = 12f;
//        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
//        //right part of the screen to control red saber and other 
//        //EntityManager thing to update the entity (auth script in demo)
//    }
//}