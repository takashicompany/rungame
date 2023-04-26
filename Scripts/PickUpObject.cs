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

	public class PickUpObject : MonoBehaviour, IPickUp
	{
		bool IPickUp.canPickedUp => true;

		void IPickUp.OnPickUp(PickUpper pickUpper)
		{
			
		}
	}

	public static class PickUpExtension
	{
		public static bool IsStackedObject(this IPickUp pickUp, out StackedObject obj)
		{
			obj = null;
			return (pickUp is Component c && c.TryGetComponent<StackedObject>(out obj));
		}
	}
}
