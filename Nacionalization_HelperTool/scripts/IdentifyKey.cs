using UnityEngine;
using UnityEngine.UI;

public class IdentifyKey : MonoBehaviour
{
    [Tooltip ("Insert the KEY from your .txt file")]
    [Header("Enter the KEY word")]
    [SerializeField] private string key;
    
    private void Start ()
    {
        GetComponent<Text>().text = LoadAndReadFile.GetKey(key);
    }
}
