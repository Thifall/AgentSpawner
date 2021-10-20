using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuloUI : MonoBehaviour
{
    public Text textField;
    public void ModuloButton()
    {
        textField.text = ModuloNumbers.DisplayNumbers();
    }
}
