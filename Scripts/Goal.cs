namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public interface IGoal
	{
		
	}

	[RequireComponent(typeof(Collider))]
	public class Goal : MonoBehaviour, IGoal
	{
		
	}
}
