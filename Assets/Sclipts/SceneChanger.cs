using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] int _sceneIndex;
    public void OnPressed()
    {
        if(_sceneIndex == 0)
        {
            AudioManager.instance.StartBgm(Bgms.Title);
        }
        StartCoroutine(GameManager.Instance.FadeAndChangeScene(_sceneIndex));
    }
    public void OnOption()
    {
        GameManager.Instance.OpenOption();
    }
    public void OnCredit()
    {
        GameManager.Instance.OpenCredit();
    }
    public void OnRule()
    {
        GameManager.Instance.OpenRule();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
