namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class Stacker : MonoBehaviour
	{
		public enum StackDirection
		{
			Forward,
			Up,
		}

		[SerializeField]
		private StackDirection _stackDirection;

		private List<StackedObject> _stacked;
	}
}