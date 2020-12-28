using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Soal : MonoBehaviour
{
    public static Soal i;

    public Text textsoal;
    public Text PilihanA;
    public Text PilihanB;
    public Text cekJawaban;
    public Text pembahasan;
    public Toggle toggleA;
    public Toggle toggleB;
    public GameObject btnJawab;
    public GameObject btnPembahasan;
    public GameObject canvasPembahasan;
    public GameObject canvasSoal;

    public string[] Jawaban;

    public int sesi;
    public bool apakahBenar;

    // Start is called before the first frame update
    void Awake()
    {
        i = this;
        sesi = 0;
    }

    private void Update()
    {
        if(toggleA.isOn || toggleB.isOn)
        {
            btnJawab.SetActive(true);
        }
        else
        {
            btnJawab.SetActive(false);
        }
    }


    private void LevelDone()
    {
        canvasSoal.SetActive(false);
        ScoreManager.i.Save();
        LevelManager.Instance.ChangeStringMap();
        //goto scene bermain disini
        StartCoroutine(gotoBermain());

    }

    private IEnumerator gotoBermain()
    {
        GameObject.Find("Canvas").SetActive(false);
        GameObject.Find("CanvasLevelDone").GetComponent<Canvas>().enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("bermain");
    }

    private void Cek()
    {
        if (apakahBenar)
        {
             cekJawaban.text = "JAWABAN ANDA : BENAR";
        }
        else
        {
             cekJawaban.text = "JAWABAN ANDA : SALAH";
        }
    }

    private void salah()
    {
        print("salah");
        Cek();
        getPembahasan();
    }

    private void benar()
    {
        print("benar");
        Cek();
        getPembahasan();
        ScoreManager.i.ScoreAtLevel += 50;
    }

    public void getjawaban()
    {
        if(toggleA.isOn && PilihanA.text == Jawaban[sesi] || toggleB.isOn && PilihanB.text == Jawaban[sesi])
        {
            apakahBenar = true;
            if (apakahBenar)
            {
                benar();
                sesi++;
            }
        }
        else
        {
            apakahBenar = false;
            salah();
            sesi++;

        }

        getSoal();

        if (sesi == 2)
        {
            btnPembahasan.GetComponent<Button>().onClick.AddListener(delegate { LevelDone(); });
        }

    }


    public void getSoal()
    {
        if (SceneManager.GetSceneByName("level 1").isLoaded)
        {
            if (sesi == 0)
            {
                textsoal.text = "Berikut ini pernyataan yang benar mengenai virus adalah...";
                PilihanA.text = "Partikel virus mengandung DNA dan RNA";
                PilihanB.text = "Partikel virus dapat dilihat dengan mikroskop cahaya";
            }
            else if (sesi == 1)
            {
                textsoal.text = "Macam-macam virus diantaranya:\n(1) Simplexvirus\n(2) Bakteriofag\n(3) Lyssavirus\n(4) Enterovirus\nYang termasuk asam inti RNA adalah …..";
                PilihanA.text = "1 dan 2";
                PilihanB.text = "3 dan 4";
            }
        }
        else if (SceneManager.GetSceneByName("level 2").isLoaded)
        {
            if (sesi == 0)
            {
                textsoal.text = "Virus HIV sangat berbahaya karena menyerang …..";
                PilihanA.text = "System pertahanan tubuh manusia";
                PilihanB.text = "Sel darah";
            }
            else if (sesi == 1)
            {
                textsoal.text = "Virus flu burung banyak sekali tipenya, tetapa yang paling berbahaya adalah tipe ….";
                PilihanA.text = "H1N5";
                PilihanB.text = "H5N1";
            }
        }
        else if (SceneManager.GetSceneByName("level 3").isLoaded)
        {
            if (sesi == 0)
            {
                textsoal.text = "Virus bukan merupakan sel karena tidak mempunyai …..";
                PilihanA.text = "Organel";
                PilihanB.text = "Protoplasma";
            }
            else if (sesi == 1)
            {
                textsoal.text = "Berikut ini yang bukan merupakan sifat-sifat dari virus adalah ….";
                PilihanA.text = "Hanya memiliki satu macam asam nukleat (DNA atau RNA)";
                PilihanB.text = "Virus dapat aktif pada makhluk hidup yang spesifik";
            }
        }
        else if (SceneManager.GetSceneByName("level 4").isLoaded)
        {
            if (sesi == 0)
            {
                textsoal.text = "Kapsid tersusun atas subunit-subunit protein yang disebut dengan …..";
                PilihanA.text = "Nukleokapsid";
                PilihanB.text = "Kapsomer";
            }
            else if (sesi == 1)
            {
                textsoal.text = "Virus yang menyebabkan penyakit leukemia adalah …..";
                PilihanA.text = "Retrovirus";
                PilihanB.text = "Orthopoxvirus";
            }
        }
        else if (SceneManager.GetSceneByName("level 5").isLoaded)
        {
            if (sesi == 0)
            {
                textsoal.text = "Virus yang menyebabkan pecahnya sel inang disebut …..";
                PilihanA.text = "Profag";
                PilihanB.text = "Virion";
            }
            else if (sesi == 1)
            {
                textsoal.text = "Virus yang menyebabkan pertumbuhan tanaman padi terhambat sehingga tanaman menjadi kerdil adalah …..";
                PilihanA.text = "Tungro";
                PilihanB.text = "CVPD";
            }
        }
        else if (SceneManager.GetSceneByName("level 6").isLoaded)
        {
            if (sesi == 0)
            {
                textsoal.text = "Kelompok penyakit berikut ini yang disebabkan oleh virus adalah …";
                PilihanA.text = "cacar, difteri dan campak";
                PilihanB.text = "rabies, herpes dan sampar";
            }
            else if (sesi == 1)
            {
                textsoal.text = "Sel tubuh bakteri sering disebut sebagai sel yang prokariotik, sebab….";
                PilihanA.text = "inti sel tidak mempunyai selaput inti";
                PilihanB.text = "sering menimbulkan penyakit";
            }
        }
        else if (SceneManager.GetSceneByName("level 7").isLoaded)
        {
            if (sesi == 0)
            {
                textsoal.text = "Penyakit demam berdarah yang timbul di berbagai kota di Indonesia disebabkan oleh….";
                PilihanA.text = "bakteri";
                PilihanB.text = "virus";
            }
            else if (sesi == 1)
            {
                textsoal.text = "Sel eukariotik lebih tinggi tingkatannya dari sel prokariotik. Arti sel eukariotik adalah….";
                PilihanA.text = "inti sel mempunyai selaput inti";
                PilihanB.text = "sel mempunyai dinding";
            }
        }
        else if (SceneManager.GetSceneByName("level 8").isLoaded)
        {
            if (sesi == 0)
            {
                textsoal.text = "Urutan tahap daur litik yang benar adalah…";
                PilihanA.text = "Adsorpsi – penetrasi – eklifase – pembentukan virus baru – lisis";
                PilihanB.text = "Eklifase – pembentukan virus baru – lisis – adsorpsi – penetrasi";
            }
            else if (sesi == 1)
            {
                textsoal.text = "Di bawah ini adalah penyakit yang disebabkan oleh virus :\n•	(1) New Castle Disease(NCD)\n•	(2) Citrus Vein Phloem Degeneration(CVPD)\n•	(3) Foot and Mouth Disease(FMD)\n•	(4) Tobacco Mosaik Virus(TMV)\n•	(5) Tungro\nPenyakit yang menyerang tumbuhan adalah….";
                PilihanA.text = "2, 4 dan 5";
                PilihanB.text = "1, 4 dan 5";
            }
        }
        else if (SceneManager.GetSceneByName("level 9").isLoaded)
        {
            if (sesi == 0)
            {
                textsoal.text = "Ciri khas virus yang tidak terdapat pada organisme lain adalah….";
                PilihanA.text = "bentuknya beraneka ragam";
                PilihanB.text = "hanya dapat berkembang biak dalam satu sel hidup";
            }
            else if (sesi == 1)
            {
                textsoal.text = "Bentuk virus yang menyerang bakteri (bakteriofage) adalah….";
                PilihanA.text = "bentuk T";
                PilihanB.text = "bola";
            }
        }
        else if (SceneManager.GetSceneByName("level 10").isLoaded)
        {
            if (sesi == 0)
            {
                textsoal.text = "Virus dapat hidup pada….";
                PilihanA.text = "embrio ayam";
                PilihanB.text = "ekstrak bakteri";
            }
            else if (sesi == 1)
            {
                textsoal.text = "Sifat virus yang mirip makhluk hidup adalah …..";
                PilihanA.text = "Dapat bereproduksi";
                PilihanB.text = "Dapat mengalami perubahan wujud";
            }
        }

        initTextjawaban();
    }


    private void initTextjawaban()
    {
        if (SceneManager.GetSceneByName("level 1").isLoaded)
        {
            if (sesi == 0)
            {
                Jawaban[0] = "Partikel virus mengandung DNA dan RNA";
            }
            else if (sesi == 1)
            {
                Jawaban[1] = "3 dan 4";
            }
        }
        else if (SceneManager.GetSceneByName("level 2").isLoaded)
        {
            if (sesi == 0)
            {
                Jawaban[0] = "Sel darah";
            }
            else if (sesi == 1)
            {
                Jawaban[1] = "H5N1";
            }
        }
        else if (SceneManager.GetSceneByName("level 3").isLoaded)
        {
            if (sesi == 0)
            {
                Jawaban[0] = "Protoplasma";
            }
            else if (sesi == 1)
            {
                Jawaban[1] = "Hanya memiliki satu macam asam nukleat (DNA atau RNA)";
            }
        }
        else if (SceneManager.GetSceneByName("level 4").isLoaded)
        {
            if (sesi == 0)
            {
                Jawaban[0] = "Kapsomer";
            }
            else if (sesi == 1)
            {
                Jawaban[1] = "Retrovirus";
            }
        }
        else if (SceneManager.GetSceneByName("level 5").isLoaded)
        {
            if (sesi == 0)
            {
                Jawaban[0] = "Profag";
            }
            else if (sesi == 1)
            {
                Jawaban[1] = "Tungro";
            }
        }
        else if (SceneManager.GetSceneByName("level 6").isLoaded)
        {
            if (sesi == 0)
            {
                Jawaban[0] = "rabies, herpes dan sampar";
            }
            else if (sesi == 1)
            {
                Jawaban[1] = "inti sel tidak mempunyai selaput inti";
            }
        }
        else if (SceneManager.GetSceneByName("level 7").isLoaded)
        {
            if (sesi == 0)
            {
                Jawaban[0] = "virus";
            }
            else if (sesi == 1)
            {
                Jawaban[1] = "inti sel mempunyai selaput inti";
            }
        }
        else if (SceneManager.GetSceneByName("level 8").isLoaded)
        {
            if (sesi == 0)
            {
                Jawaban[0] = "Adsorpsi – penetrasi – eklifase – pembentukan virus baru – lisis";
            }
            else if (sesi == 1)
            {
                Jawaban[1] = "2, 4 dan 5";
            }
        }
        else if (SceneManager.GetSceneByName("level 9").isLoaded)
        {
            if (sesi == 0)
            {
                Jawaban[0] = "hanya dapat berkembang biak dalam satu sel hidup";
            }
            else if (sesi == 1)
            {
                Jawaban[1] = "bentuk T";
            }
        }
        else if (SceneManager.GetSceneByName("level 10").isLoaded)
        {
            if (sesi == 0)
            {
                Jawaban[0] = "embrio ayam";
            }
            else if (sesi == 1)
            {
                Jawaban[1] = "Dapat bereproduksi";
            }
        }
    }


    private void getPembahasan()
    {

        canvasPembahasan.SetActive(true);

        print("sesi = " + sesi);


        if (SceneManager.GetSceneByName("level 1").isLoaded)
        {
            if (sesi == 0)
            {
                pembahasan.text = "Pembahasan:\nCiri ciri virus:\n•	Virus bisa bersifat seperti benda hidup, contohnya bisa berkembang biak jika berada di dalam sel hidup.\n•	Memiliki satu asam nukleat, DNA atau RNA saja.\n•	Virus bisa bersifat seperti benda mati, contohnya tidak melakukan metabolisme, tidak bernapas, tidak bergerak, dan berbentuk kristal jika berada di luar sel hidup.\n•	Berukuran sangat kecil, yaitu antara 20 dan 300 nm.";

            }
            else if (sesi == 1)
            {
                pembahasan.text = "Pembahasan:\nYang termasuk asam inti RNA adalah Lyssavirus dan Enterovirus";
            }
        }
        else if (SceneManager.GetSceneByName("level 2").isLoaded)
        {
            if (sesi == 0)
            {
                pembahasan.text = "Pembahasan :\nHIV adalah virus yang menyebabkan seseorang berpotensi terkena penyakit AIDS. HIV atau Human Immunodeficiency Virus adalah virus yang menyerang manusia dan menyerang sistem kekebalan tubuh secara spesifik pada sel darah. Saat HIV menyerang tubuh, maka tubuh kita akan menjadi lemah dalam melawan infeksi.";
            }
            else if (sesi == 1)
            {
                pembahasan.text = "Pembahasan :\nTipe yang paling berbahaya adalah virus H5N1, karena menurut penelitian pasien yang terjangkit virus ini hanya memiliki tingkat kesembuhan di bawah 20 %.meskipun hanya ditularkan oleh unggas virus ini merupakan pembunuh yang efektif.";
            }
        }
        else if (SceneManager.GetSceneByName("level 3").isLoaded)
        {
            if (sesi == 0)
            {
                pembahasan.text = "Pembahasan :\nVirus bukan termasuk sel karena tidak memiliki Protoplasma dan Nukleus(Inti Sel) Virus juga akan menjadi benda mati bila tidak menumpang hidup pada makhluk lain.\nContoh : Beberapa virus ada yang tinggal di darah manusia dan darah hewan.";
            }
            else if (sesi == 1)
            {
                pembahasan.text = "Pembahasan :\nYang termasuk sifat virus yaitu:\n•	Dapat dikristalkan\n•	Hanya dapat hidup dalam sel yang hidup atau parasit\n•	Bersifat sangat kecil\n•	Tidak termasuk sel karena tidak memiliki dinding sel/ membran sel, ribosom, dan lain-lain\n•	Memiliki satu jenis asam nukleat";
            }
        }
        else if (SceneManager.GetSceneByName("level 4").isLoaded)
        {
            if (sesi == 0)
            {
                pembahasan.text = "Pembahasan :\nKapsomer adalah subunit - subunit protein dengan jumlah jenis protein yang biasanya sedikit, kapsomer akan bergabung membentuk kapsid, misalnya virus mozaik yang memiliki kapsid heliks(batang) yang kaku dan tersusun dari seribu kapsomer, namun kapsomer tersebut dari satu jenis protein saja.";
            }
            else if (sesi == 1)
            {
                pembahasan.text = "Pembahasan :\nFeline leukemia virus.Feline leukemia virus(disingkat FeLV) adalah spesies retrovirus yang menginfeksi kucing. FeLV dapat ditularkan dari kucing yang terinfeksi melalui air liur atau cairan hidung yang mengandung virus. Jika sistem imun hewan rendah, virus dapat menyebabkan penyakit yang dapat mematikan.";
            }
        }
        else if (SceneManager.GetSceneByName("level 5").isLoaded)
        {
            if (sesi == 0)
            {
                pembahasan.text = "Pembahasan :\nProvirus adalah genom virus yang diintegrasikan ke dalam DNA sel inang. Dalam kasus virus bakteri (bakteriofag), provirus sering disebut sebagai profag.";
            }
            else if (sesi == 1)
            {
                pembahasan.text = "Pembahasan :\nVirus yang menyebabkan pertumbuhan tanaman padi terhambat sehingga tanaman menjadi kerdil adalah Tungro";
            }
        }
        else if (SceneManager.GetSceneByName("level 6").isLoaded)
        {
            if (sesi == 0)
            {
                pembahasan.text = "Pembahasan :\nPenyakit yang disebabkan oleh virus adalah: rabies, cacar, campak, influensa, SARS, flu burung, herpes, polio, hepatitis, gondong, kanker dan AIDS, demam berdarah, sampar(pada ayam), demam.";
            }
            else if (sesi == 1)
            {
                pembahasan.text = "Pembahasan :\nProkariotik adalah organisme yang mempunyai inti, tetapi intinya tidak memiliki membran atau selaput inti, begitu juga bakteri.Mahluk hidup prokariotik termasuk dalam kelompok Monera(uniseluler dan tidak bermembran inti).Selain bakteri, juga cyanophyta atau alga biru hijau";
            }

        }
        else if (SceneManager.GetSceneByName("level 7").isLoaded)
        {
            if (sesi == 0)
            {
                pembahasan.text = "Pembahasan :\nDemam berdarah disebabkan Tago virus(Flavi virus) atau dengue. Aedes aegepty adalah vektor yang membawa penyakit ini.";
            }
            else if (sesi == 1)
            {
                pembahasan.text = "Pembahasan :\nArti sel eukariotik adalah sel yang inti selnya mempunyai selaput(membran) inti, misalnya sel tumbuhan dan hewan.";
            }
        }
        else if (SceneManager.GetSceneByName("level 8").isLoaded)
        {
            if (sesi == 0)
            {
                pembahasan.text = "Pembahasan :\n•	Daur litik meliputi fase adsorbsi(penempelan), fase injeksi(penetrasi), fase sintesis, fase perakitan, dan fase litik(lisis).\n•	Daur lisogenik mengalami fase-fase, yaitu penggabungan, fase tenang / lisogenik, dan fase litik.";
            }
            else if (sesi == 1)
            {
                pembahasan.text = "Pembahasan :\n\n•	NCD menyebabkan tetelo pada ayam\n•	CVPD menyebabkan penyakit padajeruk\n•	FMD menyebabkan penyakit pada mulut dan kaki\n•	TMV menyebabkan penyakit pada tembaku\nTungro menyebabkan penyakit pada tanaman padi.Vektornya adalah wereng hijau dan wereng cokelat.";
            }
        }
        else if (SceneManager.GetSceneByName("level 9").isLoaded)
        {
            if (sesi == 0)
            {
                pembahasan.text = "Pembahasan :\nUntuk berkembang biak virus harus menginfeksi sel inang. Inang virus berupa makhluk lain, yaitu bakteri sel tumbuhan maupun sel hewan.";
            }
            else if (sesi == 1)
            {
                pembahasan.text = "Pembahasan :\nBakteriofge memiliki bentuk seperti huruf T. Tubuh bakteriofage tersusun atas kepala, ekor, dan serabut ekor.";
            }
        }
        else if (SceneManager.GetSceneByName("level 10").isLoaded)
        {
            if (sesi == 0)
            {
                pembahasan.text = "Pembahasan :\nVirus hanya bisa hidup dan berkembang biak pada sel hidup.";
            }
            else if (sesi == 1)
            {
                pembahasan.text = "Pembahasan :\nkarena salah satu ciri makhluk hidup adalah dapat berkembang biak begitu juga dengan virus yang dapat berkembang biak";
            }
        }
    }
}
