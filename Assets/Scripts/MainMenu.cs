using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject recordsPanel, menuPanel;
    [SerializeField] TMPro.TextMeshProUGUI textRecord;



    public void PlayButton()
    {
        SceneManager.LoadScene("Nivel1");
        audioSource.Play();
    }


    public void ShowRecords()
    {
        if (menuPanel.activeSelf)
        {
            menuPanel.SetActive(false);
            recordsPanel.SetActive(true);
        }
        StringBuilder sb= new StringBuilder();
        List<int> records = SaveManager.LoadRecord();
        int i = 0;
        foreach (var item in records)
        {
            i++;
            sb.AppendLine(i.ToString()+": "+ item.ToString());
        }
        textRecord.text =sb.ToString();
    }

    public void ShowMenu()
    {
        if (recordsPanel.activeSelf)
        {
            recordsPanel.SetActive(false);
            menuPanel.SetActive(true);
        }
    }
}
