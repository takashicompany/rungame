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
		private bool _isPicked = false;

		bool IPickUp.canPickedUp => !_isPicked;

		void IPickUp.OnPickUp(PickUpper pickUpper)
		{
			_isPicked = true;
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
