using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] int _sceneIndex;
    public void OnPressed()
    {
        SceneManager.LoadScene(_sceneIndex);
    }
    public void OnOption()
    {
        GameManager.Instance.OpenOption();
    }
}
