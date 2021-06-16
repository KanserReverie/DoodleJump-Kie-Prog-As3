using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All just using the same NameSpace this project.
namespace doodleJump
{
	public class Camera : MonoBehaviour
	{
		public Transform myTarget;

		void LateUpdate()
		{
			if (myTarget.position.y > transform.position.y)
			{
				Vector3 newPos = new Vector3(transform.position.x, myTarget.position.y, transform.position.z);
				transform.position = newPos;
			}
		}
	}
}