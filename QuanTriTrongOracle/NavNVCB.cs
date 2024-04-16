using QuanTriTrongOracle.Tab;
using QuanTriTrongOracle.TabNVCB;
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
    public partial class NavNVCB : Form
    {
        NavigationControl navigationControl_NVCB;
        NavigationButtons navigationButtons_NVCB;

        Color btnDefaultColor_NVCB = Color.MediumSeaGreen;
        Color btnSelectedtColor_NVCB = Color.Chartreuse;

        public NavNVCB()
        {
            InitializeComponent();
            InitializeNavigationControl();
            InitializeNavigationButton();
        }
        private void InitializeNavigationControl()
        {
            List<UserControl> userControls = new List<UserControl>()
            {
                new NVCB_NhanSu(),new NVCB_SinhVien(),new NVCB_Dvi(),new NVCB_HocPhan(),new NVCB_KHMO() };
            navigationControl_NVCB = new NavigationControl(userControls, panel2_NVCB);
            navigationControl_NVCB.Display(0);
        }
        private void InitializeNavigationButton()
        {
            List<Button> buttons = new List<Button>() { Nav_Info, Nav_SinhVien, Nav_Dvi, Nav_HocPhan, Nav_KHMO };
            navigationButtons_NVCB = new NavigationButtons(buttons, btnDefaultColor_NVCB, btnSelectedtColor_NVCB);
            navigationButtons_NVCB.Hightlight(Nav_Info);
        }
        private void Nav_Info_Click(object sender, EventArgs e)
        {
            navigationControl_NVCB.Display(0);
            navigationButtons_NVCB.Hightlight(Nav_Info);
        }

        private void Nav_SinhVien_Click(object sender, EventArgs e)
        {
            navigationControl_NVCB.Display(1);
            navigationButtons_NVCB.Hightlight(Nav_SinhVien);
        }

        private void Nav_Dvi_Click(object sender, EventArgs e)
        {
            navigationControl_NVCB.Display(2);
            navigationButtons_NVCB.Hightlight(Nav_Dvi);
        }

        private void Nav_HocPhan_Click(object sender, EventArgs e)
        {
            navigationControl_NVCB.Display(3);
            navigationButtons_NVCB.Hightlight(Nav_HocPhan);
        }

        private void Nav_KHMO_Click(object sender, EventArgs e)
        {
            navigationControl_NVCB.Display(4);
            navigationButtons_NVCB.Hightlight(Nav_KHMO);
        }
    }
}
