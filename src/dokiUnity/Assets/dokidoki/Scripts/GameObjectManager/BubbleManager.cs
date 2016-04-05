using UnityEngine;
using System.Collections;

public class BubbleManager : MonoBehaviour
{
    public GameObject bubble;
    public TextMesh textMesh;
    public Sprite bubbleTopLeft;
    public Sprite bubbleTopRight;
    public Sprite bubbleBottomLeft;
    public Sprite bubbleBottomRight;

    Vector2 position;

    float MaxWidth = 0.8f;
    float MaxWidth_Padding = 1.0f;
    
    
    void Reset() { 
        
    }

    void Awake() {
        textMesh.GetComponent<Renderer>().sortingOrder = 20;
        position = new Vector2(1f,1f);
    }

    void Start()
    {
    }


    void Update()
    {
        if (textMesh.GetComponent<Renderer>().bounds.extents.x < MaxWidth_Padding
            && textMesh.GetComponent<Renderer>().bounds.extents.x < bubble.GetComponent<Renderer>().bounds.extents.x)
        {
            return;
        }
        //Debug.Log("x = " + textMesh.GetComponent<Renderer>().bounds.extents.x);
        //Debug.Log("y = " + textMesh.GetComponent<Renderer>().bounds.extents.y);
        string text = textMesh.text;
        int lineLength = (int)((MaxWidth / textMesh.GetComponent<Renderer>().bounds.extents.x) * text.Length) - 1;
        string newText = text.Substring(0, lineLength/2) + "\n";
        text = text.Substring(lineLength / 2);
        int lineCount = text.Length / lineLength;
        for (int i = 0; i < lineCount;i++ )
        {
            newText += text.Substring(i * lineLength, lineLength) + "\n";
        }
        newText += text.Substring(lineCount * lineLength);


        bubble.transform.localScale = new Vector3(1.2f * bubble.transform.localScale.x * MaxWidth_Padding / bubble.GetComponent<Renderer>().bounds.extents.x,
                                bubble.transform.localScale.y * (textMesh.GetComponent<Renderer>().bounds.extents.y * (lineCount+1) + 0.4f) / bubble.GetComponent<Renderer>().bounds.extents.y,
                                bubble.transform.localScale.z);

        textMesh.text = newText;
        textMesh.transform.localPosition = new Vector3(bubble.transform.localPosition.x, bubble.transform.localPosition.y, bubble.transform.localPosition.z);

        /*
        this.transform.localPosition = new Vector3(
            -(this.gameObject.transform.parent.gameObject.GetComponent<Renderer>().bounds.extents.x / 2 + bubble.GetComponent<Renderer>().bounds.extents.x),
            this.gameObject.transform.parent.gameObject.GetComponent<Renderer>().bounds.extents.y / 2 + bubble.GetComponent<Renderer>().bounds.extents.y,
            0
            );
        Vector3 randomVector = new Vector3(Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f));
        this.transform.localPosition += randomVector;
         * */
        positionBubble(position);
    }

    public void positionBubble(Vector2 position) {
        float x = this.gameObject.transform.parent.gameObject.GetComponent<Renderer>().bounds.extents.x / 2 + bubble.GetComponent<Renderer>().bounds.extents.x;
        float y = this.gameObject.transform.parent.gameObject.GetComponent<Renderer>().bounds.extents.y / 2 + bubble.GetComponent<Renderer>().bounds.extents.y;
        if (position.x == 1 && position.y == 1)
        {
            bubble.GetComponent<SpriteRenderer>().sprite = bubbleTopRight;
        }
        else if (position.x == -1 && position.y == 1)
        {
            bubble.GetComponent<SpriteRenderer>().sprite = bubbleTopLeft;
        }
        else if (position.x == 1 && position.y == -1)
        {
            y = this.gameObject.transform.parent.gameObject.GetComponent<Renderer>().bounds.extents.y / 2 + bubble.GetComponent<Renderer>().bounds.extents.y/2;
            bubble.GetComponent<SpriteRenderer>().sprite = bubbleBottomRight;
        }else if(position.x == -1 && position.y == -1){
            y = this.gameObject.transform.parent.gameObject.GetComponent<Renderer>().bounds.extents.y / 2 + bubble.GetComponent<Renderer>().bounds.extents.y/2;
            bubble.GetComponent<SpriteRenderer>().sprite = bubbleBottomLeft;
        }
        x *= position.x;
        y *= position.y;
        this.transform.localPosition = new Vector3(x, y, 0);
        Vector3 randomVector = new Vector3(Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f));
        this.transform.localPosition += randomVector;
    }

    public void writeOnBubbleBoard(string shownName, string content, string voiceSrc, Vector2 position){
        this.show();
        textMesh.text = content;
        this.position = position;
    }

    public void testBubbleBoard() {
        writeOnBubbleBoard(null, "这世界真是残酷，我一个人完全没有办法活下去。", null, position);
    }

    public void hide(){
        bubble.SetActive(false);
        textMesh.gameObject.SetActive(false);
    }

    public void show() {
        bubble.SetActive(true);
        textMesh.gameObject.SetActive(true);
    }
}