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
        // ���������� ���� � ���������
        GameManager.Instance.SaveTopScores();
        EditorApplication.isPlaying = false;
#else
        // � ����� ������� ����
        GameManager.Instance.SaveTopScores();
        Application.Quit();
#endif
    }
}
