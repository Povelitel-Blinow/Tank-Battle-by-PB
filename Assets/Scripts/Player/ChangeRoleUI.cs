using UnityEngine;
using TMPro;

public class ChangeRoleUI : MonoBehaviour
{
    [SerializeField] private GameObject _changePanel;
    [SerializeField] private TextMeshProUGUI _timer;

    public void StartTimer()
    {
        _changePanel.SetActive(true);
        SetTimeText(0);
    }

    public void SetTimer(float time)
    {
        SetTimeText(time);
    }

    public void EndTimer()
    {
        _changePanel.SetActive(false);
        SetTimeText(0);
    }

    private void SetTimeText(float time)
    {
        _timer.text = time.ToString("F2");
    }
}
