using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    public TMP_InputField inputField;
    public TextMeshProUGUI bestPlayerText;


    // Start is called before the first frame update
    void Start()
    {
       
        inputField.onValueChanged.AddListener(UpdateNameDisplay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void UpdateNameDisplay (string newName)
    {
        GameManager.Instance.currentPlayerNameText = newName;
        bestPlayerText.text = "Hello, " + GameManager.Instance.currentPlayerNameText + "!";
    }
}
