using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PETSHOPMANAGEMENT
{
    public partial class UserForm : Form
    {
        SqlConnection conn = new SqlConnection();
        DataGrid dataGridView_Division = new DataGrid();
        DbConnect db = new DbConnect();
        public UserForm()
        {
            InitializeComponent();
            conn=new SqlConnection(db.connection());
        }
        
        private void dgvuser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
  
                // Tạo một đối tượng SqlConnection từ chuỗi kết nối

                // Mở kết nối đến cơ sở dữ liệu
                conn.Open();

                // Tạo một đối tượng SqlCommand để thực thi truy vấn
                SqlCommand cmd = new SqlCommand("SELECT * FROM sales.StaffView", conn);

                // Tạo một đối tượng SqlDataAdapter để lấy dữ liệu từ view
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // Tạo một đối tượng DataTable để lưu trữ dữ liệu từ view
                DataTable dataTable = new DataTable();

                // Đổ dữ liệu từ view vào DataTable
                adapter.Fill(dataTable);

                dataTable.Columns["BonusSalary"].ColumnName = "Salary";

                // Gán DataTable làm nguồn dữ liệu cho DataGridView
                dataGridView_Division.DataSource = dataTable;
                // Đóng kết nối đến cơ sở dữ liệu
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserModule uM = new UserModule();
            uM.ShowDialog();
        }
    }
}
