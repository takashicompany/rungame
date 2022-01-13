namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public interface IPickUp
	{
		bool canPickedUp { get; }
		void OnPickUp(PickUpper pickUpper);
	}
}
