using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien
{
    class DocGia
    {
        private String MaDocGia { get; set; }
        private String HoTen { get; set; }
        private DateTime NgaySinh { get; set; }
        private String DiaChi { get; set; }
        private String NgheNghiep { get; set; }

        public DocGia()
        {
        }

        public DocGia(string maDocGia, string hoTen, DateTime ngaySinh, string diaChi, string ngheNghiep)
        {
            MaDocGia = maDocGia;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            NgheNghiep = ngheNghiep;
        }
    }
}
