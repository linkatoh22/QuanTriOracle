using System;
using System.Collections.Generic;
using QuanTriTrongOracle.TabGVU;
using QuanTriTrongOracle.TabTK;
using QuanTriTrongOracle.TabGV;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanTriTrongOracle
{
    public partial class NavTK2 : Form
    {
        NavigationControl navigationControl;
        NavigationButtons navigationButtons;

        Color btnDefaultColor = Color.MediumSeaGreen;
        Color btnSelectedtColor = Color.Chartreuse;
        public NavTK2()
        {
            InitializeComponent();
            InitializeNavigationControl();
            InitializeNavigationButton();
        }
        private void InitializeNavigationControl()
        {
            List<UserControl> userControls = new List<UserControl>()
            {
                new GVU_NhanSu(),new GV_DangKy(),new TK_PhanCong(),new TK_NhanSu(),new TK_All()};
            navigationControl = new NavigationControl(userControls, panel2);
            navigationControl.Display(0);
        }
        private void InitializeNavigationButton()
        {
            List<Button> buttons = new List<Button>() { Nav_NhanSu, Nav_DangKy, Nav_PhanCong, Nav_MNhanSu, Nav_All};
            navigationButtons = new NavigationButtons(buttons, btnDefaultColor, btnSelectedtColor);
            navigationButtons.Hightlight(Nav_NhanSu);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Nav_NhanSu_Click(object sender, EventArgs e)
        {
            navigationControl.Display(0);
            navigationButtons.Hightlight(Nav_NhanSu);
        }

        private void Nav_DangKy_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1);
            navigationButtons.Hightlight(Nav_DangKy);
        }

        private void Nav_PhanCong_Click(object sender, EventArgs e)
        {
            navigationControl.Display(2);
            navigationButtons.Hightlight(Nav_PhanCong);
        }

        private void Nav_MNhanSu_Click(object sender, EventArgs e)
        {
            navigationControl.Display(3);
            navigationButtons.Hightlight(Nav_MNhanSu);
        }

        private void Nav_All_Click(object sender, EventArgs e)
        {
            navigationControl.Display(4);
            navigationButtons.Hightlight(Nav_All);
        }
    }
}
