using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien
{
    class Program
    {
        

        private void DanhSachSach(List<Sach> dsSach, Dictionary<string, int> sl, List<OChua> dsOChua)
        {
            OChua chua = new OChua();
            Dictionary<string, int> dsCoTheChoMuon = new Dictionary<string, int>();
            for (int i = 0; i < dsOChua.Count; i++)
            {
                if (dsCoTheChoMuon.ContainsKey(dsOChua[i].MaSach))
                {
                    dsCoTheChoMuon[dsOChua[i].MaSach] += dsOChua[i].SoLuong;
                }
                else
                {
                    dsCoTheChoMuon.Add(dsOChua[i].MaSach, dsOChua[i].SoLuong);
                }
            }
            Console.WriteLine("============DS Sach=====================");
            for (int i = 0; i < dsSach.Count; i++)
            {
                    string output = "\nMa sach " + dsSach[i].MaSach + "\nTen sach " + dsSach[i].TenSach + "\nNha xuat ban " + dsSach[i].NhaXuatBan +
                    "\nNam xuat ban :" + dsSach[i].NamXuatBan + "\nSo luong : " + sl[dsSach[i].MaSach] + "\nSL sach co the cho muon :" + dsCoTheChoMuon[dsOChua[i].MaSach];
                    Console.WriteLine(output);
            }
        }
        private void DanhSachOChua(List<OChua> dsOChua)
        {
            Console.WriteLine("============DS O Chua=====================");


            for (int i = 0; i < dsOChua.Count; i++)
            {
                Console.WriteLine("\nMa " + dsOChua[i].MaO + "\nMa sach : " + dsOChua[i].MaSach + "\nSo luong " + dsOChua[i].SoLuong);
            }
        }
        private void DSCoTheChoMuon(List<OChua> dsOChua)
        {
            Dictionary<string, int> dsCoTheChoMuon = new Dictionary<string, int>();
            for(int i=0;i<dsOChua.Count;i++)
            {
                if(dsOChua[i].SoLuong !=0)
                {
                    Console.WriteLine("\nMa sach : " + dsOChua[i].MaSach + "\tSo luong :" + dsOChua[i].SoLuong);
                    //dsCoTheChoMuon.Add(dsOChua[i].MaSach, dsOChua[i].SoLuong);
                }
            }
        }
        private void TimKiem(List<Sach> dsSach, Dictionary<string, int> sl, List<OChua> dsOChua,string mas)
        {

            OChua chua = new OChua();
            Dictionary<string, int> dsCoTheChoMuon = new Dictionary<string, int>();
            for (int i = 0; i < dsOChua.Count; i++)
            {
                if (dsCoTheChoMuon.ContainsKey(dsOChua[i].MaSach))
                {
                    dsCoTheChoMuon[dsOChua[i].MaSach] += dsOChua[i].SoLuong;
                }
                else
                {
                    dsCoTheChoMuon.Add(dsOChua[i].MaSach, dsOChua[i].SoLuong);
                }
            }
            Console.WriteLine("============Thong tin sach=====================");
            for (int i = 0; i < dsSach.Count; i++)
            {
                if(dsSach[i].MaSach == mas)
                {
                    int sldachomuon = sl[dsSach[i].MaSach] - dsCoTheChoMuon[dsOChua[i].MaSach];
                    string output = "\nMa sach " + dsSach[i].MaSach + "\nTen sach " + dsSach[i].TenSach + "\nNha xuat ban " + dsSach[i].NhaXuatBan +
                    "\nNam xuat ban :" + dsSach[i].NamXuatBan
                    + "\nSo luong hien co :" + dsCoTheChoMuon[dsOChua[i].MaSach]
                    + "\nTong so luong : " + sl[dsSach[i].MaSach] 
                    + "\nSo sach da cho muon : " + sldachomuon;
                    Console.WriteLine(output);
                }
            }
        }
        public void showFoot()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
        }
        static void Main(string[] args)
        {
            Sach sach = new Sach();
            OChua ochua = new OChua();
            PhieuMuon phieuMuon = new PhieuMuon(); 
            Program program = new Program();
            int n = 0;
            List<Sach> dsSach = new List<Sach>();
            List<OChua> dsOChua = new List<OChua>();
            List<PhieuMuon> dsPhieuMuon = new List<PhieuMuon>();
            Dictionary<string, int> sl = new Dictionary<string, int>();


            sach.showLayout();
            Console.WriteLine("Nhap so o chua :");
            n = int.Parse(Console.ReadLine());


            while (true)
            {
                sach.showLayout();
                int chon = 0;
                String luachon = "\nNhap lua chon :" +
                            "\n1.Nhap sach " +
                            "\n2.Lap phieu muon " +
                            "\n3.Tim kiem theo ma sach " +
                            "\n4.In danh sach sach ";
                Console.WriteLine(luachon);
                program.showFoot();
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        {
                            NhapSach(dsSach,sl,dsOChua,n);
                            break;
                        }
                    case 2:
                        {
                            TaoPhieuMuon(dsOChua,dsPhieuMuon,sl);
                            break;
                        }
                    case 3:
                        {
                            sach.showLayout();
                            Console.WriteLine("Nhap ma sach :");
                            string ms = Console.ReadLine();
                            program.TimKiem(dsSach, sl, dsOChua, ms);
                            break;
                        }
                    case 4:
                        {
                            sach.showLayout();
                            program.DanhSachSach(dsSach,sl,dsOChua);
                            program.DanhSachOChua(dsOChua);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 0:
                        break;
                }
            }
            Console.ReadLine();
        }

        private static void TaoPhieuMuon(List<OChua> dsOChua, List<PhieuMuon> dsPhieuMuon, Dictionary<string,int> sl)
        {
            OChua ochua = new OChua();
            ochua.showLayout();
            PhieuMuon phieuMuon = new PhieuMuon();
            Program program = new Program();
            Console.WriteLine("Ma doc gia");
            string madocgia = Console.ReadLine();

            program.DSCoTheChoMuon(dsOChua);
            Console.WriteLine("Ma sach");
            string maS = Console.ReadLine();
            Console.WriteLine("Lay sach " + maS + " tu o chua :");
            for (int i = 0; i < dsOChua.Count; i++)
            {
                if (dsOChua[i].MaSach == maS)
                {
                    Console.WriteLine(dsOChua[i].MaO + "\n");
                }
            }
            string maOChua = Console.ReadLine();
            //lay sach tu o chua;
            ochua.LaySachTuO(dsOChua, maOChua, sl);

            DateTime ngaymuon = DateTime.Now;

            dsPhieuMuon.Add(new PhieuMuon(phieuMuon.genKey(), madocgia, maS, ngaymuon, " da cho muon"));
            Console.Clear();
            throw new NotImplementedException();
        }

        private static void NhapSach(List<Sach> dsSach, Dictionary<string,int> sl, List<OChua> dsOChua, int n)
        {
            
            int soluong = 0;
            OChua ochua = new OChua();
            Sach sach1 = new Sach();
            sach1.showLayout();
            if (soluong == 0) soluong++;
            Console.WriteLine("Kiem tra ten sach :");
            string tensach = Console.ReadLine();
            if (sach1.TimTenSach(dsSach, tensach) != null)
            {
                sach1 = sach1.getSachbyMa(dsSach, sach1.getMaSachbyTen(dsSach, tensach));
                Console.WriteLine("Sach da ton tai! Ma sach: " + sach1.MaSach);
                sl[sach1.getMaSachbyTen(dsSach, tensach)]++;
            }
            else
            {
                //khong thay ten sach => sinh ma cho sach
                sach1.MaSach = sach1.genKey();
                Console.WriteLine("Nhap ten sach : ");
                sach1.TenSach = Console.ReadLine();
                Console.WriteLine("Nhap ten nha xuat ban : ");
                sach1.NhaXuatBan = Console.ReadLine();
                Console.WriteLine("Nhap nam xuat ban : ");
                sach1.NamXuatBan = int.Parse(Console.ReadLine());
                dsSach.Add(sach1);
                sl.Add(sach1.MaSach, 1);
            }
            ochua.XepSach(dsOChua, sach1, n);

            Console.Clear();
            throw new NotImplementedException();
        }
    }
}
