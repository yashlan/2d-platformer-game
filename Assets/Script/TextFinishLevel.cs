using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TextFinishLevel : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = SceneManager.GetActiveScene().name.ToUpper() + " CLEARED !!!";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
