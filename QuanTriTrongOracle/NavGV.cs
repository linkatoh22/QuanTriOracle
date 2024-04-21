using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanTriTrongOracle.TabGV;


namespace QuanTriTrongOracle
{
    public partial class NavGV : Form
    {
        NavigationControl navigationControl_GV;
        NavigationButtons navigationButtons_GV;

        Color btnDefaultColor_GV = Color.MediumSeaGreen;
        Color btnSelectedtColor_GV = Color.Chartreuse;

        public NavGV()
        {
            InitializeComponent();
            InitializeNavigationControl();
            InitializeNavigationButton();
        }                                                                               

        private void InitializeNavigationControl()
        {
            List<UserControl> userControls = new List<UserControl>()
            { new GV_XemThongTin(), new GV_XemSinhVien(), new GV_XemDonVi(), new GV_XemHocPhan(), new GV_XemKHMo(), 
              new GV_XemPhanCong(), new GV_DangKy() };
            navigationControl_GV = new NavigationControl(userControls, panel2_GV);
            navigationControl_GV.Display(0);
        }
        private void InitializeNavigationButton()
        {
            List<Button> buttons = new List<Button>() { Nav_XemThongTin, Nav_XemSinhVien, Nav_XemDonVi, Nav_XemHocPhan, 
                                                        Nav_XemKHMo, Nav_XemPhanCong,Nav_DangKy };
            navigationButtons_GV = new NavigationButtons(buttons, btnDefaultColor_GV, btnSelectedtColor_GV);
            navigationButtons_GV.Hightlight(Nav_XemThongTin);
        }

        private void Nav_XemThongTin_Click(object sender, EventArgs e)
        {
            navigationControl_GV.Display(0);
            navigationButtons_GV.Hightlight(Nav_XemThongTin);
        }

        private void Nav_XemSinhVien_Click(object sender, EventArgs e)
        {
            navigationControl_GV.Display(1);
            navigationButtons_GV.Hightlight(Nav_XemSinhVien);
        }

        private void Nav_XemDonVi_Click(object sender, EventArgs e)
        {
            navigationControl_GV.Display(2);
            navigationButtons_GV.Hightlight(Nav_XemDonVi);
        }
        private void Nav_XemHocPhan_Click(object sender, EventArgs e)
        {
            navigationControl_GV.Display(3);
            navigationButtons_GV.Hightlight(Nav_XemHocPhan);
        }

        private void Nav_XemKHMo_Click(object sender, EventArgs e)
        {
            navigationControl_GV.Display(4);
            navigationButtons_GV.Hightlight(Nav_XemKHMo);
        }

        private void Nav_XemPhanCong_Click(object sender, EventArgs e)
        {
            navigationControl_GV.Display(5);
            navigationButtons_GV.Hightlight(Nav_XemPhanCong);
        }

        private void Nav_DangKy_Click(object sender, EventArgs e)
        {
            navigationControl_GV.Display(6);
            navigationButtons_GV.Hightlight(Nav_DangKy);
        }
    }
}
