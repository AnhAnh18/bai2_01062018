using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien
{
    class Sach
    {
        public String MaSach { get; set; }
        public String TenSach { get; set; }
        public String NhaXuatBan { get; set; }
        public int NamXuatBan { get; set; }
        public Sach()
        {
        }

        public Sach(string maSach, string tenSach, string nhaXuatBan, int namXuatBan)
        {
            MaSach = maSach;
            TenSach = tenSach;
            NhaXuatBan = nhaXuatBan;
            NamXuatBan = namXuatBan;
        }

        

        public void TimKiem(List<Sach> dsSach,string maSach)
        {
            for(int i=0;i<dsSach.Count;i++)
            {
                if(dsSach[i].MaSach == maSach)
                {
                    String luachon = "Nhap lua chon :" +
                        "\n1.So sach con theo ma " + maSach + " :" +
                        "\n2.So sach da cho muon theo ma " + maSach + " :" +
                        "\n3.Tong so sach theo ma " + maSach + " : " +
                        "\n4.Vi tri o theo ma " + maSach + " :";
                    Console.WriteLine(luachon);
                    int chon = int.Parse(Console.ReadLine());
                    switch(chon)
                    {
                        case 1:
                            {

                                break;
                            }
                    }

                }
                else
                {
                    Console.WriteLine("Khong tim thay ma sach");
                }
            }
        }
        public string TimTenSach(List<Sach> dsSach, string tenSach)
        {
            for(int i=0;i<dsSach.Count;i++)
            {
                if (dsSach[i].TenSach == tenSach)
                {
                    return dsSach[i].TenSach;
                }
            }
            return null;
        }
        public string getMaSachbyTen(List<Sach> dsSach, string tenSach)
        {

            for (int i = 0; i < dsSach.Count; i++)
            {
                if (dsSach[i].TenSach == tenSach)
                {
                    return dsSach[i].MaSach;
                }
            }
            return null;
        }

        public Sach getSachbyMa(List<Sach> lstSach, String Ma)
        {
            for (int i = 0; i < lstSach.Count; i++)
            {
                if (lstSach[i].MaSach == Ma) return lstSach[i];
            }
            return null;
        }
        public Dictionary<String, int> getSLMoiSach(List<Sach> lstSach)
        {
            Dictionary<String, int> dic = new Dictionary<String, int>();
            if (lstSach != null)
            {
                dic.Add(lstSach[0].MaSach, 1);
                for (int i = 1; i < lstSach.Count; i++)
                {
                    if (lstSach.Count == 1) continue;
                    if (dic.ContainsKey(lstSach[i].MaSach))
                    {
                        dic[lstSach[i].MaSach] += 1;
                    }
                    else
                    {
                        dic.Add(lstSach[i].MaSach, 1);
                    }
                }
            }
            return dic;
        }

        public string genKey()
        {
            int second = DateTime.Now.Second;
            int minute = DateTime.Now.Minute;
            int hour = DateTime.Now.Hour;
            return "S00" + hour + minute + second;
        }
    }
}
