using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SmoothScrollView : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
   
    private Vector2 normalSize = new Vector2(230f, 230f);
    private Vector2 enlargedSize = new Vector2(250f, 250f);
    public Sprite orginalSprite;
    public Sprite newSprite;
    
    public float resizeSpeed = 5f;

    private RectTransform rectTransform;
    private Vector2 targetSize;

    private bool isResizing = false;

    void Start()
    {
        
        rectTransform = GetComponent<RectTransform>();
        targetSize = normalSize;
    }

    void Update()
    {
      
        if (isResizing)
        {
            rectTransform.sizeDelta = Vector2.Lerp(rectTransform.sizeDelta, targetSize, resizeSpeed * Time.deltaTime);

            
            if (Vector2.Distance(rectTransform.sizeDelta, targetSize) < 0.1f)
            {
                rectTransform.sizeDelta = targetSize;
                isResizing = false;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        this.GetComponent<Image>().sprite = newSprite;
        targetSize = enlargedSize;
        GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Bold;
        isResizing = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Image>().sprite = orginalSprite;
        targetSize = normalSize;
        GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Normal;
        isResizing = true;
    }
}
