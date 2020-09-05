using System;
using UnityEngine;
using System.Collections.Generic;

public class LoadAndReadFile : MonoBehaviour
{
	private static LoadAndReadFile _instance;
	private static Dictionary<string, string> _fields;
	private const string DefaultLang = "pt";

	private void Awake()
	{
		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
		LoadLanguage();
	}

	private void LoadLanguage()
	{
		if (_fields == null)
			_fields = new Dictionary<string, string>();
		
		_fields.Clear();
		
		var lang = PlayerPrefs.GetString("_language", DefaultLang);
		var allTexts = (Resources.Load (@"Languages/" + lang) as TextAsset).text; //without (.txt)
		var lines = allTexts.Split (new string[] { "\r\n", "\n" }, StringSplitOptions.None);
		string key, value;

		foreach (var line in lines)
		{
			if (line.IndexOf("=") >= 0 && !line.StartsWith("#")) {
				key = line.Substring(0, line.IndexOf("="));
				value = line.Substring(line.IndexOf("=") + 1,
					line.Length - line.IndexOf ("=") - 1).Replace("\\n", Environment.NewLine);
				_fields.Add(key, value);
			}
		}
	}

	public static string GetKey(string key)
	{
		if (!_fields.ContainsKey(key)) {
			Debug.LogError ("There is no key: [" + key + "] in your text file!");
			return null;
		}
		return _fields[key];
	}
}
