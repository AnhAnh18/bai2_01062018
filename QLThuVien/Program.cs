using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien
{
    class Program
    {
        

        private void DanhSachSach(List<Sach> dsSach, Dictionary<string, int> sl)
        {
            Console.WriteLine("============DS Sach=====================");
            for (int i = 0; i < dsSach.Count; i++)
            {
                string output = "\nMa sach " + dsSach[i].MaSach + "\nTen sach " + dsSach[i].TenSach + "\nNha xuat ban " + dsSach[i].NhaXuatBan +
                    "\nNam xuat ban :" + dsSach[i].NamXuatBan + "\nSo luong : " + sl[dsSach[i].MaSach];
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
            

            //dsSach.Add(new Sach("S001", "Ten sach 1", "Nha xuat ban 1", 2000));
            //dsSach.Add(new Sach("S002", "Ten sach 2", "Nha xuat ban 1", 2000));
            //dsSach.Add(new Sach("S003", "Ten sach 3", "Nha xuat ban 1", 2000));
            ////dsSach.Add(new Sach("S004", "Ten sach 5", "Nha xuat ban 1", 2000));
            ////dsSach.Add(new Sach("S005", "Ten sach 6", "Nha xuat ban 1", 2000));
            //sl.Add("S001", 1);
            //sl.Add("S002", 3);
            //sl.Add("S003", 5);
            //dsOChua.Add(new OChua("OC001", "S001", sl["S001"]));
            //dsOChua.Add(new OChua("OC002", "S002", sl["S002"]));
            //dsOChua.Add(new OChua("OC003", "S003", sl["S003"]));
            //dsOChua.Add(new OChua("OC004", "S004", 3));

            
            string masach = null;

            int soluong = 0;
            Console.WriteLine("Nhap so o chua :");
            n = int.Parse(Console.ReadLine());


            while (true)
            {

                int chon = 0;
                String luachon = "\nNhap lua chon :" +
                            "\n1.Nhap sach " +
                            "\n2.Lap phieu muon " +
                            "\n3.In danh sach sach ";
                Console.WriteLine(luachon);
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        {
                            Sach sach1 = new Sach();
                            if(soluong == 0) soluong++;
                            Console.WriteLine("Kiem tra ten sach :");
                            string tensach = Console.ReadLine();
                            if (sach1.TimTenSach(dsSach, tensach) != null)
                            {
                                sach1 = sach1.getSachbyMa(dsSach,sach1.getMaSachbyTen(dsSach,tensach));
                                Console.WriteLine("Sach da ton tai! Ma sach: " + sach1.MaSach);
                                sl[sach.getMaSachbyTen(dsSach, tensach)]++;
                            }
                            else
                            {
                                //khong thay ten sach => sinh ma cho sach
                                sach1.MaSach = sach.genKey();
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
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Ma doc gia");
                            string madocgia = Console.ReadLine();
                            program.DanhSachSach(dsSach, sl);
                            Console.WriteLine("Ma sach");
                            string maS = Console.ReadLine();
                            Console.WriteLine("Lay sach " + maS + " tu o chua :");
                            for (int i=0;i<dsOChua.Count;i++)
                            {
                                if(dsOChua[i].MaSach == maS)
                                {
                                    Console.WriteLine(dsOChua[i].MaO + "\n");
                                }
                            }
                            string maOChua = Console.ReadLine();
                            //lay sach tu o chua;
                            ochua.LaySachTuO(dsOChua,maOChua,sl);

                            DateTime ngaymuon = DateTime.Now;

                            dsPhieuMuon.Add(new PhieuMuon(phieuMuon.genKey(), madocgia, maS, ngaymuon," da cho muon" ));
                            break;
                        }
                    case 3:
                        {
                            program.DanhSachSach(dsSach,sl);
                            program.DanhSachOChua(dsOChua);
                            break;
                        }
                    case 0:
                        break;
                }
            }

            Console.ReadLine();


        }


    }
}
