using System;
using System.Collections.Generic;
using QuanTriTrongOracle.TabGVU;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanTriTrongOracle
{
    public partial class Nav_GVU2 : Form
    {
        NavigationControl navigationControl;
        NavigationButtons navigationButtons;

        Color btnDefaultColor = Color.MediumSeaGreen;
        Color btnSelectedtColor = Color.Chartreuse;
        public Nav_GVU2()
        {
            InitializeComponent();
            InitializeNavigationControl();
            InitializeNavigationButton();
        }
        private void InitializeNavigationControl()
        {
            List<UserControl> userControls = new List<UserControl>()
            {
                new GVU_NhanSu(),new GVU_SinhVien(),new GVU_DonVi(),new GVU_HocPhan(),new GVU_KHMo(),new GVU_PhanCong(),new GVU_DangKy() };
            navigationControl = new NavigationControl(userControls, panel2);
            navigationControl.Display(0);
        }
        private void InitializeNavigationButton()
        {
            List<Button> buttons = new List<Button>() { Nav_NhanSu, Nav_SinhVien, Nav_DonVi, Nav_HocPhan, Nav_KHMo, Nav_PhanCong, Nav_DangKy };
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

        private void Nav_SinhVien_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1);
            navigationButtons.Hightlight(Nav_SinhVien);
        }

        private void Nav_DonVi_Click(object sender, EventArgs e)
        {
            navigationControl.Display(2);
            navigationButtons.Hightlight(Nav_DonVi);
        }

        private void Nav_HocPhan_Click(object sender, EventArgs e)
        {
            navigationControl.Display(3);
            navigationButtons.Hightlight(Nav_HocPhan);
        }

        private void Nav_KHMo_Click(object sender, EventArgs e)
        {
            navigationControl.Display(4);
            navigationButtons.Hightlight(Nav_KHMo);
        }

        private void Nav_PhanCong_Click(object sender, EventArgs e)
        {
            navigationControl.Display(5);
            navigationButtons.Hightlight(Nav_PhanCong);
        }

        private void Nav_DangKy_Click(object sender, EventArgs e)
        {
            navigationControl.Display(6);
            navigationButtons.Hightlight(Nav_DangKy);
        }
    }
}
