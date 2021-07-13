
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject LevelUI;
    public void ActivateUI()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if (index == 1 || index == 2 || index == 3)
        {
            LevelUI.SetActive(true);
        }
    }
}