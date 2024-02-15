using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISoundVolume : MonoBehaviour
{
    public Slider slider_sound_bgm;
    public Slider slider_sound_fx;

    private void Start()
    {
        slider_sound_bgm.value = GameData_Option.Instance.sound_volume_bgm;
        slider_sound_fx.value = GameData_Option.Instance.sound_volume_fx;
    }


    public void SaveSoundVolume()
    {
        GameData_Option.Instance.SetSound_volume_bgm(slider_sound_bgm.value);
        GameData_Option.Instance.SetSound_volume_fx(slider_sound_fx.value);
    }
}
