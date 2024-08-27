using UnityEngine;
using UnityEngine.EventSystems;

public class NextScene : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        MainManager.Instance.OnLoadScene2SceneEvent();

    }

}
