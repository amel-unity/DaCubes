using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
//use a system for this

public class TapManager : SystemBase
{
	private Rect leftBounds, rightBounds;
	private bool rightSaberOn, leftSaberOn;

	protected override void OnCreate()
	{
        leftBounds = new Rect(0, 0, Screen.width / 2, Screen.height);
        rightBounds = new Rect(Screen.width / 2, 0, Screen.width, Screen.height);
	}

    protected override void OnUpdate()
    {
        Vector3 screenPos = Input.mousePosition;
        screenPos.z = 12f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

		//check if the finger is down or has been released
		if(Input.GetMouseButtonDown(0))
		{
			if(leftBounds.Contains(screenPos))
			{
				//pick up blue saber
            	//Debug.Log("Left!");
				leftSaberOn = true;
			}
			else if(rightBounds.Contains(screenPos))
			{
				//pick up red saber
            	//Debug.Log("Right!");
				rightSaberOn = true;
			}
		}
		else if(Input.GetMouseButtonUp(0))
		{
			//drop both sabers
			rightSaberOn = false;
			leftSaberOn = false;
		}

        //update sabers as needed
		if (leftSaberOn)
        {
            Entities
			.WithName("MoveSaberBlue")
			.WithAll<BlueSaber>()
            .ForEach((ref Translation position) =>
            {
                position.Value = worldPos;
            }).Run();
        }
        if (rightSaberOn)
        {
            Entities.WithName("MoveSaberRed")
			.WithAll<RedSaber>()
			.ForEach((ref Translation position) =>
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