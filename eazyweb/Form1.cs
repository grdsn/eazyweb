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
        public Dictionary<String,int> dic = new Dictionary<string, int>();
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
        public int addDivCount = 0;
        public int addTableCount = 0;
        public int addImgCount = 0;
        public int addUrlCount = 0;
        public int addTextboxCount = 0;
        public int addButtonCount = 0;
        public int addNavCount = 0;
        public int addInputCount = 1;
        public int addSmallCount = 0;
        public int addLinkCount = 0;
        public int inputedCount = 1;

        //inputタグのフラグ
        public int inputflg = 0;
        public int inputedflg = 0;
        public int inputeditflg = 0;

        //入れ替え時のインデックス保持用
        public int cont1 = 0;
        public int cont2 = 0;
        //入れ替え時の部品コントロール保持用
        Control ctrl1;
        Control ctrl2;

        //作業状態系
        List<string> listTag = new List<string>();
        List<string> listName = new List<string>();

        //ボタンイベントの有無
        public Boolean button_event = false;

        private void Reset()
        {
            this.flowLayoutPanel_body.Controls.Clear();
            this.flowLayoutPanel_head.Controls.Clear();
            this.flowLayoutPanel_input.Controls.Clear();

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
            addDivCount = 0;
            addTableCount = 0;
            addImgCount = 0;
            addUrlCount = 0;
            addTextboxCount = 0;
            addButtonCount = 0;
            addNavCount = 0;
            addInputCount = 1;
            addSmallCount = 0;
            addLinkCount = 0;
            inputedCount = 1;

            //inputタグのフラグ
            inputflg = 0;
            inputedflg = 0;
            inputeditflg = 0;

            //入れ替え時のインデックス保持用
            cont1 = 0;
            cont2 = 0;
            //作業状態系
            listTag.Clear();
            listName.Clear();

            //ボタンイベントの有無
            button_event = false;

        }

    public Form1()
        {
            InitializeComponent();
        }

        //タグツリーのボタン表示の切り替え
        public void ButtonVisible()
        {
            switch(flg){
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
                    if (inputeditflg == 1)
                    {
                        break;
                    }
                    else
                    {
                        this.groupHead.Visible = false;
                        this.groupBody.Visible = true;
                        this.groupInput.Visible = false;
                        this.group_tag.BackColor = Color.FromName("Brown");
                        this.label1.BackColor = Color.FromName("Brown");
                        contflg = 0;
                        break;
                    }
                //編集ボタン
                case 6:
                    this.button_delete.Visible = true;
                    this.button_swap.Visible = true;
                    this.group_tag.BackColor = Color.FromArgb(238, 106, 34);
                    this.label1.BackColor = Color.FromArgb(238, 106, 34);
                    contflg = 0;
                    break;
                //入れ替え
                case 7:
                    this.group_tag.BackColor = Color.FromArgb(238, 106, 34);
                    this.label1.BackColor = Color.FromArgb(238, 106, 34);
                    break;
                //インプット
                case 8:
                    this.button_body2.Visible = true;
                    this.button_head1.Visible = false;
                    this.groupBody.Visible = false;
                    this.groupHead.Visible = false;
                    this.groupInput.Visible = true;
                    this.group_tag.BackColor = Color.FromArgb(238, 106, 34);
                    this.label1.BackColor = Color.FromArgb(238, 106, 34);
                    editflg = 0;
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
   

      
        //---タグツリーのHEADボタン処理
        private void button_head1_Click(object sender, EventArgs e)
        {
            flg = 1;
            ButtonVisible();
        }

        private void button_head2_Click(object sender, EventArgs e)
        {
            flg = 1;
            ButtonVisible();
        }
        //---

        //---タグツリーのタグツリーのBODYボタン処理
        private void button_body1_Click(object sender, EventArgs e)
        {
            flg = 2;
            button_head1.Visible = false;
            button_body2.Visible = true;
            ButtonVisible();

        }

        private void button_body2_Click(object sender, EventArgs e)
        {
            flg = 2;
            ButtonVisible();

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
            //---タグ一覧のリスト処理
            String [] Item = { "見出し","文","表","画像","URL","テキストボックス","ボタン","ナビ","インプット" ,"スモール","リンク"};

            foreach (String addItem in Item){
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
            if(editflg == 0)
            {
                editflg = 1;
                flg = 6;
                ButtonVisible();
            }
            else
            {
                editflg = 0;
                flg = 2;
                ButtonVisible();
            }
            
        }
        //---

        //---動的ボタンのイベント(引数：部品名、部品の種類、追加カウント、アイテムカウント、部品)
        private EventHandler btnclick(String name,String getkind,int BodyCount, int itemCount, Control cont)
        {               
            return delegate (object sender2, EventArgs e2)
            {

                if (flg != 6 && flg != 5 && flg != 7)
                {   //通常時の処理

                    //<input>のグループ化が行われているか
                    if (inputedflg == 0)    //未グループ化
                    {
                        switch (getkind)
                        {
                            /* プロパティ系
                            case "h1":
                                property_text.Text = "class :" + name;
                                break;
                            case "div":
                                property_text.Text = "class :" + name;
                                break;
                            case "table":
                                property_text.Text = "class :" + name;
                                break;
                            case "img":
                                property_text.Text = "class :" + name;
                                break;
                            case "url":
                                property_text.Text = "class :" + name;
                                break;
                            case "textbox":
                                property_text.Text = "class :" + name;
                                break;
                            case "button":
                                property_text.Text = "class :" + name;
                                break;
                            case "nav":
                                property_text.Text = "class :" + name;
                                break;*/
                            case "input":   //<input>部品を押したらgroup_inputに切り替え
                                flg = 8;
                                ButtonVisible();
                                break;
                            /*case "small":
                                property_text.Text = "class :" + name;
                                break;*/
                            default:
                                break;
                        }
                    }else if(inputedflg == 1)   //グループ化
                    {
                        switch (getkind)
                        {
                            /*case "h1":
                                property_text.Text = "class :" + name;
                                break;
                            case "div":
                                property_text.Text = "class :" + name;
                                break;
                            case "table":
                                property_text.Text = "class :" + name;
                                break;
                            case "img":
                                property_text.Text = "class :" + name;
                                break;
                            case "url":
                                property_text.Text = "class :" + name;
                                break;
                            case "textbox":     //inputグループ内の部品のプロパティをinput内テキストボックスに表示
                                property_text2.Text = "class :" + name;
                                break;
                            case "button":      //inputグループ内の部品のプロパティをinput内テキストボックスに表示
                                property_text2.Text = "class :" + name;
                                break;*/
                            case "input":   //<input>部品を押したらgroup_inputに切り替え
                                flg = 8;
                                ButtonVisible();
                                break;
                            /*case "nav":
                                property_text.Text = "class :" + name;
                                break;
                            case "small":
                                property_text.Text = "class :" + name;
                                break;*/
                            default:
                                break;
                        }
                    }
                }//通常時
                else if(flg == 6)   //編集時
                {
                    switch (getkind)    //switch文にして、追加コンテンツ対策
                    {
                        case "input":   //inputグループ内の編集を可能にする
                            flg = 8;
                            ButtonVisible();
                            flg = 6;
                            break;
                    }
                }//flg==6編集時
                else if (flg == 5)
                {   //削除ボタン

                    if(getkind == "input")
                    {
                        flg = 8;
                        ButtonVisible();
                        flg = 5;
                    }
                    Control[] controls = Controls.Find(name, true);
                    foreach (Control control in controls)
                    {   //部品の削除処理
                        if (control.Name == "input_" + addInputCount)
                        {
                            DialogResult result = MessageBox.Show("この部品を削除すると、中に入っている部品も消されますが、よろしいですか？", "注意！",MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                            if(result == DialogResult.Yes)
                            {
                            inputedflg = 0;
                            inputflg = 0;
                                for (int i = inputedCount; i >= 1; i--)
                                {
                                    Control[] controls2 = Controls.Find("textbox_" + i, true);
                                    foreach (Control control2 in controls2)
                                    {
                                        OpenedName.Remove(flowLayoutPanel_input.Controls.GetChildIndex(control2)+1);
                                        OpenedTag.Remove(flowLayoutPanel_input.Controls.GetChildIndex(control2)+1);
                                        this.Controls.Remove(control2);
                                        control2.Dispose();
                                    }
                                    Control[] controls3 = Controls.Find("button_" + i, true);
                                    foreach (Control control3 in controls3)
                                    {
                                        OpenedName.Remove(flowLayoutPanel_input.Controls.GetChildIndex(control3)+1);
                                        OpenedTag.Remove(flowLayoutPanel_input.Controls.GetChildIndex(control3)+1);
                                        this.Controls.Remove(control3);
                                        control3.Dispose();
                                    }
                                }
                                inputedCount = 1;
                                flg = 5;
                                ButtonVisible();
                            }else if(result == DialogResult.No)
                            {
                                break;
                            }
                        }else if(control.Name == "link_" + addLinkCount)
                        {

                        }
                        this.Controls.Remove(control);
                        OpenedName.Remove(dic[name]);
                        OpenedTag.Remove(dic[name]);
                        dic.Remove(name);
                        control.Dispose();
                    }

                }//flg==5削除
                else if (flg == 7)
                {
                    
                    
                        //bodyグループ入れ替え処理
                        switch (contflg)
                        {   //選択回数
                            //1回目
                            case 0:
                                name1 = name;   //一つ目の部品の名前を保持
                                ctrl1 = cont;   //部品のコントロールを保持
                                if(flowLayoutPanel_body.Visible == true)
                                {
                                cont1 = flowLayoutPanel_body.Controls.GetChildIndex(cont);  //Body部品のFlowLayoutPanelのインデックスを保持
                                }else if(flowLayoutPanel_input.Visible == true)
                                {
                                cont1 = flowLayoutPanel_input.Controls.GetChildIndex(cont);  //input部品のFlowLayoutPanelのインデックスを保持
                                }
                                
                                contflg = 1;    //選択カウントを設定
                                break;
                            //二回目
                            case 1:
                                ctrl2 = cont;   //二つ目の部品の名前を保持
                                if (flowLayoutPanel_body.Visible == true)
                                {
                                    cont2 = flowLayoutPanel_body.Controls.GetChildIndex(cont);  //Body部品のFlowLayoutPanelのインデックスを保持
                                }
                                else if (flowLayoutPanel_input.Visible == true)
                                {
                                    cont2 = flowLayoutPanel_input.Controls.GetChildIndex(cont);  //input部品のFlowLayoutPanelのインデックスを保持
                                }
                                SwapControls(cont1, cont2, ctrl1, ctrl2);       //入れ替えメソッドの実行
                                contflg = 0;    //初期化
                                break;
                            default:
                                break;
                        }
                    
                    
                }//flg==7入れ替え
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
        private void SwapControls(int x, int y ,Control ctrl1, Control ctrl2)
        {
            

            //入れ替え処理
            if(flowLayoutPanel_body.Visible == true)
            {
                flowLayoutPanel_body.SuspendLayout();
                flowLayoutPanel_body.Controls.SetChildIndex(ctrl1, y);
                flowLayoutPanel_body.Controls.SetChildIndex(ctrl2, x);
                flowLayoutPanel_body.ResumeLayout();
            }
            else if(flowLayoutPanel_input.Visible == true)
            {
                flowLayoutPanel_input.SuspendLayout();
                flowLayoutPanel_input.Controls.SetChildIndex(ctrl1, y);
                flowLayoutPanel_input.Controls.SetChildIndex(ctrl2, x);
                flowLayoutPanel_input.ResumeLayout();
            }
            
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
        //---

        //---インプット系部品のグループ化
        private void GroupingInput(int textCount, int buttonCount)
        {
            DialogResult result = MessageBox.Show("ボタンやテキストボックスなどの部品をまとめますか？","Inputへのグループ化", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                inputedflg = 1;
                inputflg = 1;
                flg = 8;
                ButtonVisible();
                contflg = 0;
                try
                {
                    for (int i = textCount; i >= 1; i--)
                    {
                        Control[] controls1 = this.flowLayoutPanel_body.Controls.Find(dic2["textbox_" + i], true);
                        foreach (Control control in controls1)
                        {
                            this.flowLayoutPanel_input.Controls.Add(control);
                        }
                        inputedCount++;
                    }
                    for (int i = buttonCount;i >= 1; i--) { 
                        Control[] controls2 = this.flowLayoutPanel_body.Controls.Find(dic2["button_" + i], true);
                        foreach (Control control in controls2)
                        {
                            this.flowLayoutPanel_input.Controls.Add(control);
                        }
                        inputedCount++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("対象部品が追加されていません。", "エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                       
                
                
            }else if(result == DialogResult.No)
            {
                inputedflg = 0;
                inputflg = 0;
            }
        }

        private void save(Control control)
        {
            Properties.Settings.Default.Save();
        }

        //作業ファイルの保存リスナー＆処理
        private void button_save_Click(object sender, EventArgs e)
        {
            //統合時関係ないかも
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.Filter = "CSVファイル | *.csv";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.InitialDirectory = @"C:\Users\s3a2\Desktop";
            //---

            saveFileDialog1.ShowDialog();
            // csvファイルのパス
            var filePath = saveFileDialog1.FileName;
            //var filePath = @"C:\Users\s3a2\Desktop\"+title+".csv";   //パスは変える (作業ファイル名.csv)
            // csvに出力するデータ
            for(int i =0;i < OpenedTag.Count; i++)
            {
                int keyflag = 0;
                Array.Resize(ref csv1, csv1.Length + 1);
                Array.Resize(ref csv2, csv2.Length + 1);
                foreach(var key in OpenedTag.Keys)
                {
                    if(addLinkCount > 0)
                    {
                        keyflag = 1;
                        int tmp = i;
                        i += 1000;
                        csv1[i-1000] = OpenedTag[i];
                        csv2[i-1000] = OpenedName[i];
                        i = tmp;
                        addLinkCount--;
                        break;
                    }
                }
                if(keyflag == 0)
                {
                    csv1[i] = OpenedTag[i];
                    csv2[i] = OpenedName[i];
                }else
                {
                    keyflag = 0;
                }
                
            }
            // csvファイルの書き込み
            StreamWriter file = new StreamWriter(filePath,false,Encoding.UTF8);
            for (int i = 0; i <csv1.Length; i++)
            
                file.WriteLine(string.Format("{0},{1}", csv1[i],csv2[i])); // データ部出力
            

            file.Close();
            
        }

        

        //作業ファイル開くリスナー
        private void button_open_Click(object sender, EventArgs e)
        {
            //変数の初期化
            Reset();

            //統合時関係ないかも
            openFileDialog1.Filter = "CSVファイル | *.csv";
            openFileDialog1.InitialDirectory = @"C:\Users\s3a2\Desktop";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            title = openFileDialog1.SafeFileName;
            //---

            // csvファイルのパス
            var filePath = openFileDialog1.FileName;
            //var filePath = @"C:\Users\s3a2\Desktop\" + title + ".csv";

            // csvファイルの読込
            StreamReader reader = new StreamReader(File.OpenRead(filePath));
            
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                listTag.Add(values[0]);
                listName.Add(values[1]);
                
            }
            
            reader.Close();
            OpenProcess();
        }

        //作業ファイルを開いたときの処理
        private void OpenProcess()
        {
            int lc = 0;
            while (lc != listTag.Count)
            {
                //読み込んだcsvファイルを元にタグツリーの部品の生成
                switch (listTag[lc])
                {
                    //
                    case "h1":
                        AddTag(0,listName[lc]);
                        break;
                    case "div":
                        AddTag(1, listName[lc]);
                        break;
                    case "table":
                        AddTag(2, listName[lc]);
                        break;
                    case "img":
                        AddTag(3, listName[lc]);
                        break;
                    case "url":
                        AddTag(4, listName[lc]);
                        break;
                    case "textbox":
                        AddTag(5, listName[lc]);
                        break;
                    case "button":
                        AddTag(6, listName[lc]);
                        break;
                    case "nav":
                        AddTag(7, listName[lc]);
                        break;
                    case "input":
                        AddTag(8, listName[lc]);
                        break;
                    case "small":
                        AddTag(9, listName[lc]);
                        break;
                    case "link":
                        AddTag(10, listName[lc]);
                        break;
                }
                lc++;
            }
            
        }

        //タグツリーの部品追加処理（通常時）
        private void AddTag(int Index)
        {
            //タブツリーのBODYグループに部品のボタンを追加
            switch (Index)
            {
                //見出し
                case 0:
                    addH1Count++;                                                                   //見出し個数のカウント
                    Button button_h1 = new Button();                                                //新規ボタンのインスタンス                    //ボタンの配置場所の設定
                    button_h1.Size = new Size(122, 54);                                             //ボタンのサイズ
                    button_h1.ForeColor = Color.FromArgb(90, 92, 79);                               //ボタンの文字色の設定
                    button_h1.BackColor = Color.FromArgb(211,214,195);                              //ボタンの背景色の設定
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
                    save(button_h1);
                    break;
                //文
                case 1:
                    addDivCount++;
                    Button button_div = new Button();
                    button_div.Size = new Size(122, 54);
                    button_div.ForeColor = Color.FromArgb(90, 92, 79);
                    button_div.BackColor = Color.FromArgb(211, 214, 195);
                    button_div.FlatStyle = FlatStyle.Flat;
                    button_div.FlatAppearance.BorderSize = 0;
                    button_div.Text = "<DIV>";
                    button_div.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_div.Name = "div_" + addDivCount;
                    flowLayoutPanel_body.Controls.Add(button_div);
                    addBodyCount++;
                    dic.Add(button_div.Name, addBodyCount);
                    OpenedTag.Add(addBodyCount, "div");
                    OpenedName.Add(addBodyCount, button_div.Name.ToString());
                    button_div.Click += btnclick(button_div.Name, "div", dic[button_div.Name], addDivCount, button_div);
                    save(button_div);
                    break;
                //表
                case 2:
                    addTableCount++;
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
                    save(button_table);
                    break;
                //画像
                case 3:
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
                    save(button_img);
                    break;
                //URL
                case 4:
                    addUrlCount++;
                    Button button_url = new Button();
                    button_url.Size = new Size(122, 54);
                    button_url.ForeColor = Color.FromArgb(90, 92, 79);
                    button_url.BackColor = Color.FromArgb(211, 214, 195);
                    button_url.FlatStyle = FlatStyle.Flat;
                    button_url.FlatAppearance.BorderSize = 0;
                    button_url.Text = "<URL>";
                    button_url.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_url.Name = "url_" + addUrlCount;
                    flowLayoutPanel_body.Controls.Add(button_url);
                    addBodyCount++;
                    dic.Add(button_url.Name, addBodyCount);
                    OpenedTag.Add(addBodyCount, "url");
                    OpenedName.Add(addBodyCount, button_url.Name.ToString());
                    button_url.Click += btnclick(button_url.Name, "url", dic[button_url.Name], addUrlCount, button_url);
                    save(button_url);
                    break;
                //テキストボックス
                case 5:
                    addTextboxCount++;
                    Button button_textBox = new Button();
                    button_textBox.Size = new Size(122, 54);
                    button_textBox.ForeColor = Color.FromArgb(90, 92, 79);
                    button_textBox.BackColor = Color.FromArgb(211, 214, 195);
                    button_textBox.FlatStyle = FlatStyle.Flat;
                    button_textBox.FlatAppearance.BorderSize = 0;
                    button_textBox.Text = "<TEXTBOX>";
                    button_textBox.Font = new Font("MS UI Gothic", 12, FontStyle.Bold);
                    button_textBox.Name = "textbox_" + addTextboxCount;
                    if (inputflg == 0)
                    {
                        flowLayoutPanel_body.Controls.Add(button_textBox);
                        dic.Add(button_textBox.Name, addBodyCount);
                    }
                    else if (inputflg == 1)
                    {
                        flowLayoutPanel_input.Controls.Add(button_textBox);
                        dic.Add(button_textBox.Name, flowLayoutPanel_input.Controls.GetChildIndex(button_textBox));
                    }
                    addBodyCount++;
                    dic2.Add("textbox_" + addTextboxCount, button_textBox.Name);
                    OpenedTag.Add(addBodyCount, "textbox");
                    OpenedName.Add(addBodyCount, button_textBox.Name.ToString());
                    button_textBox.Click += btnclick(button_textBox.Name, "textbox", dic[button_textBox.Name], addTextboxCount, button_textBox);
                    save(button_textBox);
                    break;
                //ボタン
                case 6:
                    addButtonCount++;
                    Button button_Button = new Button();
                    button_Button.Size = new Size(122, 54);
                    button_Button.ForeColor = Color.FromArgb(90, 92, 79);
                    button_Button.BackColor = Color.FromArgb(211, 214, 195);
                    button_Button.FlatStyle = FlatStyle.Flat;
                    button_Button.FlatAppearance.BorderSize = 0;
                    button_Button.Text = "<BUTTON>";
                    button_Button.Font = new Font("MS UI Gothic", 12, FontStyle.Bold);
                    button_Button.Name = "button_" + addButtonCount;
                    if (inputflg == 0)
                    {
                        flowLayoutPanel_body.Controls.Add(button_Button);
                        dic.Add(button_Button.Name, addBodyCount);
                    }
                    else if (inputflg == 1)
                    {
                        flowLayoutPanel_input.Controls.Add(button_Button);
                        dic.Add(button_Button.Name, flowLayoutPanel_input.Controls.GetChildIndex(button_Button));
                    }
                    addBodyCount++;
                    dic2.Add("button_" + addButtonCount, button_Button.Name);
                    OpenedTag.Add(addBodyCount, "button");
                    OpenedName.Add(addBodyCount, button_Button.Name.ToString());
                    button_Button.Click += btnclick(button_Button.Name, "button", dic[button_Button.Name], addButtonCount, button_Button);
                    save(button_Button);
                    break;
                //ナビ
                case 7:
                    addNavCount++;
                    Button button_Nav = new Button();
                    button_Nav.Size = new Size(122, 54);
                    button_Nav.ForeColor = Color.FromArgb(90, 92, 79);
                    button_Nav.BackColor = Color.FromArgb(211, 214, 195);
                    button_Nav.FlatStyle = FlatStyle.Flat;
                    button_Nav.FlatAppearance.BorderSize = 0;
                    button_Nav.Text = "<NAV>";
                    button_Nav.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_Nav.Name = "nav_" + addNavCount;
                    flowLayoutPanel_body.Controls.Add(button_Nav);
                    addBodyCount++;
                    dic.Add(button_Nav.Name, addBodyCount);
                    OpenedTag.Add(addBodyCount, "nav");
                    OpenedName.Add(addBodyCount, button_Nav.Name.ToString());
                    button_Nav.Click += btnclick(button_Nav.Name, "nav", dic[button_Nav.Name], addButtonCount, button_Nav);
                    save(button_Nav);
                    break;

                //インプット
                case 8:
                    Button button_Input = new Button();
                    button_Input.Size = new Size(122, 54);
                    button_Input.ForeColor = Color.FromArgb(90, 92, 79);
                    button_Input.BackColor = Color.FromArgb(211, 214, 195);
                    button_Input.FlatStyle = FlatStyle.Flat;
                    button_Input.FlatAppearance.BorderSize = 0; 
                    button_Input.Text = "<INPUT>";
                    button_Input.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_Input.Name = "input_" + addInputCount;
                    if (inputedCount == 1)
                    {
                        if (inputedflg != 1)
                        {
                            flowLayoutPanel_body.Controls.Add(button_Input);
                            addBodyCount++;
                            dic.Add(button_Input.Name, addBodyCount);
                            OpenedTag.Add(addBodyCount, "input");
                            OpenedName.Add(addBodyCount, button_Input.Name.ToString());
                            button_Input.Click += btnclick(button_Input.Name, "input", dic[button_Input.Name], addInputCount, button_Input);
                            GroupingInput(addTextboxCount, addButtonCount);
                            inputedCount++;
                            save(button_Input);
                        }
                    }
                    else if (inputedCount >= 2 && inputedflg != 1)
                    {
                        GroupingInput(addTextboxCount, addButtonCount);
                    }
                    else
                    {
                        MessageBox.Show("すでに追加されています。");
                        break;
                    }

                    break;
                //スモール
                case 9:
                    addSmallCount++;
                    Button button_Small = new Button();
                    button_Small.Size = new Size(122, 54);
                    button_Small.ForeColor = Color.FromArgb(90, 92, 79);
                    button_Small.BackColor = Color.FromArgb(211, 214, 195);
                    button_Small.FlatStyle = FlatStyle.Flat;
                    button_Small.FlatAppearance.BorderSize = 0;
                    button_Small.Text = "<SMALL>";
                    button_Small.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_Small.Name = "small_" + addSmallCount;
                    flowLayoutPanel_body.Controls.Add(button_Small);
                    addBodyCount++;
                    dic.Add(button_Small.Name, addBodyCount);
                    OpenedTag.Add(addBodyCount, "small");
                    OpenedName.Add(addBodyCount, button_Small.Name.ToString());
                    button_Small.Click += btnclick(button_Small.Name, "small", dic[button_Small.Name], addButtonCount, button_Small);
                    save(button_Small);
                    break;
                //リンク
                case 10:
                    addLinkCount++;
                    Button button_Link = new Button();
                    button_Link.Size = new Size(122, 54);
                    button_Link.ForeColor = Color.FromArgb(90, 92, 79);
                    button_Link.BackColor = Color.FromArgb(211, 214, 195);
                    button_Link.FlatStyle = FlatStyle.Flat;
                    button_Link.FlatAppearance.BorderSize = 0;
                    button_Link.Text = "<LINK>";
                    button_Link.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_Link.Name = "link_" + addLinkCount;
                    flowLayoutPanel_head.Controls.Add(button_Link);
                    addBodyCount++;
                    dic.Add(button_Link.Name, addHeadCount + 999);
                    OpenedTag.Add(addHeadCount + 999, "link");
                    OpenedName.Add(addHeadCount + 999, button_Link.Name.ToString());
                    button_Link.Click += btnclick(button_Link.Name, "link", dic[button_Link.Name], addButtonCount, button_Link);
                    save(button_Link);
                    break;
                default:
                    break;
            }
        }
        //タグツリーの部品追加処理（作業ファイルを開いたとき）
        private void AddTag(int Index,String name)
        {
            //タブツリーのBODYグループに部品のボタンを追加
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
                    save(button_h1);
                    break;
                //文
                case 1:
                    addDivCount++;
                    Button button_div = new Button();
                    button_div.Size = new Size(122, 54);
                    button_div.ForeColor = Color.FromArgb(90, 92, 79);
                    button_div.BackColor = Color.FromArgb(211, 214, 195);
                    button_div.FlatStyle = FlatStyle.Flat;
                    button_div.FlatAppearance.BorderSize = 0;
                    button_div.Text = "<DIV>";
                    button_div.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_div.Name = name;
                    flowLayoutPanel_body.Controls.Add(button_div);
                    addBodyCount++;
                    dic.Add(button_div.Name, addBodyCount);
                    OpenedTag.Add(addBodyCount, "div");
                    OpenedName.Add(addBodyCount, button_div.Name.ToString());
                    button_div.Click += btnclick(button_div.Name, "div", dic[button_div.Name], addDivCount, button_div);
                    save(button_div);
                    break;
                //表
                case 2:
                    addTableCount++;
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
                    save(button_table);
                    break;
                //画像
                case 3:
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
                    save(button_img);
                    break;
                //URL
                case 4:
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
                    save(button_url);
                    break;
                //テキストボックス
                case 5:
                    addTextboxCount++;
                    Button button_textBox = new Button();
                    button_textBox.Size = new Size(122, 54);
                    button_textBox.ForeColor = Color.FromArgb(90, 92, 79);
                    button_textBox.BackColor = Color.FromArgb(211, 214, 195);
                    button_textBox.FlatStyle = FlatStyle.Flat;
                    button_textBox.FlatAppearance.BorderSize = 0;
                    button_textBox.Text = "<TEXTBOX>";
                    button_textBox.Font = new Font("MS UI Gothic", 12, FontStyle.Bold);
                    button_textBox.Name = name;
                    if (inputflg == 0)
                    {
                        flowLayoutPanel_body.Controls.Add(button_textBox);
                        dic.Add(button_textBox.Name, addBodyCount);
                    }
                    else if (inputflg == 1)
                    {
                        flowLayoutPanel_input.Controls.Add(button_textBox);
                        dic.Add(button_textBox.Name, flowLayoutPanel_input.Controls.GetChildIndex(button_textBox));
                    }
                    addBodyCount++;
                    dic2.Add("textbox_" + addTextboxCount, button_textBox.Name);
                    OpenedTag.Add(addBodyCount, "textbox");
                    OpenedName.Add(addBodyCount, button_textBox.Name.ToString());
                    button_textBox.Click += btnclick(button_textBox.Name, "textbox", dic[button_textBox.Name], addTextboxCount, button_textBox);
                    save(button_textBox);
                    break;
                //ボタン
                case 6:
                    addButtonCount++;
                    Button button_Button = new Button();
                    button_Button.Size = new Size(122, 54);
                    button_Button.ForeColor = Color.FromArgb(90, 92, 79);
                    button_Button.BackColor = Color.FromArgb(211, 214, 195);
                    button_Button.FlatStyle = FlatStyle.Flat;
                    button_Button.FlatAppearance.BorderSize = 0;
                    button_Button.Text = "<BUTTON>";
                    button_Button.Font = new Font("MS UI Gothic", 12, FontStyle.Bold);
                    button_Button.Name = name;
                    if (inputflg == 0)
                    {
                        flowLayoutPanel_body.Controls.Add(button_Button);
                        dic.Add(button_Button.Name, addBodyCount);
                    }
                    else if (inputflg == 1)
                    {
                        flowLayoutPanel_input.Controls.Add(button_Button);
                        dic.Add(button_Button.Name, flowLayoutPanel_input.Controls.GetChildIndex(button_Button));
                    }
                    addBodyCount++;
                    dic2.Add("button_" + addButtonCount, button_Button.Name);
                    OpenedTag.Add(addBodyCount, "button");
                    OpenedName.Add(addBodyCount, button_Button.Name.ToString());
                    button_Button.Click += btnclick(button_Button.Name, "button", dic[button_Button.Name], addButtonCount, button_Button);
                    save(button_Button);
                    break;
                //ナビ
                case 7:
                    addNavCount++;
                    Button button_Nav = new Button();
                    button_Nav.Size = new Size(122, 54);
                    button_Nav.ForeColor = Color.FromArgb(90, 92, 79);
                    button_Nav.BackColor = Color.FromArgb(211, 214, 195);
                    button_Nav.FlatStyle = FlatStyle.Flat;
                    button_Nav.FlatAppearance.BorderSize = 0;
                    button_Nav.Text = "<NAV>";
                    button_Nav.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_Nav.Name = name;
                    flowLayoutPanel_body.Controls.Add(button_Nav);
                    addBodyCount++;
                    dic.Add(button_Nav.Name, addBodyCount);
                    OpenedTag.Add(addBodyCount, "nav");
                    OpenedName.Add(addBodyCount, button_Nav.Name.ToString());
                    button_Nav.Click += btnclick(button_Nav.Name, "nav", dic[button_Nav.Name], addButtonCount, button_Nav);
                    save(button_Nav);
                    break;

                //インプット
                case 8:
                    Button button_Input = new Button();
                    button_Input.Size = new Size(122, 54);
                    button_Input.ForeColor = Color.FromArgb(90, 92, 79);
                    button_Input.BackColor = Color.FromArgb(211, 214, 195);
                    button_Input.FlatStyle = FlatStyle.Flat;
                    button_Input.FlatAppearance.BorderSize = 0;
                    button_Input.Text = "<INPUT>";
                    button_Input.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_Input.Name = name;
                    if (inputedCount == 1)
                    {
                        if (inputedflg != 1)
                        {
                            flowLayoutPanel_body.Controls.Add(button_Input);
                            addBodyCount++;
                            dic.Add(button_Input.Name, addBodyCount);
                            OpenedTag.Add(addBodyCount, "input");
                            OpenedName.Add(addBodyCount, button_Input.Name.ToString());
                            button_Input.Click += btnclick(button_Input.Name, "input", dic[button_Input.Name], addInputCount, button_Input);
                            GroupingInput(addTextboxCount, addButtonCount);
                            inputedCount++;
                            save(button_Input);
                        }
                    }
                    else if (inputedCount >= 2 && inputedflg != 1)
                    {
                        GroupingInput(addTextboxCount, addButtonCount);
                    }
                    else
                    {
                        MessageBox.Show("すでに追加されています。");
                        break;
                    }

                    break;
                //スモール
                case 9:
                    addSmallCount++;
                    Button button_Small = new Button();
                    button_Small.Size = new Size(122, 54);
                    button_Small.ForeColor = Color.FromArgb(90, 92, 79);
                    button_Small.BackColor = Color.FromArgb(211, 214, 195);
                    button_Small.FlatStyle = FlatStyle.Flat;
                    button_Small.FlatAppearance.BorderSize = 0;
                    button_Small.Text = "<SMALL>";
                    button_Small.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_Small.Name = name;
                    flowLayoutPanel_body.Controls.Add(button_Small);
                    addBodyCount++;
                    dic.Add(button_Small.Name, addBodyCount);
                    OpenedTag.Add(addBodyCount, "small");
                    OpenedName.Add(addBodyCount, button_Small.Name.ToString());
                    button_Small.Click += btnclick(button_Small.Name, "small", dic[button_Small.Name], addButtonCount, button_Small);
                    save(button_Small);
                    break;
                //リンク
                case 10:
                    addLinkCount++;
                    Button button_Link = new Button();
                    button_Link.Size = new Size(122, 54);
                    button_Link.ForeColor = Color.FromArgb(90, 92, 79);
                    button_Link.BackColor = Color.FromArgb(211, 214, 195);
                    button_Link.FlatStyle = FlatStyle.Flat;
                    button_Link.FlatAppearance.BorderSize = 0;
                    button_Link.Text = "<LINK>";
                    button_Link.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_Link.Name = name;
                    flowLayoutPanel_head.Controls.Add(button_Link);
                    addHeadCount++;
                    dic.Add(button_Link.Name, addHeadCount + 999);
                    OpenedTag.Add(addHeadCount + 999, "link");
                    OpenedName.Add(addHeadCount + 999, button_Link.Name.ToString());
                    button_Link.Click += btnclick(button_Link.Name, "link", dic[button_Link.Name], addButtonCount, button_Link);
                    save(button_Link);
                    break;
                default:
                    break;
            }
        }
    }
}
