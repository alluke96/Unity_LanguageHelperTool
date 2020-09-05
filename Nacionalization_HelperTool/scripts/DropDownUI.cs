using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropDownUI : MonoBehaviour
{
	public string[] availableLanguages;
	
	private Dropdown _drp;
	private int _index;

	private void Awake()
	{
		_drp = GetComponent<Dropdown>();
		var v = PlayerPrefs.GetInt("_language_index", 0);
		_drp.value = v;

		_drp.onValueChanged.AddListener (delegate {
			_index = _drp.value;
			PlayerPrefs.SetInt ("_language_index", _index);
			PlayerPrefs.SetString ("_language", availableLanguages [_index]);
			Debug.Log ("Language changed to " + availableLanguages [_index]);

			ApplyLanguageChanges();
		});
	}

	public void ApplyLanguageChanges()
	{
		// TODO
		var currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentScene); // just to refresh the scene
	}

	private void OnDestroy()
	{
		_drp.onValueChanged.RemoveAllListeners();
	}
}
