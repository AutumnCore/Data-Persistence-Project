using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputField : MonoBehaviour
{
    private TMP_InputField nameInput;
    [SerializeField]
    //private string playerName;
    // Start is called before the first frame update
    void Start()
    {
        nameInput = gameObject.GetComponent<TMP_InputField>();
    }
    
    public void PassPlayerName()
    {
        if(PersistentDataManager.Instance != null)
        {
            PersistentDataManager.Instance.SetCurrentPlayerName(nameInput.text);
        }
    }
}
