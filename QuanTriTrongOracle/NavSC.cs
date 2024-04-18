using QuanTriTrongOracle.TabNVCB;
using QuanTriTrongOracle.TabSC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanTriTrongOracle
{
    public partial class NavSC : Form
    {
        NavigationControl navigationControl_SC;
        NavigationButtons navigationButtons_SC;

        Color btnDefaultColor_SC = Color.MediumSeaGreen;
        Color btnSelectedtColor_SC = Color.Chartreuse;
        public NavSC()
        {
            InitializeComponent();
            InitializeNavigationControl();
            InitializeNavigationButton();
        }
        private void InitializeNavigationControl()
        {
            List<UserControl> userControls = new List<UserControl>()
            {
                new SC_SinhVien(),new SC_HocPhan(),new SC_KHMO(),new SC_DangKy() };
            navigationControl_SC = new NavigationControl(userControls, panel2_SC);
            navigationControl_SC.Display(0);
        }
        private void InitializeNavigationButton()
        {
            List<Button> buttons = new List<Button>() { Nav_InfoSC, Nav_HocPhanSC, Nav_KHMOSC, Nav_DangKySC };
            navigationButtons_SC = new NavigationButtons(buttons, btnDefaultColor_SC, btnSelectedtColor_SC);
            navigationButtons_SC.Hightlight(Nav_InfoSC);
        }

        private void Nav_InfoSC_Click(object sender, EventArgs e)
        {
            navigationControl_SC.Display(0);
            navigationButtons_SC.Hightlight(Nav_InfoSC);
        }

        private void Nav_HocPhanSC_Click(object sender, EventArgs e)
        {
            navigationControl_SC.Display(1);
            navigationButtons_SC.Hightlight(Nav_HocPhanSC);
        }

        private void Nav_KHMOSC_Click(object sender, EventArgs e)
        {
            navigationControl_SC.Display(2);
            navigationButtons_SC.Hightlight(Nav_KHMOSC);
        }

        private void Nav_DangKySC_Click(object sender, EventArgs e)
        {
            navigationControl_SC.Display(3);
            navigationButtons_SC.Hightlight(Nav_DangKySC);
        }
    }
}
