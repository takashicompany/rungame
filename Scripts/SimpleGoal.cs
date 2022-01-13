namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class SimpleGoal : Goal
	{
		[Header("ゴールすると指定のパスのプレハブをロードして一定時間後、最初のシーンをロードする")]
		[SerializeField]
		private string _levelCompletePrefabPath = "RunGame/SimpleLevelComplete";

		[SerializeField]
		private float _waitDuration = 3f;

		[SerializeField]
		private bool _stopRunnerWhenGoal = true;

		private bool _alreadyGoal;

		public override void OnGoal(Runner runner)
		{
			if (_alreadyGoal)
			{
				return;
			}

			_alreadyGoal = true;

			base.OnGoal(runner);

			if (_stopRunnerWhenGoal)
			{
				runner.Stop();
			}

			Instantiate(Resources.Load<GameObject>(_levelCompletePrefabPath));

			StartCoroutine(CoOnGoal());

			IEnumerator CoOnGoal()
			{
				yield return new WaitForSeconds(_waitDuration);
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			}
		}
	}
}