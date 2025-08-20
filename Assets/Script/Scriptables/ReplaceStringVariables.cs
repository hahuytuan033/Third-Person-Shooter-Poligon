using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne.UI
{
    public class ReplaceStringVariables : MonoBehaviour
    {
        public StringVariable variableTo;

        public UI_UpdateText textUpdater;

        public void Replace()
        {
            textUpdater.stringVariable = variableTo;
            textUpdater.UpdateFromStringVariable();
        }
    }
}

