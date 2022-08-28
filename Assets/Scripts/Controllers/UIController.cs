using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class UIController : GameMonoBehavior
{
    public Text title;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI mainText;
    public RectTransform Buttons;
    public GameObject buttonPrefab;
    
    public Animator animator;
    public Button InventoryButton;

    public GameObject MainPanel;
    public GameObject GameMenu;
    public GameObject LoadMenu;
    public GameObject SaveMenu;

    public Inventory Inventory;

   
    public WorkflowTransition InventoryTransition;
    public StatementsController StatementsController;

    public State currentState;


    public float DefaultSpeetTyping = .03f;
    public float SpeetTyping;

    public int NumCharsAtOnce = 1;

    private void Start()
    {
        InventoryButton.onClick.AddListener(OpenInventory);
        Show();
    }
    private void Update()
    {
        TimeText.text = scene.TimeController.ToString();
    }
    public void OpenInventory()
    {
        
        InventoryTransition.Transit();

    }

    public void Show() { MainPanel.SetActive(true); }
    public void Hide() { MainPanel.SetActive(false); }
    internal void InitState(State state)
    {
        currentState = state;
        animator.SetBool("IsOpen", false);

        title.text = state.Title;
        mainText.text = "";

        ClearOptions();
        StopAllCoroutines();

        var sentences = new List<string>();

        if (state.Entry != null)
        {
            sentences.Add(state.Entry.Description);
            var trans_statemensts = StatementsController.GetStatements(state.Entry); 

            if (!String.IsNullOrEmpty(trans_statemensts))
                sentences.Add(trans_statemensts);
        }

        sentences.Add(" ");
        sentences.Add(state.GetText());

        SpeetTyping = DefaultSpeetTyping;
        var statemensts = StatementsController.GetStatements(state);

        if (!String.IsNullOrEmpty(statemensts))
            sentences.Add(statemensts);


        //var test = new StringBuilder();

        //foreach(var sentence in sentences)
        //{
        //    test.AppendLine(sentence);
        //}

        //mainText.text = test.ToString();
        StartCoroutine(TypeSentence(mainText, state, sentences.ToArray()));


    }
 
    

    void ClearOptions()
    {

        //foreach (Transform child in Buttons)
        //{
        //    GameObject.Destroy(child.gameObject);
        //}

    }
    string ShowOptions(State state)
    {
        var result = new StringBuilder();
        var template = "<link={0}><color={1}>{2}</color></link> ";
        var color = "blue";
        var isfirst = true;
        foreach (var t in state.GetTransitions())
        {
            var id = t.Id;

            if (string.IsNullOrEmpty(id))
                id = t.ActionName;

            if (!isfirst)
                result.Append(" / ");

                result.Append(string.Format(template, id, color, t.ActionName));

            

            t.ParentState = state;

            isfirst = false;

            //var gbutton = Instantiate(buttonPrefab);
            //gbutton.transform.SetParent(Buttons, false);
            //gbutton.transform.localScale = new Vector3(1, 1, 1);


            //var button = gbutton.GetComponent<Button>();
            //button.onClick.AddListener(() => TransitToNextState(t));
            //button.GetComponentInChildren<Text>().text = t.ActionName;

        }

        //animator.SetBool("IsOpen", true);

        return result.ToString();
    }

  
  
    void TransitToNextState(Transition t)
    {
        t.Transit();
    }

    public void TransitToNextState(string transitionId)
    {
        var transitions = currentState.GetTransitions();

        var transition = transitions.FirstOrDefault(x => x.Id == transitionId);
        
    
        if (transition != null)
            transition.Transit();


    }

    IEnumerator TypeSentence(TextMeshProUGUI t, State state, params string[] sentences)
    {

        foreach (var sentence in sentences)
        {
            if (string.IsNullOrEmpty(sentence))
                continue;

            var updated_sentence = sentence + "\r\n";

            var buffer = string.Empty;
            for (var i = 0; i < updated_sentence.Length; i++)
            {
                var c = updated_sentence[i];

                buffer += c;

                if (buffer.Length == NumCharsAtOnce || i + 1 == updated_sentence.Length)
                {
                    t.text += buffer;
                    buffer = string.Empty;
                    yield return new WaitForSeconds(SpeetTyping);
                }

                if(c=='<')
                {
                    int j ;
                    for(j = i  + 1; j < updated_sentence.Length; j++)
                    {
                        var tc = updated_sentence[j];
                        t.text += tc;

                        if(t.text.EndsWith("</link>"))
                        {
                            break;
                        }
                    }

                    i = j;
                    yield return new WaitForSeconds(SpeetTyping);
                }

               
            }
             
        
        }



        var options = ShowOptions(state);

        t.text = t.text + options;
    }

    public void ShowMainPanel()
    {
        MainPanel.SetActive(true);
        LoadMenu.SetActive(false);
        SaveMenu.SetActive(false);
        GameMenu.SetActive(false);
    }

    
}
