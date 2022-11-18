using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(loadGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void loadGame()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
