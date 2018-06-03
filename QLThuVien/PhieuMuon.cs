using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien
{
    class PhieuMuon
    {
        public String MaPhieuMuon { get; set; }
        public String MaDocGia { get; set; }
        public String MaSach { get; set; }
        public DateTime NgayMuon { get; set; }
        public string TrangThai { get; set; }

        public PhieuMuon()
        {
        }

        public PhieuMuon(string maPhieuMuon, string maDocGia, string maSach, DateTime ngayMuon, string trangthai)
        {
            MaPhieuMuon = maPhieuMuon;
            MaDocGia = maDocGia;
            MaSach = maSach;
            NgayMuon = ngayMuon;
            TrangThai = trangthai;
        }

        public string genKey()
        {
            int second = DateTime.Now.Second;
            int minute = DateTime.Now.Minute;
            int hour = DateTime.Now.Hour;
            return "PM00" + hour + minute + second;
        }
    }
}
