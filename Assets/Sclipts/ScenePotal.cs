using UnityEngine;

public class ScenePotal : MonoBehaviour, IInteractable
{
    [SerializeField] string _name = string.Empty;
    [SerializeField] int _indexScene;
    public string GetInteractText()
    {
        return "[F]" + _name + "‚ÖˆÚ“®‚·‚é";
    }

    public void Interact(PlayerInteraction player)
    {
        StartCoroutine(GameManager.Instance.FadeAndChangeScene(_indexScene));
    }
}
