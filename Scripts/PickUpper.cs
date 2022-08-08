namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;
	using takashicompany.Unity;

	public class PickUpper : TaBehaviour
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

		// TODO Pickup -> PickUp

		public void Pickup(Collision collision)
		{
			TryPickup(collision);
		}

		public bool TryPickup(Collision collision)
		{
			return TryPickup(collision.collider);
		}

		public void Pickup(Collider collider)
		{
			TryPickup(collider);
		}

		public bool TryPickup(Collider other)
		{
			if (other.TryGetSelfOrParentComponent<IPickUp>(out var pickUp) && pickUp.canPickedUp)
			{
				pickUp.OnPickUp(this);
				_onPickUp?.Invoke(pickUp);

				return true;
			}

			return false;
		}
	}

	public static class PickUpperExtension
	{
		public static bool IsStacker(this PickUpper self, out Stacker stacker)
		{
			return self.TryGetComponent<Stacker>(out stacker);
		}
	}
}
