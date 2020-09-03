using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace eazyweb
{
    public partial class Form1 : Form
    {
        //画面フラグ
        public int flg = 0;
        //編集フラグ
        public int editflg = 0;
        //入れ替え部品
        public int contflg = 0;
        public int BCount1 = 0;
        public int BCount2 = 0;
        public int ItemCount1 = 0;
        public int ItemCount2 = 0;
        public Dictionary<String, int> dic = new Dictionary<string, int>();
        public Dictionary<String, String> dic2 = new Dictionary<string, string>() { { "", "" } };
        public Dictionary<int, String> OpenedTag = new Dictionary<int, string>();
        public Dictionary<int, String> OpenedName = new Dictionary<int, string>();

        public String name1 = "";
        public String name2 = "";
        public String title = "新規作成";

        public String[] csv1 = new String[0];
        public String[] csv2 = new String[0];
        //追加部品のカウント
        public int addHeadCount = 1;
        public int addBodyCount = 0;
        public int addH1Count = 0;
        public int addTableCount = 0;
        public int addImgCount = 0;
        public int addUrlCount = 0;
        //追加-2020/09/02
        public int addPCount = 0;
        public int addEmCount = 0;
        public int addBCount = 0;
        public int addOlCount = 0;
        public int addUlCount = 0;


        //入れ替え時のインデックス保持用
        public int cont1 = 0;
        public int cont2 = 0;
        //入れ替え時の部品コントロール保持用
        Control ctrl1;
        Control ctrl2;

        //作業状態系
        List<string> listTag = new List<string>();
        List<string> listName = new List<string>();
        List<string> listTitle = new List<string>();    //タイトル用に追加2020/09/01

        //起動ファイルのパス取得
        private String path = Directory.GetCurrentDirectory();

        private void Reset()
        {
            try
            {
                this.flowLayoutPanel_body.Controls.Clear();
                this.flowLayoutPanel_head.Controls.Clear();
                this.flowLayoutPanel_input.Controls.Clear();
                textTitle.Text = "";

                //画面フラグ
                flg = 0;
                //編集フラグ
                editflg = 0;
                //入れ替え部品
                contflg = 0;
                BCount1 = 0;
                BCount2 = 0;
                ItemCount1 = 0;
                ItemCount2 = 0;
                dic.Clear();
                dic2.Clear();
                OpenedTag.Clear();
                OpenedName.Clear();

                name1 = null;
                name2 = null;

                var list = new List<string>();
                list.AddRange(csv1);
                list.Clear();
                csv1 = list.ToArray();

                list.AddRange(csv2);
                list.Clear();
                csv2 = list.ToArray();

                //追加部品のカウント
                addHeadCount = 1;
                addBodyCount = 0;
                addH1Count = 0;
                addPCount = 0;
                addTableCount = 0;
                addImgCount = 0;
                addUrlCount = 0;
                

                //入れ替え時のインデックス保持用
                cont1 = 0;
                cont2 = 0;
                //作業状態系
                listTag.Clear();
                listName.Clear();
            }
            catch (Exception ex)
            {
                OutputErrorLog(ex);
            }
            
        }

        public Form1()
        {
            InitializeComponent();
        }

        //タグツリーのボタン表示の切り替え
        public void ButtonVisible()
        {
            try
            {
                switch (flg)
                {
                    //HTMLボタン
                    case 0:
                        this.button_body2.Visible = false;
                        this.button_head1.Visible = true;
                        this.group_tag.Visible = true;
                        this.groupHead.Visible = false;
                        this.groupBody.Visible = false;
                        this.button_delete.Visible = false;
                        this.button_swap.Visible = false;
                        this.groupInput.Visible = false;
                        this.group_tag.BackColor = Color.FromArgb(238, 106, 34);
                        this.label1.BackColor = Color.FromArgb(238, 106, 34);
                        editflg = 0;
                        contflg = 0;
                        break;
                    //HEADボタン
                    case 1:
                        this.groupHead.Visible = true;
                        this.groupBody.Visible = false;
                        this.button_delete.Visible = false;
                        this.button_swap.Visible = false;
                        this.groupInput.Visible = false;
                        this.group_tag.BackColor = Color.FromArgb(238, 106, 34);
                        this.label1.BackColor = Color.FromArgb(238, 106, 34);
                        editflg = 0;
                        contflg = 0;
                        break;
                    //BODYボタン
                    case 2:
                        this.groupHead.Visible = false;
                        this.groupBody.Visible = true;
                        this.button_delete.Visible = false;
                        this.button_swap.Visible = false;
                        this.groupInput.Visible = false;
                        this.group_tag.BackColor = Color.FromArgb(238, 106, 34);
                        this.label1.BackColor = Color.FromArgb(238, 106, 34);
                        editflg = 0;
                        contflg = 0;
                        break;
                    //削除ボタン
                    case 5:
                        
                            this.button_delete.Visible = true;
                            this.button_swap.Visible = true;
                            this.group_tag.BackColor = Color.FromName("Brown");
                            this.label1.BackColor = Color.FromName("Brown");
                            contflg = 0;
                            break;
                        
                    //編集ボタン
                    case 6:
                        if (editflg == 0)
                        {
                            this.button_delete.Visible = true;
                            this.button_swap.Visible = true;
                        }
                        else
                        {
                            this.button_delete.Visible = false;
                            this.button_swap.Visible = false;
                        }
                        this.group_tag.BackColor = Color.FromArgb(238, 106, 34);
                        this.label1.BackColor = Color.FromArgb(238, 106, 34);
                        contflg = 0;
                        break;
                    //入れ替え
                    case 7:
                        this.group_tag.BackColor = Color.FromArgb(238, 106, 34);
                        this.label1.BackColor = Color.FromArgb(238, 106, 34);
                        break;
                    //例外
                    default:
                        this.group_tag.Visible = true;
                        this.groupHead.Visible = false;
                        this.groupBody.Visible = false;
                        this.groupInput.Visible = false;
                        this.button_delete.Visible = false;
                        this.button_swap.Visible = false;
                        this.group_tag.BackColor = Color.FromArgb(238, 106, 34);
                        this.label1.BackColor = Color.FromArgb(238, 106, 34);
                        editflg = 0;
                        contflg = 0;
                        break;

                }
            }
            catch(Exception ex)
            {
                OutputErrorLog(ex);
            }
            
        }

        //---タグツリーのHEADボタン処理
        private void button_head1_Click(object sender, EventArgs e)
        {
            if(flg == 5)
            {
                flg = 1;
                ButtonVisible();
                flg = 5;
                ButtonVisible();
            }else
            {
                flg = 1;
                ButtonVisible();
            }
            
        }
        //---

        //---タグツリーのタグツリーのBODYボタン処理
        private void button_body1_Click(object sender, EventArgs e)
        {
            if(flg == 5)
            {
                flg = 2;
                button_head1.Visible = false;
                button_body2.Visible = true;
                ButtonVisible();
                flg = 5;
                ButtonVisible();
            }else
            {
                flg = 2;
                button_head1.Visible = false;
                button_body2.Visible = true;
                ButtonVisible();
            }
            
            

        }

        private void button_body2_Click(object sender, EventArgs e)
        {
            if (flg == 5)
            {
                flg = 2;
                button_head1.Visible = false;
                button_body2.Visible = true;
                ButtonVisible();
                flg = 5;
                ButtonVisible();
            }
            else
            {
                flg = 2;
                button_head1.Visible = false;
                button_body2.Visible = true;
                ButtonVisible();
            }

        }
        //---

        //---タグツリーのHTMLボタン処理
        private void button_html_Click(object sender, EventArgs e)
        {
            flg = 0;
            ButtonVisible();
        }
        //---

        //Formロード時処理
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //---タグ一覧のリスト処理
                String[] Item = { "見出し", "テキスト", "強調", "ハイパーテキスト", "太字", "順序ありリスト", "順序なしリスト", "画像", "テーブル"};

                foreach (String addItem in Item)
                {
                    listItem.Items.Add(addItem);
                }
                //---

                //---タグツリーグループのスクロール
                this.flowLayoutPanel_body.VerticalScroll.Visible = true;
                this.flowLayoutPanel_input.VerticalScroll.Visible = true;
                this.flowLayoutPanel_head.VerticalScroll.Visible = true;
                //---
                ToolTip tt = new ToolTip();
                tt.SetToolTip(button_html, "全体");
                tt.SetToolTip(button_head1, "<head>部分");
                tt.SetToolTip(button_body1, "<body>部分");
            }
            catch(Exception ex)
            {
                OutputErrorLog(ex);
            }
            
            
        }
        //---

        //部品一覧の部品選択時の処理
        private void listItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddTag(listItem.SelectedIndex);
        }
        //---

        //---編集ボタンを押したとき
        private void button_edit_Click_1(object sender, EventArgs e)
        {
            if (editflg == 0)
            {
                flg = 6;
                ButtonVisible();
                editflg = 1;
            }
            else
            {
                flg = 6;
                ButtonVisible();
                editflg = 0;
            }

        }
        //---

        //---動的ボタンのイベント(引数：部品名、部品の種類、追加カウント、アイテムカウント、部品)
        private EventHandler btnclick(String name, String getkind, int BodyCount, int itemCount, Control cont)
        {
            return delegate (object sender2, EventArgs e2)
            {
                try
                {
                    if (flg != 6 && flg != 5 && flg != 7)
                    {   //通常時の処理

                        
                            switch (getkind)
                            {
                                //プロパティ系
                                case "h1":
                                    //property_text.Text = "class :" + name;
                                    break;
                                case "p":
                                    //property_text.Text = "class :" + name;
                                    break;
                                case "em":
                                    //property_text.Text = "class :" + name;
                                    break;
                                case "url":
                                    //property_text.Text = "class :" + name;
                                    break;
                                case "b":
                                    //urlの編集がしたい
                                    //property_text.Text = "class :" + name;
                                    break;
                                case "lo":
                                    //property_text.Text = "class :" + name;
                                    break;
                                case "ul":
                                    //property_text.Text = "class :" + name;
                                    break;
                                case "img":
                                    //property_text.Text = "class :" + name;
                                    break;
                                case "table":   
                                    break;
                                default:
                                    break;
                            }
                        
                    }//通常時
                    else if (flg == 6)   //編集時
                    {
                                ButtonVisible();
                        
                    }//flg==6編集時
                    else if (flg == 5)
                    {   //削除ボタン

                        
                        Control[] controls = Controls.Find(name, true);
                        foreach (Control control in controls)
                        {   //部品の削除処理
                            this.Controls.Remove(control);
                            OpenedName.Remove(dic[name]);
                            OpenedTag.Remove(dic[name]);
                            dic.Remove(name);
                            control.Dispose();
                        }

                    }//flg==5削除
                    else if (flg == 7)
                    {//bodyグループ入れ替え処理
                        switch (contflg)
                        {   //選択回数
                            //1回目
                            case 0:
                                name1 = name;   //一つ目の部品の名前を保持
                                ctrl1 = cont;   //部品のコントロールを保持
                                cont1 = flowLayoutPanel_body.Controls.GetChildIndex(cont);  //Body部品のFlowLayoutPanelのインデックスを保持
                                contflg = 1;    //選択カウントを設定
                                break;
                            //二回目
                            case 1:
                                ctrl2 = cont;   //二つ目の部品の名前を保持
                                cont2 = flowLayoutPanel_body.Controls.GetChildIndex(cont);  //Body部品のFlowLayoutPanelのインデックスを保持
                                SwapControls(cont1, cont2, ctrl1, ctrl2);       //入れ替えメソッドの実行
                                contflg = 0;    //初期化
                                break;
                            default:
                                break;
                        }


                    }//flg==7入れ替え
                }
                catch(Exception ex)
                {
                    OutputErrorLog(ex);
                }
                
            };
        }
        //---

        //削除ボタン
        private void button_delete_Click(object sender, EventArgs e)
        {
            flg = 5;
            ButtonVisible();
        }
        //---

        //入れ替えボタン
        private void button_swap_Click(object sender, EventArgs e)
        {
            flg = 7;
            ButtonVisible();

        }
        //---

        //---入れ替え処理メソッド
        private void SwapControls(int x, int y, Control ctrl1, Control ctrl2)
        {

            try
            {
                //入れ替え処理
                flowLayoutPanel_body.SuspendLayout();
                flowLayoutPanel_body.Controls.SetChildIndex(ctrl1, y);
                flowLayoutPanel_body.Controls.SetChildIndex(ctrl2, x);
                flowLayoutPanel_body.ResumeLayout();
                //csv用入れ替え
                x++;
                y++;
                var tmp = OpenedTag[x];
                OpenedTag[x] = OpenedTag[y];
                OpenedTag[y] = tmp;
                //csv用入れ替え
                tmp = OpenedName[x];
                OpenedName[x] = OpenedName[y];
                OpenedName[y] = tmp;
            }
            catch (Exception ex) {
                OutputErrorLog(ex);
            }
        }
        //---

        //作業ファイルの保存リスナー＆処理
        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                //統合時関係ないかも
                saveFileDialog1.DefaultExt = "csv";
                saveFileDialog1.Filter = "CSVファイル | *.csv";
                saveFileDialog1.AddExtension = true;
                saveFileDialog1.InitialDirectory = path + "\\CSV";
                MessageBox.Show(saveFileDialog1.InitialDirectory);
                //---

                if (DialogResult.OK == saveFileDialog1.ShowDialog())
                {
                    // csvファイルのパス
                    var filePath = saveFileDialog1.FileName;
                    //var filePath = path + "/CSV";   //パスは変える (作業ファイル名.csv)
                    // csvに出力するデータ
                    for (int i = 0; i < OpenedTag.Count; i++)
                    {
                        Array.Resize(ref csv1, csv1.Length + 1);
                        Array.Resize(ref csv2, csv2.Length + 1);
                        foreach (var key in OpenedTag.Keys)
                        {
                            csv1[i] = OpenedTag[i + 1];
                            csv2[i] = OpenedName[i + 1];
                        }
                    }
                    // csvファイルの書き込み
                    StreamWriter file = new StreamWriter(filePath, false, Encoding.UTF8);
                    for (int i = 0; i < csv1.Length; i++)
                    {
                        if (i == 0)
                        {
                            file.WriteLine(string.Format("{0},{1},{2}", csv1[i], csv2[i], textTitle.Text)); //1-3にタイトルのテキストボックスの値を保存
                        }
                        else
                        {
                            file.WriteLine(string.Format("{0},{1}", csv1[i], csv2[i])); // データ部出力
                        }

                    }



                    file.Close();
                }
            }
            catch(Exception ex)
            {
                OutputErrorLog(ex);
            }
            


        }

        //作業ファイル開くリスナー
        private void button_open_Click(object sender, EventArgs e)
        {
            try
            {
                //変数の初期化
                Reset();

                //統合時関係ないかも
                openFileDialog1.Filter = "CSVファイル | *.csv";
                openFileDialog1.InitialDirectory = path;
                openFileDialog1.FileName = "";
                if (DialogResult.OK == openFileDialog1.ShowDialog())
                {
                    title = openFileDialog1.SafeFileName;
                    //---

                    // csvファイルのパス
                    var filePath = openFileDialog1.FileName;
                    //var filePath = @"C:\Users\s3a2\Desktop\" + title + ".csv";

                    // csvファイルの読込
                    StreamReader reader = new StreamReader(File.OpenRead(filePath));
                    //タイトル取得用フラグ
                    int tflg = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        listTag.Add(values[0]);
                        listName.Add(values[1]);

                        //タイトルの取得
                        if (tflg == 0)
                        {
                            listTitle.Add(values[2]);
                            tflg++;
                        }
                    }
                    reader.Close();
                    OpenProcess();
                }
            }
            catch(Exception ex)
            {
                OutputErrorLog(ex);
            }
            

        }

        //作業ファイルを開いたときの処理
        private void OpenProcess()
        {
            try
            {
                textTitle.Text = listTitle[0];
                int lc = 0;
                while (lc != listTag.Count)
                {
                    //読み込んだcsvファイルを元にタグツリーの部品の生成
                    switch (listTag[lc])
                    {
                        
                        case "h1":
                            AddTag(0, listName[lc]);
                            break;
                        case "p":
                            AddTag(1, listName[lc]);
                            break;
                        case "em":
                            AddTag(2, listName[lc]);
                            break;
                        case "url":
                            AddTag(3, listName[lc]);
                            break;
                        case "b":
                            AddTag(4, listName[lc]);
                            break;
                        case "ol":
                            AddTag(5, listName[lc]);
                            break;
                        case "ul":
                            AddTag(6, listName[lc]);
                            break;
                        case "img":
                            AddTag(7, listName[lc]);
                            break;
                        case "table":
                            AddTag(8, listName[lc]);
                            break;
                        default:
                            break;
                    }
                    lc++;
                }
            }
            catch(Exception ex)
            {
                OutputErrorLog(ex);
            }
            

        }

        //タグツリーの部品追加処理（通常時）
        private void AddTag(int Index)
        {
            try
            {
                //タグツリーのBODYグループに部品のボタンを追加
                switch (Index)
                {
                    //見出し
                    case 0:
                        addH1Count++;                                                                   //見出し個数のカウント
                        Button button_h1 = new Button();                                                //新規ボタンのインスタンス                    //ボタンの配置場所の設定
                        button_h1.Size = new Size(122, 54);                                             //ボタンのサイズ
                        button_h1.ForeColor = Color.FromArgb(90, 92, 79);                               //ボタンの文字色の設定
                        button_h1.BackColor = Color.FromArgb(211, 214, 195);                              //ボタンの背景色の設定
                        button_h1.FlatStyle = FlatStyle.Flat;                                           //枠のスタイルの設定
                        button_h1.FlatAppearance.BorderSize = 0;                                        //枠なしに設定
                        button_h1.Text = "<H1>";                                                        //ボタンのテキスト
                        button_h1.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);                  //フォントの設定
                        button_h1.Name = "h1_" + addH1Count;                                            //ボタンのNameの設定
                        flowLayoutPanel_body.Controls.Add(button_h1);
                        addBodyCount++;                                                                 //BODYの個数のカウント
                        dic.Add(button_h1.Name, addBodyCount);
                        OpenedTag.Add(addBodyCount, "h1");
                        OpenedName.Add(addBodyCount, button_h1.Name.ToString());
                        button_h1.Click += btnclick(button_h1.Name, "h1", dic[button_h1.Name], addH1Count, button_h1);                  //追加したボタンにイベントを追加
                        break;
                    //テキスト
                    case 1:
                        addPCount++;
                        Button button_p = new Button();
                        button_p.Size = new Size(122, 54);
                        button_p.ForeColor = Color.FromArgb(90, 92, 79);
                        button_p.BackColor = Color.FromArgb(211, 214, 195);
                        button_p.FlatStyle = FlatStyle.Flat;
                        button_p.FlatAppearance.BorderSize = 0;
                        button_p.Text = "<P>";
                        button_p.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_p.Name = "p_" + addPCount;
                        flowLayoutPanel_body.Controls.Add(button_p);
                        addBodyCount++;
                        dic.Add(button_p.Name, addBodyCount);
                        OpenedTag.Add(addBodyCount, "p");
                        OpenedName.Add(addBodyCount, button_p.Name.ToString());
                        button_p.Click += btnclick(button_p.Name, "p", dic[button_p.Name], addPCount, button_p);
                        break;
                    //強調
                    case 2:
                        addEmCount++;
                        Button button_em = new Button();
                        button_em.Size = new Size(122, 54);
                        button_em.ForeColor = Color.FromArgb(90, 92, 79);
                        button_em.BackColor = Color.FromArgb(211, 214, 195);
                        button_em.FlatStyle = FlatStyle.Flat;
                        button_em.FlatAppearance.BorderSize = 0;
                        button_em.Text = "<EM>";
                        button_em.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_em.Name = "em_" + addTableCount;
                        flowLayoutPanel_body.Controls.Add(button_em);
                        addBodyCount++;
                        dic.Add(button_em.Name, addBodyCount);
                        OpenedTag.Add(addBodyCount, "em");
                        OpenedName.Add(addBodyCount, button_em.Name.ToString());
                        button_em.Click += btnclick(button_em.Name, "em", dic[button_em.Name], addTableCount, button_em);
                        break;
                    //ハイパーテキスト
                    case 3:
                        addUrlCount++;
                        Button button_url = new Button();
                        button_url.Size = new Size(122, 54);
                        button_url.ForeColor = Color.FromArgb(90, 92, 79);
                        button_url.BackColor = Color.FromArgb(211, 214, 195);
                        button_url.FlatStyle = FlatStyle.Flat;
                        button_url.FlatAppearance.BorderSize = 0;
                        button_url.Text = "<URL>";
                        button_url.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_url.Name = "url_" + addImgCount;
                        flowLayoutPanel_body.Controls.Add(button_url);
                        addBodyCount++;
                        dic.Add(button_url.Name, addBodyCount);
                        OpenedTag.Add(addBodyCount, "url");
                        OpenedName.Add(addBodyCount, button_url.Name.ToString());
                        button_url.Click += btnclick(button_url.Name, "url", dic[button_url.Name], addImgCount, button_url);
                        break;
                    //太字
                    case 4:
                        addBCount++;
                        Button button_b = new Button();
                        button_b.Size = new Size(122, 54);
                        button_b.ForeColor = Color.FromArgb(90, 92, 79);
                        button_b.BackColor = Color.FromArgb(211, 214, 195);
                        button_b.FlatStyle = FlatStyle.Flat;
                        button_b.FlatAppearance.BorderSize = 0;
                        button_b.Text = "<B>";
                        button_b.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_b.Name = "b_" + addBCount;
                        flowLayoutPanel_body.Controls.Add(button_b);
                        addBodyCount++;
                        dic.Add(button_b.Name, addBodyCount);
                        OpenedTag.Add(addBodyCount, "b");
                        OpenedName.Add(addBodyCount, button_b.Name.ToString());
                        button_b.Click += btnclick(button_b.Name, "b", dic[button_b.Name], addBCount, button_b);
                        break;
                    //順序ありリスト
                    case 5:
                        addOlCount++;
                        Button button_ol = new Button();
                        button_ol.Size = new Size(122, 54);
                        button_ol.ForeColor = Color.FromArgb(90, 92, 79);
                        button_ol.BackColor = Color.FromArgb(211, 214, 195);
                        button_ol.FlatStyle = FlatStyle.Flat;
                        button_ol.FlatAppearance.BorderSize = 0;
                        button_ol.Text = "<OL>";
                        button_ol.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_ol.Name = "ol_" + addOlCount;
                        flowLayoutPanel_body.Controls.Add(button_ol);
                        dic.Add(button_ol.Name, addBodyCount);
                        addBodyCount++;
                        dic2.Add("ol_" + addOlCount, button_ol.Name);
                        OpenedTag.Add(addBodyCount, "ol");
                        OpenedName.Add(addBodyCount, button_ol.Name.ToString());
                        button_ol.Click += btnclick(button_ol.Name, "ol", dic[button_ol.Name], addOlCount, button_ol);
                        break;
                    //順序なしリスト
                    case 6:
                        addUlCount++;
                        Button button_ul = new Button();
                        button_ul.Size = new Size(122, 54);
                        button_ul.ForeColor = Color.FromArgb(90, 92, 79);
                        button_ul.BackColor = Color.FromArgb(211, 214, 195);
                        button_ul.FlatStyle = FlatStyle.Flat;
                        button_ul.FlatAppearance.BorderSize = 0;
                        button_ul.Text = "<UL>";
                        button_ul.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_ul.Name = "ul_" + addUlCount;
                        flowLayoutPanel_body.Controls.Add(button_ul);
                        dic.Add(button_ul.Name, addBodyCount);
                        addBodyCount++;
                        dic2.Add("ul_" + addUlCount, button_ul.Name);
                        OpenedTag.Add(addBodyCount, "ul");
                        OpenedName.Add(addBodyCount, button_ul.Name.ToString());
                        button_ul.Click += btnclick(button_ul.Name, "ul", dic[button_ul.Name], addUlCount, button_ul);
                        break;
                    //画像
                    case 7:
                        addImgCount++;
                        Button button_img = new Button();
                        button_img.Size = new Size(122, 54);
                        button_img.ForeColor = Color.FromArgb(90, 92, 79);
                        button_img.BackColor = Color.FromArgb(211, 214, 195);
                        button_img.FlatStyle = FlatStyle.Flat;
                        button_img.FlatAppearance.BorderSize = 0;
                        button_img.Text = "<IMG>";
                        button_img.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_img.Name = "img_" + addImgCount;
                        flowLayoutPanel_body.Controls.Add(button_img);
                        addBodyCount++;
                        dic.Add(button_img.Name, addBodyCount);
                        OpenedTag.Add(addBodyCount, "img");
                        OpenedName.Add(addBodyCount, button_img.Name.ToString());
                        button_img.Click += btnclick(button_img.Name, "img", dic[button_img.Name], addImgCount, button_img);
                        break;

                    //テーブル
                    case 8:
                        Button button_table = new Button();
                        button_table.Size = new Size(122, 54);
                        button_table.ForeColor = Color.FromArgb(90, 92, 79);
                        button_table.BackColor = Color.FromArgb(211, 214, 195);
                        button_table.FlatStyle = FlatStyle.Flat;
                        button_table.FlatAppearance.BorderSize = 0;
                        button_table.Text = "<TABLE>";
                        button_table.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_table.Name = "table_" + addTableCount;
                        flowLayoutPanel_body.Controls.Add(button_table);
                        addBodyCount++;
                        dic.Add(button_table.Name, addBodyCount);
                        OpenedTag.Add(addBodyCount, "table");
                        OpenedName.Add(addBodyCount, button_table.Name.ToString());
                        button_table.Click += btnclick(button_table.Name, "table", dic[button_table.Name], addTableCount, button_table);
                        break;
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                OutputErrorLog(ex);
            }
            
        }
        //タグツリーの部品追加処理（作業ファイルを開いたとき）
        private void AddTag(int Index, String name)
        {
            try
            {
                //タグツリーのBODYグループに部品のボタンを追加
                switch (Index)
                {
                    //見出し
                    case 0:
                        addH1Count++;                                                                   //見出し個数のカウント
                        Button button_h1 = new Button();                                                //新規ボタンのインスタンス                    //ボタンの配置場所の設定
                        button_h1.Size = new Size(122, 54);                                             //ボタンのサイズ
                        button_h1.ForeColor = Color.FromArgb(90, 92, 79);                               //ボタンの文字色の設定
                        button_h1.BackColor = Color.FromArgb(211, 214, 195);                            //ボタンの背景色の設定
                        button_h1.FlatStyle = FlatStyle.Flat;                                           //枠のスタイルの設定
                        button_h1.FlatAppearance.BorderSize = 0;                                        //枠なしに設定
                        button_h1.Text = "<H1>";                                                        //ボタンのテキスト
                        button_h1.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);                  //フォントの設定
                        button_h1.Name = name;                                                          //ボタンのNameの設定
                        flowLayoutPanel_body.Controls.Add(button_h1);
                        addBodyCount++;                                                                 //BODYの個数のカウント
                        dic.Add(button_h1.Name, addBodyCount);
                        OpenedTag.Add(addBodyCount, "h1");
                        OpenedName.Add(addBodyCount, button_h1.Name.ToString());
                        button_h1.Click += btnclick(button_h1.Name, "h1", dic[button_h1.Name], addH1Count, button_h1);                  //追加したボタンにイベントを追加
                        break;
                    //テキスト
                    case 1:
                        addPCount++;
                        Button button_p = new Button();
                        button_p.Size = new Size(122, 54);
                        button_p.ForeColor = Color.FromArgb(90, 92, 79);
                        button_p.BackColor = Color.FromArgb(211, 214, 195);
                        button_p.FlatStyle = FlatStyle.Flat;
                        button_p.FlatAppearance.BorderSize = 0;
                        button_p.Text = "<P>";
                        button_p.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_p.Name = name;
                        flowLayoutPanel_body.Controls.Add(button_p);
                        addBodyCount++;
                        dic.Add(button_p.Name, addBodyCount);
                        OpenedTag.Add(addBodyCount, "p");
                        OpenedName.Add(addBodyCount, button_p.Name.ToString());
                        button_p.Click += btnclick(button_p.Name, "p", dic[button_p.Name], addPCount, button_p);
                        break;
                    //強調
                    case 2:
                        addEmCount++;
                        Button button_em = new Button();
                        button_em.Size = new Size(122, 54);
                        button_em.ForeColor = Color.FromArgb(90, 92, 79);
                        button_em.BackColor = Color.FromArgb(211, 214, 195);
                        button_em.FlatStyle = FlatStyle.Flat;
                        button_em.FlatAppearance.BorderSize = 0;
                        button_em.Text = "<EM>";
                        button_em.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_em.Name = name;
                        flowLayoutPanel_body.Controls.Add(button_em);
                        addBodyCount++;
                        dic.Add(button_em.Name, addBodyCount);
                        OpenedTag.Add(addBodyCount, "em");
                        OpenedName.Add(addBodyCount, button_em.Name.ToString());
                        button_em.Click += btnclick(button_em.Name, "em", dic[button_em.Name], addEmCount, button_em);
                        break;
                    //ハイパーテキスト
                    case 3:
                        addUrlCount++;
                        Button button_url = new Button();
                        button_url.Size = new Size(122, 54);
                        button_url.ForeColor = Color.FromArgb(90, 92, 79);
                        button_url.BackColor = Color.FromArgb(211, 214, 195);
                        button_url.FlatStyle = FlatStyle.Flat;
                        button_url.FlatAppearance.BorderSize = 0;
                        button_url.Text = "<URL>";
                        button_url.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_url.Name = name;
                        flowLayoutPanel_body.Controls.Add(button_url);
                        addBodyCount++;
                        dic.Add(button_url.Name, addBodyCount);
                        OpenedTag.Add(addBodyCount, "url");
                        OpenedName.Add(addBodyCount, button_url.Name.ToString());
                        button_url.Click += btnclick(button_url.Name, "url", dic[button_url.Name], addUrlCount, button_url);
                        break;
                    //太字
                    case 4:
                        addBCount++;
                        Button button_b = new Button();
                        button_b.Size = new Size(122, 54);
                        button_b.ForeColor = Color.FromArgb(90, 92, 79);
                        button_b.BackColor = Color.FromArgb(211, 214, 195);
                        button_b.FlatStyle = FlatStyle.Flat;
                        button_b.FlatAppearance.BorderSize = 0;
                        button_b.Text = "<B>";
                        button_b.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_b.Name = name;
                        flowLayoutPanel_body.Controls.Add(button_b);
                        addBodyCount++;
                        dic.Add(button_b.Name, addBodyCount);
                        OpenedTag.Add(addBodyCount, "b");
                        OpenedName.Add(addBodyCount, button_b.Name.ToString());
                        button_b.Click += btnclick(button_b.Name, "b", dic[button_b.Name], addBCount, button_b);
                        break;
                    //順序ありリスト
                    case 5:
                        addOlCount++;
                        Button button_ol = new Button();
                        button_ol.Size = new Size(122, 54);
                        button_ol.ForeColor = Color.FromArgb(90, 92, 79);
                        button_ol.BackColor = Color.FromArgb(211, 214, 195);
                        button_ol.FlatStyle = FlatStyle.Flat;
                        button_ol.FlatAppearance.BorderSize = 0;
                        button_ol.Text = "<OL>";
                        button_ol.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_ol.Name = name;
                        flowLayoutPanel_body.Controls.Add(button_ol);
                        dic.Add(button_ol.Name, addBodyCount);
                        addBodyCount++;
                        dic2.Add("ol_" + addOlCount, button_ol.Name);
                        OpenedTag.Add(addBodyCount, "ol");
                        OpenedName.Add(addBodyCount, button_ol.Name.ToString());
                        button_ol.Click += btnclick(button_ol.Name, "ol", dic[button_ol.Name], addOlCount, button_ol);
                        break;
                    //順序なしリスト
                    case 6:
                        addUlCount++;
                        Button button_ul = new Button();
                        button_ul.Size = new Size(122, 54);
                        button_ul.ForeColor = Color.FromArgb(90, 92, 79);
                        button_ul.BackColor = Color.FromArgb(211, 214, 195);
                        button_ul.FlatStyle = FlatStyle.Flat;
                        button_ul.FlatAppearance.BorderSize = 0;
                        button_ul.Text = "<UL>";
                        button_ul.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_ul.Name = name;
                        flowLayoutPanel_body.Controls.Add(button_ul);
                        dic.Add(button_ul.Name, addBodyCount);
                        addBodyCount++;
                        dic2.Add("ul_" + addUlCount, button_ul.Name);
                        OpenedTag.Add(addBodyCount, "ul");
                        OpenedName.Add(addBodyCount, button_ul.Name.ToString());
                        button_ul.Click += btnclick(button_ul.Name, "ul", dic[button_ul.Name], addUlCount, button_ul);
                        break;
                    //画像
                    case 7:
                        addImgCount++;
                        Button button_img = new Button();
                        button_img.Size = new Size(122, 54);
                        button_img.ForeColor = Color.FromArgb(90, 92, 79);
                        button_img.BackColor = Color.FromArgb(211, 214, 195);
                        button_img.FlatStyle = FlatStyle.Flat;
                        button_img.FlatAppearance.BorderSize = 0;
                        button_img.Text = "<IMG>";
                        button_img.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_img.Name = name;
                        flowLayoutPanel_body.Controls.Add(button_img);
                        addBodyCount++;
                        dic.Add(button_img.Name, addBodyCount);
                        OpenedTag.Add(addBodyCount, "img");
                        OpenedName.Add(addBodyCount, button_img.Name.ToString());
                        button_img.Click += btnclick(button_img.Name, "img", dic[button_img.Name], addImgCount, button_img);
                        break;

                    //テーブル
                    case 8:
                        Button button_table = new Button();
                        button_table.Size = new Size(122, 54);
                        button_table.ForeColor = Color.FromArgb(90, 92, 79);
                        button_table.BackColor = Color.FromArgb(211, 214, 195);
                        button_table.FlatStyle = FlatStyle.Flat;
                        button_table.FlatAppearance.BorderSize = 0;
                        button_table.Text = "<TABLE>";
                        button_table.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                        button_table.Name = name;
                        flowLayoutPanel_body.Controls.Add(button_table);
                        addBodyCount++;
                        dic.Add(button_table.Name, addBodyCount);
                        OpenedTag.Add(addBodyCount, "table");
                        OpenedName.Add(addBodyCount, button_table.Name.ToString());
                        button_table.Click += btnclick(button_table.Name, "table", dic[button_table.Name], addTableCount, button_table);
                        break;
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                OutputErrorLog(ex);
            }
            
        }

        private void OutputErrorLog(Exception ex)
        {
            // 書き込み設定
            System.IO.StreamWriter sw = new StreamWriter(
             this.path + "\\log\\errorlog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt",   // 出力先ファイル名
             true,                                                           // 追加書き込み
             System.Text.Encoding.GetEncoding("UTF-8"));                 // 文字コード

            // ログ出力
            //sw.SetOut(sw); // 出力先（Outプロパティ）を設定
            sw.WriteLine("[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "] message: " + ex.Message);
            sw.WriteLine("[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "] stack trace: " + ex.StackTrace);
            sw.WriteLine(ex.StackTrace);
            sw.WriteLine();

            // ファイルを閉じる
            sw.Dispose();
        }
    }
}



