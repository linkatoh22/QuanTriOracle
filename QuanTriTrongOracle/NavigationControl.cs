using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanTriTrongOracle
{
    public class NavigationControl
    {
        List<UserControl> userControlList= new List<UserControl>();
        Panel panel;
        public NavigationControl(List<UserControl> userControlList, Panel panel)
        {
            this.userControlList = userControlList;
            this.panel= panel;
            AddUserControl();
        }
        private void AddUserControl()
        {
            for (int i = 0; i < userControlList.Count(); i++)
            {
                // Kiểm tra xem UserControl đã được khởi tạo chưa
                if (userControlList[i] != null)
                {
                    //set every control dock style to fill
                    userControlList[i].Dock = DockStyle.Fill;
                    panel.Controls.Add(userControlList[i]);
                }
                else
                {
                    // Xuất thông báo hoặc xử lý lỗi nếu cần thiết
                    MessageBox.Show($"UserControl at index {i} is null.");
                }
            }
        }

        public void Display(int index)
        {
            if(index<userControlList.Count())
            {
                userControlList[index].BringToFront();
            }
        }

    }
}
