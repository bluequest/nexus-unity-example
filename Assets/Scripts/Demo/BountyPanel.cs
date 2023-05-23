using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class BountyPanel : MonoBehaviour
{
    public Image bountyIconImage;

    public IEnumerator LoadIconImage(string imageURL)
    {
        print("Loading icon image " + imageURL);
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageURL);
        yield return request.SendWebRequest();

        if (request.responseCode == 200)
        {
            Texture2D myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            // bountyIconImage.rectTransform.rect
            Sprite newSprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
            bountyIconImage.sprite = newSprite;
        }
        else
        {

        }
    }
}
