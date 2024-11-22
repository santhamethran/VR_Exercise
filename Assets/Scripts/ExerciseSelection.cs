using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;

public class ExerciseSelection : MonoBehaviour
{
    [SerializeField]
    private Button _start;
    [SerializeField]
    private RawImage _rawImg;
    private static string[] _exercises = new string[7] {"Fist Hold", "O Shape", "Fingertip Touch", "Knuckle Bend", "Intrinsic Flexion", "Thumb Extension", "Supination Pronation" };
    [SerializeField]
    private TextMeshProUGUI _title;
    [SerializeField]
    private VideoClip[] _clips;
    [SerializeField]
    private VideoPlayer _vd;

    public void SelectExercise(int index)
    {
        _title.text = _exercises[index];

        _vd.clip = _clips[index];

        _start.onClick.RemoveAllListeners();
        int i = index;  // Value lost, so save local.
        _start.onClick.AddListener(() => ConfirmExercise(_exercises[i]));
    }

    public void ConfirmExercise(string scene)
    {
        SceneManager.LoadScene(scene);
        SceneControlPanels.instance.IscontrolPanels = true;
        /*if (SceneManager.GetSceneByName(scene).IsValid())
            SceneManager.LoadScene(1);
        else
        {
            _title.text = scene + " doesn't exist. Cnt " + SceneManager.sceneCountInBuildSettings;
        }*/
    }
}
