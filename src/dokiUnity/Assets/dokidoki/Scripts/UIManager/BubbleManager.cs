using UnityEngine;
using System.Collections;

/// <summary>
/// BubbleManager manages bubble of the character to show bubble effect.
/// Create the atmosphere like reading manga
/// </summary>
public class BubbleManager : MonoBehaviour
{
    /// <summary>
    /// Pointer to the bubble GameObject
    /// </summary>
    public GameObject bubble;
    /// <summary>
    /// Pointer to text GameObject's the textMesh component
    /// </summary>
    public TextMesh textMesh;
    /// <summary>
    /// Sprite Pointer to the bubble background picture which tail is pointed to bottom right
    /// </summary>
    public Sprite bubbleTopLeft;
    /// <summary>
    /// Sprite Pointer to the bubble background picture which tail is pointed to bottom left
    /// </summary>
    public Sprite bubbleTopRight;
    /// <summary>
    /// Sprite Pointer to the bubble background picture which tail is pointed to top right
    /// </summary>
    public Sprite bubbleBottomLeft;
    /// <summary>
    /// Sprite Pointer to the bubble background picture which tail is pointed to top left
    /// </summary>
    public Sprite bubbleBottomRight;
    /// <summary>
    /// Read the position of character and then decides position of the bubble
    /// </summary>
    Vector2 position;

    /// <summary>
    /// row length of the text
    /// </summary>
    float MaxWidth = 1.4f;
    /// <summary>
    /// the total length of the row and its padding
    /// </summary>
    float MaxWidth_Padding = 1.6f;


    void Awake() {
        textMesh.GetComponent<Renderer>().sortingOrder = 100;
    }
    /// <summary>
    /// Detect bubble text's bounds' width and height.
    /// If width(max row length) is bigger than MaxWidth, and then cut the text into multiple lines.
    /// And Then update bubble text.
    /// </summary>
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
    /// <summary>
    /// Put bubble into a proper postion according to the character's position
    /// </summary>
    /// <param name="position">Character's position</param>
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
    /// <summary>
    /// Write a new dialog which contains character's name, text content, and voice source, into the bubble
    /// </summary>
    /// <param name="shownName">Character's name</param>
    /// <param name="content">Dialog's text content</param>
    /// <param name="voiceSrc">Voice source name</param>
    /// <param name="characterPosition">Character's position</param>
    public void writeOnBubbleBoard(string shownName, string content, string voiceSrc, Vector2 characterPosition){
        this.show();
        textMesh.text = content;
        this.position.x = (characterPosition.x < 0.5)?1:-1;
        this.position.y = (characterPosition.y <= 0.5)?1:-1;
        positionBubble(this.position);
        //Debug.Log("characterPosition = " + characterPosition);
        //Debug.Log("this.position = " + this.position);
    }
    public void testBubbleBoard() {
        writeOnBubbleBoard(null, "这世界真是残酷，我一个人完全没有办法活下去。", null, position);
    }
    /// <summary>
    /// Hide the bubble
    /// </summary>
    public void hide(){
        bubble.SetActive(false);
        textMesh.gameObject.SetActive(false);
    }
    /// <summary>
    /// Show the bubble
    /// </summary>
    public void show() {
        bubble.SetActive(true);
        textMesh.gameObject.SetActive(true);
    }
}