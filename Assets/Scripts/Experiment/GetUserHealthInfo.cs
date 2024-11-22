using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetUserHealthInfo : MonoBehaviour
{
    public List<Sprite> emoji;
    public List<string> emoji_Status_txt;
    public TMP_Text UserCurrent_emoji_Status_txt;
    int UserEmoji_Click_count=0;

    public void UserHealthstatus()
    {
       
        UserEmoji_Click_count++;
        if (UserEmoji_Click_count == emoji.Count)
        {
            UserEmoji_Click_count=0;
        }
        this.GetComponent<Image>().sprite =emoji[UserEmoji_Click_count];
        UserCurrent_emoji_Status_txt.text = emoji_Status_txt[UserEmoji_Click_count];
    }
}
