using UnityEngine;
using System.Collections;
using DG.Tweening;

public class GameManager : MonoBehaviour {

	public GameObject[] Units = new GameObject[4];
	public GameObject ActiveUnit;
	private int _activeUnitIndex;

	private float _currentInterval;
    public static GameManager Instance;

    // Use this for initialization
    void Awake ()
    {
		ActiveUnit = Units [0];
        Instance = this;
	}

	void Update () {

		_currentInterval += Time.deltaTime;
		if (_currentInterval >= 1)
        {
			_activeUnitIndex++;
			if (_activeUnitIndex == this.Units.Length)
            {
				_activeUnitIndex = 0;
			}

			ActiveUnit = Units[_activeUnitIndex];
			_currentInterval = 0;

            // pop the unit when selected
            ActiveUnit.transform.DOScale(2.5f, 0.1f).OnComplete(() =>
            {
                ActiveUnit.transform.localScale = new Vector3(1, 1, 1);
            });
		}
	}
}
