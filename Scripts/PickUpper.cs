namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	[RequireComponent(typeof(Collider))]
	public class PickUpper : TaBehabviour
	{
		[SerializeField]
		private UnityEvent<IPickUp> _onPickUp;

		public UnityEvent<IPickUp> onPickUp => _onPickUp;

		private void OnCollisionEnter(Collision collision)
		{
			TryPickup(collision.collider);
		}

		private	void OnTriggerEnter(Collider other)
		{
			TryPickup(other);
		}

		private void TryPickup(Collider other)
		{
			if (other.TryGetSelfOrParentComponent<IPickUp>(out var pickUp))
			{
				pickUp.OnPickUp(this);
				_onPickUp?.Invoke(pickUp);
			}
		}
	}
}
