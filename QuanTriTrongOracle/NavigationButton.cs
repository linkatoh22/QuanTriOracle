using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanTriTrongOracle
{
    internal class NavigationButtons
    {
        List<Button> buttons;
        Color defaultColor;
        Color selectedColor;
        public NavigationButtons(List<Button> buttons,Color defaultColor, Color selectedColor)
        {
            this.buttons = buttons;
            this.defaultColor = defaultColor;
            this.selectedColor = selectedColor;
            SetButtonColor();
        }
        private void SetButtonColor() { 
            foreach(Button button1 in buttons)
            {
                button1.BackColor = defaultColor;


            }
        }
        public void Hightlight(Button selectedeButton)
        {
            foreach(Button button1 in buttons)
            {
                if(button1 ==selectedeButton)
                {
                    selectedeButton.BackColor = selectedColor;
                }
                else
                {
                    button1.BackColor= defaultColor;
                }
            }
        }
            
    }
}
