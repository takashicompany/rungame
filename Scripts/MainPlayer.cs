namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using takashicompany.Unity;

	public class MainPlayer : TaBehaviour
	{
		private Runner _runnerIntenral;

		protected Runner runner => _runnerIntenral ?? (_runnerIntenral = GetComponent<Runner>());

		private PickUpper _pickUpperInternal;

		protected PickUpper _pickUpper => _pickUpperInternal ?? (_pickUpperInternal = GetComponent<PickUpper>());

		private Hopper _hopperInternal;

		protected Hopper _hopper => _hopperInternal ?? (_hopperInternal = GetComponent<Hopper>());
	}
}