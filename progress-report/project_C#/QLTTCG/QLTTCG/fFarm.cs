using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTTCG
{
    public partial class fFarm : Form
    {
        public fFarm()
        {
            InitializeComponent();
        }
        private string connectionString = @"Server=DESKTOP-HUA4EOJ\SQLEXPRESS;Database=QLTTCG;Trusted_Connection=True;";


        private void fFarm_Load(object sender, EventArgs e)
        {
            LoadNhanVienData();
            LoadKhachHangData();
            LoadHoCaData();
            LoadCaData();
            LoadThucAnData();
            LoadThuocData();
            LoadDotThaCaData();
            LoadChoAnData();
            LoadSuDungThuocData();
            LoadTheoDoiSucKhoeData();
            LoadTheoDoiMoiTruongData();
            LoadBenhData();
            LoadHoaDonData();
            LoadChiTietHoaDonData();
            LoadBaoCaoData();
            txbTongThu.ReadOnly = true;
            txbTongChi.ReadOnly = true;
            txbLoiNhuan.ReadOnly = true;
            txbTongThu.ReadOnly = true;
            txbTongThu.BackColor = SystemColors.Control; // Màu nền giống Label
            txbTongThu.BorderStyle = BorderStyle.None;   // Bỏ viền

            txbTongChi.ReadOnly = true;
            txbTongChi.BackColor = SystemColors.Control;
            txbTongChi.BorderStyle = BorderStyle.None;

            txbLoiNhuan.ReadOnly = true;
            txbLoiNhuan.BackColor = SystemColors.Control;
            txbLoiNhuan.BorderStyle = BorderStyle.None;
            txbThanhTien.ReadOnly = true;
            txbThanhTien.BackColor = SystemColors.Control; // Màu nền giống Label
            txbThanhTien.BorderStyle = BorderStyle.None;   // Bỏ viền
        }
        private void LoadBaoCaoData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM BaoCao";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    DGVBaoCao.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
        private void LoadChiTietHoaDonData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM ChiTietHoaDon";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    DGVChiTietHoaDon.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
        private void LoadHoaDonData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaHoaDon, MaKhachHang, MaNhanVien, NgayBan FROM HoaDon";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    DGVHoaDon.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
        private void LoadBenhData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Benh";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    DGVBenh.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
        private void LoadTheoDoiMoiTruongData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM TheoDoiMoiTruong";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    DGVTheoDoiMoiTruong.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
        private void LoadTheoDoiSucKhoeData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM TheoDoiSucKhoe";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    DGVTheoDoiSucKhoe.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
        private void LoadSuDungThuocData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM SuDungThuoc";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    DGVLichSuDungThuoc.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
        private void LoadChoAnData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM ChoAn";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    DGVLichSuChoAn.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu lịch sử cho ăn: " + ex.Message);
                }
            }
        }
        private void LoadDotThaCaData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM DotThaCa";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    DGVDotThaCa.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu đợt thả cá: " + ex.Message);
                }
            }
        }
        private void LoadThuocData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Thuoc";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    DGVThuoc.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu thuốc: " + ex.Message);
                }
            }
        }
        private void LoadThucAnData() {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM ThucAn";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    DGVThucAn.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void LoadCaData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Ca";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    DGVCa.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void LoadHoCaData()
        {
            textBoxMaHoCa.ReadOnly = true;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM HoCa";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    DGVHoCa.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu Hồ cá: " + ex.Message);
                }
            }
        }

        private void LoadNhanVienData()
        {
            string connectionString = "Data Source=DESKTOP-HUA4EOJ\\SQLEXPRESS;Initial Catalog=QLTTCG;Integrated Security=True";
            string query = "SELECT * FROM NhanVien";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                DGVNhanVien.DataSource = dataTable;
            }
        }
        private void btnAdd_T1_Click(object sender, EventArgs e)
        {
            string soDienThoai = txbSDTNhanVien.Text.Trim();

            // Kiểm tra số điện thoại có hợp lệ không
            if (!Regex.IsMatch(soDienThoai, @"^\d+$"))
            {
                MessageBox.Show("Số điện thoại chỉ được phép chứa các chữ số.");
                return;
            }

            if (soDienThoai.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số.");
                return;
            }

            // Lấy các giá trị từ TextBox khác
            string maNhanVien = txbMaNhanVien.Text.Trim();
            string tenNhanVien = txbHoTenNhanVien.Text.Trim();

            // Tiến hành thêm dữ liệu vào cơ sở dữ liệu
            try
            {
                string connectionString = @"Server=DESKTOP-HUA4EOJ\SQLEXPRESS;Database=QLTTCG;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO NhanVien (MaNhanVien, HoTenNV, SoDienThoaiNV) VALUES (@MaNhanVien, @HoTenNV, @SoDienThoaiNV)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Thêm tham số vào câu lệnh SQL
                        cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                        cmd.Parameters.AddWithValue("@HoTenNV", tenNhanVien);
                        cmd.Parameters.AddWithValue("@SoDienThoaiNV", soDienThoai);

                        // Thực thi câu lệnh
                        cmd.ExecuteNonQuery();
                    }
                }

                // Cập nhật lại DataGridView sau khi thêm dữ liệu
                LoadNhanVienData();
                MessageBox.Show("Thêm nhân viên thành công!");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên" );
            }
        }

        private void btnEdit_T1_Click(object sender, EventArgs e)
        {
            string maNhanVien = txbMaNhanVien.Text;
            string hoTenNV = txbHoTenNhanVien.Text;
            string soDienThoaiNV = txbSDTNhanVien.Text;

            // Kiểm tra nếu các trường không rỗng
            if (!string.IsNullOrEmpty(maNhanVien) && !string.IsNullOrEmpty(hoTenNV) && !string.IsNullOrEmpty(soDienThoaiNV))
            {
                string query = "UPDATE NhanVien SET HoTenNV = @HoTenNV, SoDienThoaiNV = @SoDienThoaiNV WHERE MaNhanVien = @MaNhanVien";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@HoTenNV", hoTenNV);
                    command.Parameters.AddWithValue("@SoDienThoaiNV", soDienThoaiNV);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                // Sau khi sửa dữ liệu, tải lại DataGridView
                LoadNhanVienData();

                // Thông báo
                MessageBox.Show("Sửa thông tin nhân viên thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo");
            }
        }

        private void btnDelete_T1_Click(object sender, EventArgs e)
        {
            string maNhanVien = txbMaNhanVien.Text;

            // Kiểm tra nếu MaNhanVien không rỗng
            if (!string.IsNullOrEmpty(maNhanVien))
            {
                string query = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                // Sau khi xóa dữ liệu, tải lại DataGridView
                LoadNhanVienData();

                // Thông báo
                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mã Nhân Viên để xóa.", "Cảnh báo");
            }
        }

        private void DGVNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVNhanVien.Rows[e.RowIndex];
                txbMaNhanVien.Text = row.Cells["MaNhanVien"].Value.ToString();
                txbHoTenNhanVien.Text = row.Cells["HoTenNV"].Value.ToString();
                txbSDTNhanVien.Text = row.Cells["SoDienThoaiNV"].Value.ToString();
            }
            // Kiểm tra nếu người dùng đã chọn một dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow row = DGVNhanVien.Rows[e.RowIndex];

                // Đặt dữ liệu từ các cell vào các TextBox
                txbMaNhanVien.Text = row.Cells["MaNhanVien"].Value.ToString();
                txbHoTenNhanVien.Text = row.Cells["HoTenNV"].Value.ToString();
                txbSDTNhanVien.Text = row.Cells["SoDienThoaiNV"].Value.ToString();
            }
        }
        private void LoadKhachHangData()
        {
            string connectionString = "Data Source=DESKTOP-HUA4EOJ\\SQLEXPRESS;Initial Catalog=QLTTCG;Integrated Security=True";
            string query = "SELECT * FROM KhachHang";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                DGVKhachHang.DataSource = dataTable;
            }
        }
        private void btnAdd_T2_Click(object sender, EventArgs e)
        {
            string maKH = txbMaKhachHang.Text.Trim();
            string tenKH = txbHoTenKhachHang.Text.Trim();
            string sdtKH = txbSDTKhachHang.Text.Trim();
            string emailKH = txbEmailKhachHang.Text.Trim();
            string diaChiKH = txbDiaChiKhachHang.Text.Trim();

            string connectionString = "Data Source=DESKTOP-HUA4EOJ\\SQLEXPRESS;Initial Catalog=QLTTCG;Integrated Security=True";

            // Kiểm tra trùng lặp
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string checkQuery = "SELECT COUNT(*) FROM KhachHang WHERE MaKhachHang = @MaKH";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@MaKH", maKH);

                connection.Open();
                int count = (int)checkCommand.ExecuteScalar(); // Lấy số lượng bản ghi có MaKhachHang = maKH
                connection.Close();

                if (count > 0)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng nhập mã khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng không thực hiện thêm
                }
            }

            // Thêm khách hàng nếu không trùng
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO KhachHang (MaKhachHang, HoTenKH, SoDienThoaiKH, EmailKH, DiaChiKH) VALUES (@MaKH, @TenKH, @SDTKH, @EmailKH, @DiaChiKH)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaKH", maKH);
                command.Parameters.AddWithValue("@TenKH", tenKH);
                command.Parameters.AddWithValue("@SDTKH", sdtKH);
                command.Parameters.AddWithValue("@EmailKH", emailKH);
                command.Parameters.AddWithValue("@DiaChiKH", diaChiKH);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            MessageBox.Show("Thêm khách hàng thành công!", "Thông báo");
            LoadKhachHangData(); // Cập nhật lại DataGridView
        }

        private void btnEdit_T2_Click(object sender, EventArgs e)
        {
            string maKH = txbMaKhachHang.Text.Trim();
            string tenKH = txbHoTenKhachHang.Text.Trim();
            string sdtKH = txbSDTKhachHang.Text.Trim();
            string emailKH = txbEmailKhachHang.Text.Trim();
            string diaChiKH = txbDiaChiKhachHang.Text.Trim();

            string connectionString = "Data Source=DESKTOP-HUA4EOJ\\SQLEXPRESS;Initial Catalog=QLTTCG;Integrated Security=True";
            string query = "UPDATE KhachHang SET HoTenKH = @TenKH, SoDienThoaiKH = @SDTKH, EmailKH = @EmailKH, DiaChiKH = @DiaChiKH WHERE MaKhachHang = @MaKH";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaKH", maKH);
                command.Parameters.AddWithValue("@TenKH", tenKH);
                command.Parameters.AddWithValue("@SDTKH", sdtKH);
                command.Parameters.AddWithValue("@EmailKH", emailKH);
                command.Parameters.AddWithValue("@DiaChiKH", diaChiKH);

                connection.Open();
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo");
            LoadKhachHangData();
        }

        private void btnDelete_T2_Click(object sender, EventArgs e)
        {
            string maKH = txbMaKhachHang.Text.Trim();

            string connectionString = "Data Source=DESKTOP-HUA4EOJ\\SQLEXPRESS;Initial Catalog=QLTTCG;Integrated Security=True";
            string query = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKH";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaKH", maKH);

                connection.Open();
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Xóa khách hàng thành công!", "Thông báo");
            LoadKhachHangData();
        }
        private void DGVKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVKhachHang.Rows[e.RowIndex];
                txbMaKhachHang.Text = row.Cells["MaKhachHang"].Value.ToString();
                txbHoTenKhachHang.Text = row.Cells["HoTenKH"].Value.ToString();
                txbSDTKhachHang.Text = row.Cells["SoDienThoaiKH"].Value.ToString();
                txbEmailKhachHang.Text = row.Cells["EmailKH"].Value.ToString();
                txbDiaChiKhachHang.Text = row.Cells["DiaChiKH"].Value.ToString();
            }
        }
        private void tpLichSuChoAn_Click(object sender, EventArgs e)
        {

        }

       

        private void tpThuoc_Click(object sender, EventArgs e)
        {

        }

        private void txbMaNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbHoTenNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbSDTNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button20_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE DotThaCa SET MaHoCa = @MaHoCa, MaCa = @MaCa, NgayTha = @NgayTha, SoLuong = @SoLuong " +
                                   "WHERE MaDotThaCa = @MaDotThaCa";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaDotThaCa", txbMaDotThaCa.Text);
                    command.Parameters.AddWithValue("@MaHoCa", TextBMaHoCa.Text);
                    command.Parameters.AddWithValue("@MaCa", TextBMaCa.Text);
                    command.Parameters.AddWithValue("@NgayTha", Convert.ToDateTime(TxbNgayTha.Text));
                    command.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(txbSoLuong.Text));
                    command.ExecuteNonQuery();

                    MessageBox.Show("Sửa thành công!");
                    LoadDotThaCaData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa đợt thả cá: " + ex.Message);
                }
            }
        }

       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txbMaKhachHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbHoTenKhachHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbSDTKhachHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbEmailKhachHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbDiaChiKhachHang_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void DGVHoCa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng người dùng đã click vào một dòng hợp lệ
            {
                DataGridViewRow row = DGVHoCa.Rows[e.RowIndex];
                if (row.Cells["MaHoCa"].Value != null) // Kiểm tra giá trị không rỗng
                {
                    textBoxMaHoCa.Text = row.Cells["MaHoCa"].Value.ToString();
                }
                if (row.Cells["DienTich"].Value != null) // Kiểm tra giá trị không rỗng
                {
                    txbDienTich.Text = row.Cells["DienTich"].Value.ToString();
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txbMaCa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbTenCa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbGiaBan_TextChanged(object sender, EventArgs e)
        {

        }

        private void DGVCa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấn vào một dòng dữ liệu (không phải tiêu đề)
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ các ô trong dòng đã nhấn
                string maCa = DGVCa.Rows[e.RowIndex].Cells["MaCa"].Value.ToString();
                string tenCa = DGVCa.Rows[e.RowIndex].Cells["tenCa"].Value.ToString();
                string giaBan = DGVCa.Rows[e.RowIndex].Cells["giaBan"].Value.ToString();

                // Hiển thị dữ liệu vào các TextBox
                txbMaCa.Text = maCa;
                txbTenCa.Text = tenCa;
                txbGiaBan.Text = giaBan;
            }
        }

        private void btnAdd_T4_Click(object sender, EventArgs e)
        {
            string maCa = txbMaCa.Text.Trim();
            string tenCa = txbTenCa.Text.Trim();
            string giaBan = txbGiaBan.Text.Trim();

            if (string.IsNullOrEmpty(maCa) || string.IsNullOrEmpty(tenCa) || string.IsNullOrEmpty(giaBan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Ca (MaCa, tenCa, giaBan) VALUES (@MaCa, @tenCa, @giaBan)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaCa", maCa);
                    command.Parameters.AddWithValue("@tenCa", tenCa);
                    command.Parameters.AddWithValue("@giaBan", Convert.ToDecimal(giaBan));

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm cá thành công!");
                LoadCaData();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi thêm cá " );
            }
        }

        private void btnEdit_T4_Click(object sender, EventArgs e)
        {
            string maCa = txbMaCa.Text.Trim();
            string tenCa = txbTenCa.Text.Trim();
            string giaBan = txbGiaBan.Text.Trim();

            if (string.IsNullOrEmpty(maCa) || string.IsNullOrEmpty(tenCa) || string.IsNullOrEmpty(giaBan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Ca SET tenCa = @tenCa, giaBan = @giaBan WHERE MaCa = @MaCa";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaCa", maCa);
                    command.Parameters.AddWithValue("@tenCa", tenCa);
                    command.Parameters.AddWithValue("@giaBan", Convert.ToDecimal(giaBan));

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật cá thành công!");
                LoadCaData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật cá: " + ex.Message);
            }
        }

        private void btnDelete_T4_Click(object sender, EventArgs e)
        {
            string maCa = txbMaCa.Text.Trim();

            if (string.IsNullOrEmpty(maCa))
            {
                MessageBox.Show("Vui lòng nhập Mã Cá để xóa.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Ca WHERE MaCa = @MaCa";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaCa", maCa);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Xóa cá thành công!");
                LoadCaData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa cá: " + ex.Message);
            }
        }

        // Xử lý sự kiện khi nhấn vào một hàng trong DataGridView
        private void DGVCa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVCa.Rows[e.RowIndex];
                txbMaCa.Text = row.Cells["MaCa"].Value.ToString();
                txbTenCa.Text = row.Cells["tenCa"].Value.ToString();
                txbGiaBan.Text = row.Cells["giaBan"].Value.ToString();
            }
        }
        private string GenerateMaHoCa()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TOP 1 MaHoCa FROM HoCa ORDER BY MaHoCa DESC";
                SqlCommand command = new SqlCommand(query, connection);
                object result = command.ExecuteScalar();

                if (result != null) // Nếu đã có dữ liệu
                {
                    string lastMaHoCa = result.ToString(); // VD: "HC001"
                    int numberPart = int.Parse(lastMaHoCa.Substring(2)); // Lấy phần số, VD: 001 -> 1
                    return "HC" + (numberPart + 1).ToString("D3"); // Tăng số và định dạng lại, VD: 002
                }
                else
                {
                    // Nếu chưa có dữ liệu trong bảng
                    return "HC001";
                }
            }
        }
        private bool IsMaHoCaExists(string maHoCa)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM HoCa WHERE MaHoCa = @MaHoCa";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHoCa", maHoCa);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0; // Trả về true nếu đã tồn tại
            }
        }

        private void btnAdd_T3_Click(object sender, EventArgs e)
        {
            string newMaHoCa = GenerateMaHoCa();

            if (!double.TryParse(txbDienTich.Text, out double dienTich) || dienTich <= 0)
            {
                MessageBox.Show("Diện Tích phải là số dương!");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO HoCa (MaHoCa, DienTich) VALUES (@MaHoCa, @DienTich)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHoCa", newMaHoCa);
                    command.Parameters.AddWithValue("@DienTich", dienTich);
                    command.ExecuteNonQuery();
                    MessageBox.Show($"Thêm thành công! Mã Hồ Cá mới: {newMaHoCa}");
                    LoadHoCaData();

                    // Hiển thị mã mới trên giao diện
                    textBoxMaHoCa.Text = GenerateMaHoCa();
                    txbDienTich.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message);
                }
            }
        }

        private void btnEdit_T3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE HoCa SET DienTich = @DienTich WHERE MaHoCa = @MaHoCa";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHoCa", textBoxMaHoCa.Text);
                    command.Parameters.AddWithValue("@DienTich", Convert.ToDouble(txbDienTich.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công!");
                    LoadHoCaData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message);
                }
            }
        }

        private void btnDelete_T3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM HoCa WHERE MaHoCa = @MaHoCa";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHoCa", textBoxMaHoCa.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    LoadHoCaData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_T5_Click(object sender, EventArgs e)
        {
            if (IsMaThucAnExists(txbMaThucAn.Text))
            {
                MessageBox.Show("Mã Thức Ăn đã tồn tại. Vui lòng nhập mã khác!");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO ThucAn (MaThucAn, TenThucAn, LoaiThucAn, GiaThucAn, DonViThucAn) " +
                                   "VALUES (@MaThucAn, @TenThucAn, @LoaiThucAn, @GiaThucAn, @DonViThucAn)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaThucAn", txbMaThucAn.Text);
                    command.Parameters.AddWithValue("@TenThucAn", txbTenThucAn.Text);
                    command.Parameters.AddWithValue("@LoaiThucAn", txbLoaiThucAn.Text);
                    command.Parameters.AddWithValue("@GiaThucAn", Convert.ToDecimal(txbGiaThucAn.Text));
                    command.Parameters.AddWithValue("@DonViThucAn", txbDonViThucAn.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!");
                    LoadThucAnData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message);
                }
            }
        }
        private bool IsMaThucAnExists(string maThucAn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM ThucAn WHERE MaThucAn = @MaThucAn";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaThucAn", maThucAn);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0; // Trả về true nếu đã tồn tại
            }
        }
        private void DGVThucAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo dòng hợp lệ
            {
                DataGridViewRow row = DGVThucAn.Rows[e.RowIndex];
                txbMaThucAn.Text = row.Cells["MaThucAn"].Value.ToString();
                txbTenThucAn.Text = row.Cells["TenThucAn"].Value.ToString();
                txbLoaiThucAn.Text = row.Cells["LoaiThucAn"].Value.ToString();
                txbGiaThucAn.Text = row.Cells["GiaThucAn"].Value.ToString();
                txbDonViThucAn.Text = row.Cells["DonViThucAn"].Value.ToString();
            }
        }

        private void btnEdit_T5_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE ThucAn SET TenThucAn = @TenThucAn, LoaiThucAn = @LoaiThucAn, GiaThucAn = @GiaThucAn, DonViThucAn = @DonViThucAn " +
                                   "WHERE MaThucAn = @MaThucAn";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaThucAn", txbMaThucAn.Text);
                    command.Parameters.AddWithValue("@TenThucAn", txbTenThucAn.Text);
                    command.Parameters.AddWithValue("@LoaiThucAn", txbLoaiThucAn.Text);
                    command.Parameters.AddWithValue("@GiaThucAn", Convert.ToDecimal(txbGiaThucAn.Text));
                    command.Parameters.AddWithValue("@DonViThucAn", txbDonViThucAn.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadThucAnData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message);
                }
            }
        }

        private void btnDelete_T5_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM ThucAn WHERE MaThucAn = @MaThucAn";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaThucAn", txbMaThucAn.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    LoadThucAnData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void txbMaThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra dòng hợp lệ
            {
                DataGridViewRow row = DGVThuoc.Rows[e.RowIndex];
                txbMaThuoc.Text = row.Cells["MaThuoc"].Value.ToString();
                txbTenThuoc.Text = row.Cells["TenThuoc"].Value.ToString();
                txbCongDung.Text = row.Cells["CongDung"].Value.ToString();
                txbDonViThuoc.Text = row.Cells["DonViThuoc"].Value.ToString();
                txbGiaThuoc.Text = row.Cells["GiaThuoc"].Value.ToString();
            }
        }
        private bool IsMaThuocExists(string maThuoc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Thuoc WHERE MaThuoc = @MaThuoc";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaThuoc", maThuoc);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0; // Trả về true nếu mã thuốc đã tồn tại
            }
        }
        private void txbMaThuoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbDonViThucAn_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbDonViThuoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_T7_Click(object sender, EventArgs e)
        {
            if (IsMaThuocExists(txbMaThuoc.Text))
            {
                MessageBox.Show("Mã Thuốc đã tồn tại. Vui lòng nhập mã khác!");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Thuoc (MaThuoc, TenThuoc, CongDung, DonViThuoc, GiaThuoc) " +
                                   "VALUES (@MaThuoc, @TenThuoc, @CongDung, @DonViThuoc, @GiaThuoc)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaThuoc", txbMaThuoc.Text);
                    command.Parameters.AddWithValue("@TenThuoc", txbTenThuoc.Text);
                    command.Parameters.AddWithValue("@CongDung", txbCongDung.Text);
                    command.Parameters.AddWithValue("@DonViThuoc", txbDonViThuoc.Text);
                    command.Parameters.AddWithValue("@GiaThuoc", Convert.ToDecimal(txbGiaThuoc.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!");
                    LoadThuocData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message);
                }
            }
        }

        private void btnEdit_T7_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Thuoc SET TenThuoc = @TenThuoc, CongDung = @CongDung, DonViThuoc = @DonViThuoc, GiaThuoc = @GiaThuoc " +
                                   "WHERE MaThuoc = @MaThuoc";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaThuoc", txbMaThuoc.Text);
                    command.Parameters.AddWithValue("@TenThuoc", txbTenThuoc.Text);
                    command.Parameters.AddWithValue("@CongDung", txbCongDung.Text);
                    command.Parameters.AddWithValue("@DonViThuoc", txbDonViThuoc.Text);
                    command.Parameters.AddWithValue("@GiaThuoc", Convert.ToDecimal(txbGiaThuoc.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadThuocData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message);
                }
            }
        }

        private void btnDelete_t7_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Thuoc WHERE MaThuoc = @MaThuoc";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaThuoc", txbMaThuoc.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    LoadThuocData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void DGVDotThaCa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem người dùng có click vào dòng hợp lệ không
            {
                DataGridViewRow row = DGVDotThaCa.Rows[e.RowIndex];
                txbMaDotThaCa.Text = row.Cells["MaDotThaCa"].Value.ToString();
                TextBMaHoCa.Text = row.Cells["MaHoCa"].Value.ToString();
                TextBMaCa.Text = row.Cells["MaCa"].Value.ToString();
                TxbNgayTha.Text = Convert.ToDateTime(row.Cells["NgayTha"].Value).ToString("yyyy-MM-dd"); // Format ngày
                txbSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
            }
        }
        private bool ValidateDotThaCaInput()
        {
            if (string.IsNullOrWhiteSpace(txbMaDotThaCa.Text) ||
                string.IsNullOrWhiteSpace(TextBMaHoCa.Text) ||
                string.IsNullOrWhiteSpace(TextBMaCa.Text) ||
                string.IsNullOrWhiteSpace(TxbNgayTha.Text) ||
                string.IsNullOrWhiteSpace(txbSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return false;
            }

            if (!DateTime.TryParse(TxbNgayTha.Text, out _))
            {
                MessageBox.Show("Ngày thả không hợp lệ!");
                return false;
            }

            if (!int.TryParse(txbSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!");
                return false;
            }

            return true;
        }
        private void btnAdd_T8_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO DotThaCa (MaDotThaCa, MaHoCa, MaCa, NgayTha, SoLuong) " +
                                   "VALUES (@MaDotThaCa, @MaHoCa, @MaCa, @NgayTha, @SoLuong)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaDotThaCa", txbMaDotThaCa.Text);
                    command.Parameters.AddWithValue("@MaHoCa", TextBMaHoCa.Text);
                    command.Parameters.AddWithValue("@MaCa", TextBMaCa.Text);
                    command.Parameters.AddWithValue("@NgayTha", Convert.ToDateTime(TxbNgayTha.Text));
                    command.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(txbSoLuong.Text));
                    command.ExecuteNonQuery();

                    MessageBox.Show("Thêm thành công!");
                    LoadDotThaCaData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi thêm đợt thả cá ");
                }
            }
        }

        private void btnDelete_T8_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM DotThaCa WHERE MaDotThaCa = @MaDotThaCa";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaDotThaCa", txbMaDotThaCa.Text);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Xóa thành công!");
                    LoadDotThaCaData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi xóa đợt thả cá ");
                }
            }
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void DGVLichSuChoAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem người dùng có click vào dòng hợp lệ không
            {
                DataGridViewRow row = DGVLichSuChoAn.Rows[e.RowIndex];
                txbMaChoAn.Text = row.Cells["MaChoAn"].Value.ToString();
                tboxMaHoCa.Text = row.Cells["MaHoCa"].Value.ToString();
                textBMaDotThaCa.Text = row.Cells["MaDotThaCa"].Value.ToString();
                textBMaThucAn.Text = row.Cells["MaThucAn"].Value.ToString();
                txbNgayChoAn.Text = Convert.ToDateTime(row.Cells["NgayChoAn"].Value).ToString("yyyy-MM-dd"); // Format ngày
                txbLuongThucAn.Text = row.Cells["LuongThucAn"].Value.ToString();
            }
        }
        private bool ValidateChoAnInput()
        {
            if (string.IsNullOrWhiteSpace(txbMaChoAn.Text) ||
                string.IsNullOrWhiteSpace(tboxMaHoCa.Text) ||
                string.IsNullOrWhiteSpace(textBMaDotThaCa.Text) ||
                string.IsNullOrWhiteSpace(textBMaThucAn.Text) ||
                string.IsNullOrWhiteSpace(txbNgayChoAn.Text) ||
                string.IsNullOrWhiteSpace(txbLuongThucAn.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return false;
            }

            if (!DateTime.TryParse(txbNgayChoAn.Text, out _))
            {
                MessageBox.Show("Ngày cho ăn không hợp lệ!");
                return false;
            }

            if (!double.TryParse(txbLuongThucAn.Text, out double luong) || luong <= 0)
            {
                MessageBox.Show("Lượng thức ăn phải là số dương!");
                return false;
            }

            return true;
        }
        private void btnAdd_T9_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO ChoAn (MaChoAn, MaHoCa, MaDotThaCa, MaThucAn, NgayChoAn, LuongThucAn) " +
                                   "VALUES (@MaChoAn, @MaHoCa, @MaDotThaCa, @MaThucAn, @NgayChoAn, @LuongThucAn)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaChoAn", txbMaChoAn.Text);
                    command.Parameters.AddWithValue("@MaHoCa", tboxMaHoCa.Text);
                    command.Parameters.AddWithValue("@MaDotThaCa", textBMaDotThaCa.Text);
                    command.Parameters.AddWithValue("@MaThucAn", textBMaThucAn.Text);
                    command.Parameters.AddWithValue("@NgayChoAn", Convert.ToDateTime(txbNgayChoAn.Text));
                    command.Parameters.AddWithValue("@LuongThucAn", Convert.ToDouble(txbLuongThucAn.Text));
                    command.ExecuteNonQuery();

                    MessageBox.Show("Thêm thành công!");
                    LoadChoAnData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi thêm lịch sử cho ăn ");
                }
            }
            if (!ValidateChoAnInput()) return;
        }

        private void btnEdit_T9_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE ChoAn SET MaHoCa = @MaHoCa, MaDotThaCa = @MaDotThaCa, MaThucAn = @MaThucAn, NgayChoAn = @NgayChoAn, LuongThucAn = @LuongThucAn " +
                                   "WHERE MaChoAn = @MaChoAn";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaChoAn", txbMaChoAn.Text);
                    command.Parameters.AddWithValue("@MaHoCa", tboxMaHoCa.Text);
                    command.Parameters.AddWithValue("@MaDotThaCa", textBMaDotThaCa.Text);
                    command.Parameters.AddWithValue("@MaThucAn", textBMaThucAn.Text);
                    command.Parameters.AddWithValue("@NgayChoAn", Convert.ToDateTime(txbNgayChoAn.Text));
                    command.Parameters.AddWithValue("@LuongThucAn", Convert.ToDouble(txbLuongThucAn.Text));
                    command.ExecuteNonQuery();

                    MessageBox.Show("Sửa thành công!");
                    LoadChoAnData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi sửa lịch sử cho ăn ");
                }
            }
            if (!ValidateChoAnInput()) return;
        }

        private void btnDelete_T9_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM ChoAn WHERE MaChoAn = @MaChoAn";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaChoAn", txbMaChoAn.Text);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Xóa thành công!");
                    LoadChoAnData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi xóa lịch sử cho ăn " );
                }
            }
        }

        private void btnAdd_T10_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO SuDungThuoc (MaSuDungThuoc, MaHoCa, MaDotThaCa, MaThuoc, NgaySuDung, LieuLuong) " +
                                   "VALUES (@MaSuDungThuoc, @MaHoCa, @MaDotThaCa, @MaThuoc, @NgaySuDung, @LieuLuong)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaSuDungThuoc", txbMaSuDungThuoc.Text);
                    command.Parameters.AddWithValue("@MaHoCa", txboxMaHoCa.Text);
                    command.Parameters.AddWithValue("@MaDotThaCa", txboxMaDotThaCa.Text);
                    command.Parameters.AddWithValue("@MaThuoc", txboxMaThuoc.Text);
                    command.Parameters.AddWithValue("@NgaySuDung", DateTime.Parse(txbNgaySuDung.Text));
                    command.Parameters.AddWithValue("@LieuLuong", float.Parse(txbLieuLuong.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công!");
                    LoadSuDungThuocData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi thêm " );
                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE SuDungThuoc " +
                                   "SET MaHoCa = @MaHoCa, MaDotThaCa = @MaDotThaCa, MaThuoc = @MaThuoc, " +
                                   "NgaySuDung = @NgaySuDung, LieuLuong = @LieuLuong " +
                                   "WHERE MaSuDungThuoc = @MaSuDungThuoc";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaSuDungThuoc", txbMaSuDungThuoc.Text);
                    command.Parameters.AddWithValue("@MaHoCa", txboxMaHoCa.Text);
                    command.Parameters.AddWithValue("@MaDotThaCa", txboxMaDotThaCa.Text);
                    command.Parameters.AddWithValue("@MaThuoc", txboxMaThuoc.Text);
                    command.Parameters.AddWithValue("@NgaySuDung", DateTime.Parse(txbNgaySuDung.Text));
                    command.Parameters.AddWithValue("@LieuLuong", float.Parse(txbLieuLuong.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadSuDungThuocData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi sửa ");
                }
            }
        }

        private void btnDelete_T10_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM SuDungThuoc WHERE MaSuDungThuoc = @MaSuDungThuoc";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaSuDungThuoc", txbMaSuDungThuoc.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    LoadSuDungThuocData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi xóa ");
                }
            }
        }

        private void DGVLichSuDungThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_T11_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO TheoDoiSucKhoe (MaTheoDoiSucKhoe, MaHoCa, MaDotThaCa, MaBenh, NgayGhiNhan, TinhTrangSucKhoe, GhiChu) " +
                                   "VALUES (@MaTheoDoiSucKhoe, @MaHoCa, @MaDotThaCa, @MaBenh, @NgayGhiNhan, @TinhTrangSucKhoe, @GhiChu)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTheoDoiSucKhoe", txbTheoDoiSucKhoe.Text);
                    command.Parameters.AddWithValue("@MaHoCa", texBoxMaHoCa.Text);
                    command.Parameters.AddWithValue("@MaDotThaCa", texBoxMaDotThaCa.Text);
                    command.Parameters.AddWithValue("@MaBenh", textbxMaBenh.Text);
                    command.Parameters.AddWithValue("@NgayGhiNhan", DateTime.Parse(txbNgayGhiNhan.Text));
                    command.Parameters.AddWithValue("@TinhTrangSucKhoe", txbTinhTrangSucKhoe.Text);
                    command.Parameters.AddWithValue("@GhiChu", txbGhiChu.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công!");
                    LoadTheoDoiSucKhoeData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi thêm ");
                }
            }
        }

        private void btnEdit_T11_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE TheoDoiSucKhoe " +
                                   "SET MaHoCa = @MaHoCa, MaDotThaCa = @MaDotThaCa, MaBenh = @MaBenh, " +
                                   "NgayGhiNhan = @NgayGhiNhan, TinhTrangSucKhoe = @TinhTrangSucKhoe, GhiChu = @GhiChu " +
                                   "WHERE MaTheoDoiSucKhoe = @MaTheoDoiSucKhoe";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTheoDoiSucKhoe", txbTheoDoiSucKhoe.Text);
                    command.Parameters.AddWithValue("@MaHoCa", texBoxMaHoCa.Text);
                    command.Parameters.AddWithValue("@MaDotThaCa", texBoxMaDotThaCa.Text);
                    command.Parameters.AddWithValue("@MaBenh", textbxMaBenh.Text);
                    command.Parameters.AddWithValue("@NgayGhiNhan", DateTime.Parse(txbNgayGhiNhan.Text));
                    command.Parameters.AddWithValue("@TinhTrangSucKhoe", txbTinhTrangSucKhoe.Text);
                    command.Parameters.AddWithValue("@GhiChu", txbGhiChu.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadTheoDoiSucKhoeData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi sửa ");
                }
            }
        }

        private void btnDelete_T11_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM TheoDoiSucKhoe WHERE MaTheoDoiSucKhoe = @MaTheoDoiSucKhoe";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTheoDoiSucKhoe", txbTheoDoiSucKhoe.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    LoadTheoDoiSucKhoeData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi xóa ");
                }
            }
        }

        private void DGVTheoDoiSucKhoe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVTheoDoiSucKhoe.Rows[e.RowIndex];
                txbTheoDoiSucKhoe.Text = row.Cells["MaTheoDoiSucKhoe"].Value.ToString();
                texBoxMaHoCa.Text = row.Cells["MaHoCa"].Value.ToString();
                texBoxMaDotThaCa.Text = row.Cells["MaDotThaCa"].Value.ToString();
                textbxMaBenh.Text = row.Cells["MaBenh"].Value.ToString();
                txbNgayGhiNhan.Text = row.Cells["NgayGhiNhan"].Value.ToString();
                txbTinhTrangSucKhoe.Text = row.Cells["TinhTrangSucKhoe"].Value.ToString();
                txbGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }

        private void btnAdd_T12_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO TheoDoiMoiTruong (MaTheoDoiMoiTruong, MaHoCa, NgayGhiNhan, NhietDo, DoPH, NongDoOxy) " +
                                   "VALUES (@MaTheoDoiMoiTruong, @MaHoCa, @NgayGhiNhan, @NhietDo, @DoPH, @NongDoOxy)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTheoDoiMoiTruong", txbMaTheoDoiMoiTruong.Text);
                    command.Parameters.AddWithValue("@MaHoCa", tbHoCa.Text);
                    command.Parameters.AddWithValue("@NgayGhiNhan", DateTime.Parse(textBNgayGhiNhan.Text));
                    command.Parameters.AddWithValue("@NhietDo", float.Parse(txbNhietDo.Text));
                    command.Parameters.AddWithValue("@DoPH", float.Parse(txbDoPH.Text));
                    command.Parameters.AddWithValue("@NongDoOxy", float.Parse(txbNongDoOxy.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công!");
                    LoadTheoDoiMoiTruongData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi thêm ");
                }
            }
        }

        private void btnEdit_T12_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE TheoDoiMoiTruong " +
                                   "SET MaHoCa = @MaHoCa, NgayGhiNhan = @NgayGhiNhan, NhietDo = @NhietDo, " +
                                   "DoPH = @DoPH, NongDoOxy = @NongDoOxy " +
                                   "WHERE MaTheoDoiMoiTruong = @MaTheoDoiMoiTruong";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTheoDoiMoiTruong", txbMaTheoDoiMoiTruong.Text);
                    command.Parameters.AddWithValue("@MaHoCa", tbHoCa.Text);
                    command.Parameters.AddWithValue("@NgayGhiNhan", DateTime.Parse(textBNgayGhiNhan.Text));
                    command.Parameters.AddWithValue("@NhietDo", float.Parse(txbNhietDo.Text));
                    command.Parameters.AddWithValue("@DoPH", float.Parse(txbDoPH.Text));
                    command.Parameters.AddWithValue("@NongDoOxy", float.Parse(txbNongDoOxy.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadTheoDoiMoiTruongData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi sửa ");
                }
            }
        }

        private void btnDelete_T12_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM TheoDoiMoiTruong WHERE MaTheoDoiMoiTruong = @MaTheoDoiMoiTruong";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTheoDoiMoiTruong", txbMaTheoDoiMoiTruong.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    LoadTheoDoiMoiTruongData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi xóa ");
                }
            }
        }

        private void DGVTheoDoiMoiTruong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVTheoDoiMoiTruong.Rows[e.RowIndex];
                txbMaTheoDoiMoiTruong.Text = row.Cells["MaTheoDoiMoiTruong"].Value.ToString();
                tbHoCa.Text = row.Cells["MaHoCa"].Value.ToString();
                textBNgayGhiNhan.Text = row.Cells["NgayGhiNhan"].Value.ToString();
                txbNhietDo.Text = row.Cells["NhietDo"].Value.ToString();
                txbDoPH.Text = row.Cells["DoPH"].Value.ToString();
                txbNongDoOxy.Text = row.Cells["NongDoOxy"].Value.ToString();
            }
        }

        private void btnAdd_T13_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Benh (MaBenh, TenBenh, TrieuChung) VALUES (@MaBenh, @TenBenh, @TrieuChung)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaBenh", txbMaBenh.Text);
                    command.Parameters.AddWithValue("@TenBenh", txbTenBenh.Text);
                    command.Parameters.AddWithValue("@TrieuChung", txbTrieuChung.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm bệnh thành công!");
                    LoadBenhData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi thêm: ");
                }
            }
        }

        private void btnEdit_T13_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Benh SET TenBenh = @TenBenh, TrieuChung = @TrieuChung WHERE MaBenh = @MaBenh";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaBenh", txbMaBenh.Text);
                    command.Parameters.AddWithValue("@TenBenh", txbTenBenh.Text);
                    command.Parameters.AddWithValue("@TrieuChung", txbTrieuChung.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Sửa thông tin bệnh thành công!");
                    LoadBenhData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi sửa ");
                }
            }
        }

        private void btnDelete_T13_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Benh WHERE MaBenh = @MaBenh";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaBenh", txbMaBenh.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa bệnh thành công!");
                    LoadBenhData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi xóa ");
                }
            }
        }

        private void DGVTrieuchung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVBenh.Rows[e.RowIndex];
                txbMaBenh.Text = row.Cells["MaBenh"].Value.ToString();
                txbTenBenh.Text = row.Cells["TenBenh"].Value.ToString();
                txbTrieuChung.Text = row.Cells["TrieuChung"].Value.ToString();
            }
        }
        private string GenerateNewMaHoaDon()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Lấy mã hóa đơn lớn nhất hiện tại
                    string query = "SELECT TOP 1 MaHoaDon FROM HoaDon ORDER BY MaHoaDon DESC";
                    SqlCommand command = new SqlCommand(query, connection);
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string lastMaHoaDon = result.ToString();
                        // Tách phần số từ mã hóa đơn (VD: HD001 → 001)
                        int numberPart = int.Parse(lastMaHoaDon.Substring(2));
                        // Tăng số thứ tự
                        numberPart++;
                        // Tạo mã hóa đơn mới (VD: 002 → HD002)
                        return "HD" + numberPart.ToString("D3");
                    }
                    else
                    {
                        // Trường hợp chưa có mã hóa đơn nào
                        return "HD001";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi tạo mã hóa đơn mới ");
                    return null;
                }
            }
        }
        private void btnAdd_T14_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Tạo mã hóa đơn mới
                    string newMaHoaDon = GenerateNewMaHoaDon();
                    if (newMaHoaDon == null) return;

                    string query = "INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayBan) " +
                                   "VALUES (@MaHoaDon, @MaKhachHang, @MaNhanVien, @NgayBan)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHoaDon", newMaHoaDon);
                    command.Parameters.AddWithValue("@MaKhachHang", textBMaKhachHang.Text);
                    command.Parameters.AddWithValue("@MaNhanVien", textBMaNhanVien.Text);
                    command.Parameters.AddWithValue("@NgayBan", DateTime.Parse(txbNgayBan.Text));
                    command.ExecuteNonQuery();

                    MessageBox.Show("Thêm hóa đơn thành công!");
                    LoadHoaDonData();

                    // Gán mã hóa đơn mới vào TextBox (tùy chọn)
                    txbMaHoaDon.Text = newMaHoaDon;
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi thêm hóa đơn ");
                }
            }

        }

        private void btnEdit_T14_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE HoaDon SET MaKhachHang = @MaKhachHang, MaNhanVien = @MaNhanVien, NgayBan = @NgayBan " +
                                   "WHERE MaHoaDon = @MaHoaDon";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHoaDon", txbMaHoaDon.Text);
                    command.Parameters.AddWithValue("@MaKhachHang", textBMaKhachHang.Text);
                    command.Parameters.AddWithValue("@MaNhanVien", textBMaNhanVien.Text);
                    command.Parameters.AddWithValue("@NgayBan", DateTime.Parse(txbNgayBan.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật hóa đơn thành công!");
                    LoadHoaDonData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi cập nhật hóa đơn ");
                }
            }
           
        }

        private void btnDelete_T14_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHoaDon", txbMaHoaDon.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa hóa đơn thành công!");
                    LoadHoaDonData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi xóa hóa đơn ");
                }
            }
        }

        private void DGVHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVHoaDon.Rows[e.RowIndex];
                txbMaHoaDon.Text = row.Cells["MaHoaDon"].Value.ToString();
                textBMaKhachHang.Text = row.Cells["MaKhachHang"].Value.ToString();
                textBMaNhanVien.Text = row.Cells["MaNhanVien"].Value.ToString();
                txbNgayBan.Text = row.Cells["NgayBan"].Value.ToString();
            }
        }

        private void btnAdd_T15_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO ChiTietHoaDon (MaChiTietHoaDon, MaHoaDon, MaCa, SoLuongCa, DonGia, ThanhTien) " +
                                   "VALUES (@MaChiTietHoaDon, @MaHoaDon, @MaCa, @SoLuongCa, @DonGia, @ThanhTien)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaChiTietHoaDon", txbMaChiTietHoaDon.Text);
                    command.Parameters.AddWithValue("@MaHoaDon", textBoxMaHoaDon.Text);
                    command.Parameters.AddWithValue("@MaCa", textBoxMaCa.Text);
                    command.Parameters.AddWithValue("@SoLuongCa", Convert.ToInt32(txbSoLuongCa.Text));
                    command.Parameters.AddWithValue("@DonGia", Convert.ToDouble(txbDonGia.Text));
                    command.Parameters.AddWithValue("@ThanhTien", Convert.ToDouble(txbThanhTien.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm chi tiết hóa đơn thành công!");
                    LoadChiTietHoaDonData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi thêm chi tiết hóa đơn " );
                }
            }
        }

        private void btnEdit_T15_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE ChiTietHoaDon SET MaHoaDon = @MaHoaDon, MaCa = @MaCa, SoLuongCa = @SoLuongCa, " +
                                   "DonGia = @DonGia, ThanhTien = @ThanhTien WHERE MaChiTietHoaDon = @MaChiTietHoaDon";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaChiTietHoaDon", txbMaChiTietHoaDon.Text);
                    command.Parameters.AddWithValue("@MaHoaDon", textBoxMaHoaDon.Text);
                    command.Parameters.AddWithValue("@MaCa", textBoxMaCa.Text);
                    command.Parameters.AddWithValue("@SoLuongCa", Convert.ToInt32(txbSoLuongCa.Text));
                    command.Parameters.AddWithValue("@DonGia", Convert.ToDouble(txbDonGia.Text));
                    command.Parameters.AddWithValue("@ThanhTien", Convert.ToDouble(txbThanhTien.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật chi tiết hóa đơn thành công!");
                    LoadChiTietHoaDonData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi cập nhật chi tiết hóa đơn ");
                }
            }
        }

        private void btnDelete_T15_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM ChiTietHoaDon WHERE MaChiTietHoaDon = @MaChiTietHoaDon";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaChiTietHoaDon", txbMaChiTietHoaDon.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa chi tiết hóa đơn thành công!");
                    LoadChiTietHoaDonData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi xóa chi tiết hóa đơn " );
                }
            }
        }

        private void DGVChiTietHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVChiTietHoaDon.Rows[e.RowIndex];
                txbMaChiTietHoaDon.Text = row.Cells["MaChiTietHoaDon"].Value.ToString();
                textBoxMaHoaDon.Text = row.Cells["MaHoaDon"].Value.ToString();
                textBoxMaCa.Text = row.Cells["MaCa"].Value.ToString();
                txbSoLuongCa.Text = row.Cells["SoLuongCa"].Value.ToString();
                txbDonGia.Text = row.Cells["DonGia"].Value.ToString();
                txbThanhTien.Text = row.Cells["ThanhTien"].Value.ToString();
            }
        }
        private void CalculateThanhTien()
        {
            if (int.TryParse(txbSoLuongCa.Text, out int soLuongCa) &&
                double.TryParse(txbDonGia.Text, out double donGia))
            {
                double thanhTien = soLuongCa * donGia;
                txbThanhTien.Text = thanhTien.ToString();
            }
        }

        private void txbSoLuongCa_TextChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }

        private void txbDonGia_TextChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }

        private void txbMaHoaDon_TextChanged(object sender, EventArgs e)
        {
            txbMaHoaDon.ReadOnly = true;

        }

        private void label72_Click(object sender, EventArgs e)
        {

        }
        public void TaoBaoCao(DateTime ngayBaoCao)
        {
            string connectionString = "your_connection_string";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("TaoBaoCao", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Thêm tham số cho thủ tục
                    cmd.Parameters.AddWithValue("@NgayBaoCao", ngayBaoCao);

                    // Thực thi thủ tục
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Báo cáo đã được tạo thành công!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
        }
        private double TinhTongThu(SqlConnection connection, DateTime ngayBaoCao)
        {
            string query = @"
        SELECT ISNULL(SUM(SoLuongCa * DonGia), 0) AS TongThu
        FROM ChiTietHoaDon
        INNER JOIN HoaDon ON ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon
        WHERE HoaDon.NgayBan <= @NgayBaoCao";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@NgayBaoCao", ngayBaoCao);

            return Convert.ToDouble(cmd.ExecuteScalar());
        }

        private double TinhTongChi(SqlConnection connection, DateTime ngayBaoCao)
        {
            string query = @"
        SELECT ISNULL(SUM(ChoAn.LuongThucAn * ThucAn.GiaThucAn), 0) +
               ISNULL(SUM(SuDungThuoc.LieuLuong * Thuoc.GiaThuoc), 0) AS TongChi
        FROM ChoAn
        INNER JOIN ThucAn ON ChoAn.MaThucAn = ThucAn.MaThucAn
        FULL OUTER JOIN SuDungThuoc ON ChoAn.MaDotThaCa = SuDungThuoc.MaDotThaCa
        INNER JOIN Thuoc ON SuDungThuoc.MaThuoc = Thuoc.MaThuoc
        WHERE ChoAn.NgayChoAn <= @NgayBaoCao OR SuDungThuoc.NgaySuDung <= @NgayBaoCao";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@NgayBaoCao", ngayBaoCao);

            return Convert.ToDouble(cmd.ExecuteScalar());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Tính toán tự động Tổng thu, Tổng chi, Lợi nhuận
                    DateTime ngayBaoCao = DateTime.Parse(txbNgayBaoCao.Text);
                    double tongThu = TinhTongThu(connection, ngayBaoCao);
                    double tongChi = TinhTongChi(connection, ngayBaoCao);
                    double loiNhuan = tongThu - tongChi;

                    // Tạo mã báo cáo tự động
                    string MaBaoCao = GenerateMaBaoCao();

                    // Thêm vào cơ sở dữ liệu
                    string query = "INSERT INTO BaoCao (MaBaoCao, NgayBaoCao, TongThu, TongChi, LoiNhuan) " +
                                   "VALUES (@MaBaoCao, @NgayBaoCao, @TongThu, @TongChi, @LoiNhuan)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaBaoCao", MaBaoCao);
                    command.Parameters.AddWithValue("@NgayBaoCao", ngayBaoCao);
                    command.Parameters.AddWithValue("@TongThu", tongThu);
                    command.Parameters.AddWithValue("@TongChi", tongChi);
                    command.Parameters.AddWithValue("@LoiNhuan", loiNhuan);
                    command.ExecuteNonQuery();

                    // Hiển thị trên giao diện
                    txbTongThu.Text = tongThu.ToString("N0");
                    txbTongChi.Text = tongChi.ToString("N0");
                    txbLoiNhuan.Text = loiNhuan.ToString("N0");

                    MessageBox.Show("Thêm báo cáo thành công!");
                    LoadBaoCaoData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi thêm báo cáo " );
                }
            }
        }

        private string GenerateMaBaoCao()
        {
            // Lấy mã lớn nhất hiện tại và tạo mã mới theo định dạng HD001, HD002...
            string MaBaoCao = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT MAX(CAST(SUBSTRING(MaBaoCao, 3, 3) AS INT)) FROM BaoCao";
                SqlCommand command = new SqlCommand(query, connection);
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    int newId = Convert.ToInt32(result) + 1;
                    MaBaoCao = "HD" + newId.ToString("D3");  // Ví dụ: HD001, HD002
                }
                else
                {
                    MaBaoCao = "HD001";
                }
            }
            return MaBaoCao;
        }
        private void DGVBaoCao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Chỉ xử lý khi click vào dòng hợp lệ
            {
                DataGridViewRow row = DGVBaoCao.Rows[e.RowIndex];
                txbMaBaoCao.Text = row.Cells["MaBaoCao"].Value.ToString();
                txbNgayBaoCao.Text = row.Cells["NgayBaoCao"].Value.ToString();
                txbTongThu.Text = row.Cells["TongThu"].Value.ToString();
                txbTongChi.Text = row.Cells["TongChi"].Value.ToString();
                txbLoiNhuan.Text = row.Cells["LoiNhuan"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Tính toán tự động Tổng thu, Tổng chi, Lợi nhuận
                    DateTime ngayBaoCao = DateTime.Parse(txbNgayBaoCao.Text);
                    double tongThu = TinhTongThu(connection, ngayBaoCao);
                    double tongChi = TinhTongChi(connection, ngayBaoCao);
                    double loiNhuan = tongThu - tongChi;

                    // Cập nhật cơ sở dữ liệu
                    string query = "UPDATE BaoCao SET NgayBaoCao = @NgayBaoCao, TongThu = @TongThu, " +
                                   "TongChi = @TongChi, LoiNhuan = @LoiNhuan WHERE MaBaoCao = @MaBaoCao";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaBaoCao", txbMaBaoCao.Text);
                    command.Parameters.AddWithValue("@NgayBaoCao", ngayBaoCao);
                    command.Parameters.AddWithValue("@TongThu", tongThu);
                    command.Parameters.AddWithValue("@TongChi", tongChi);
                    command.Parameters.AddWithValue("@LoiNhuan", loiNhuan);
                    command.ExecuteNonQuery();

                    // Hiển thị trên giao diện
                    txbTongThu.Text = tongThu.ToString("N0");
                    txbTongChi.Text = tongChi.ToString("N0");
                    txbLoiNhuan.Text = loiNhuan.ToString("N0");

                    MessageBox.Show("Cập nhật báo cáo thành công!");
                    LoadBaoCaoData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi khi sửa báo cáo ");
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM BaoCao WHERE MaBaoCao = @MaBaoCao";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaBaoCao", txbMaBaoCao.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa báo cáo thành công!");
                    LoadBaoCaoData();
                }
                catch (Exception )
                {
                    MessageBox.Show("Lỗi khi xóa báo cáo " );
                }
            }
        }

        private void DGVLichSuDungThuoc_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào một cell hợp lệ (không phải tiêu đề cột)
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin từ các ô trong dòng được chọn
                DataGridViewRow row = DGVLichSuDungThuoc.Rows[e.RowIndex];

                // Cập nhật các textbox với dữ liệu từ dòng được chọn
                txbMaSuDungThuoc.Text = row.Cells["MaSuDungThuoc"].Value.ToString();
                txboxMaHoCa.Text = row.Cells["MaHoCa"].Value.ToString();
                txboxMaDotThaCa.Text = row.Cells["MaDotThaCa"].Value.ToString();
                txboxMaThuoc.Text = row.Cells["MaThuoc"].Value.ToString();
                txbNgaySuDung.Text = Convert.ToDateTime(row.Cells["NgaySuDung"].Value).ToString("yyyy-MM-dd");
                txbLieuLuong.Text = row.Cells["LieuLuong"].Value.ToString();
            }
        }

        private void txbTongThu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbTongChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbLoiNhuan_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel45_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txbSoLuongCa_TextChanged_1(object sender, EventArgs e)
        {
            CalculateChiTietThanhTien();
        }

        private void txbDonGia_TextChanged_1(object sender, EventArgs e)
        {
            CalculateChiTietThanhTien();
        }
        private void CalculateChiTietThanhTien()
        {
            if (int.TryParse(txbSoLuongCa.Text, out int soLuongCa) &&
                double.TryParse(txbDonGia.Text, out double donGia))
            {
                double thanhTien = soLuongCa * donGia;
                txbThanhTien.Text = thanhTien.ToString("F2"); // Định dạng 2 chữ số thập phân
            }
            else
            {
                txbThanhTien.Text = "0";
            }
        }

    }
}
    

