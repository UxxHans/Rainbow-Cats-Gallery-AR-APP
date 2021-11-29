using UnityEngine.UI;
using UnityEngine;

public class NotificationBox : MonoBehaviour
{
    public GameObject notificationBox;
    public float waitTime;

    public void Show(string content)
    {
        notificationBox.SetActive(true);
        notificationBox.GetComponentInChildren<Text>().text = content;
        CancelInvoke();
        Invoke(nameof(Hide), waitTime);
    }

    void Hide()
    {
        notificationBox.SetActive(false);
    }
}
