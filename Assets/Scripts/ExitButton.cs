using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        // Остановить игру в редакторе
        GameManager.Instance.SaveTopScores();
        EditorApplication.isPlaying = false;
#else
        // В билде закрыть игру
        GameManager.Instance.SaveTopScores();
        Application.Quit();
#endif
    }
}
