using UnityEngine;
using UnityEngine.EventSystems;

public class SaveButton : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        MainManager.Instance.Save();
        Debug.Log("Finish Save");
    }
}
