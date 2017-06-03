using UnityEngine;
using UnityEngine.UI;
//@Author Alec Harrison
//Used for debugging and learning how listeners work in unity
public class On_Click : MonoBehaviour
{
	public Button Button;

	void Start()
	{
		Button btn = Button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
        
        Debug.Log("You have clicked the button!");
	}
}