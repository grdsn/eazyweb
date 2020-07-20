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

namespace eazyweb
{
    public partial class Form1 : Form
    {
        //画面フラグ
        public int flg = 0;
        //入れ替え部品
        public int contflg = 0;
        public int BCount1 = 0;
        public int BCount2 = 0;
        public int ItemCount1 = 0;
        public int ItemCount2 = 0;
        public Dictionary<String,int> dic = new Dictionary<string, int>() { { "", 0 } };
        public String name1 = "";
        public String name2 = "";
        //追加部品のカウント
        public int addHeadCount = 2;
        public int addBodyCount = 1;
        public int addH1Count = 0;
        public int addPCount = 0;
        public int addTableCount = 0;
        public int addImgCount = 0;
        public int addUrlCount = 0;
        public int addTextboxCount = 0;
        public int addButtonCount = 0;


        //ボタンイベントの有無
        public Boolean button_event = false;

        public String openFile = "";
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
                    this.group_tag.Visible = true;
                    this.groupHead.Visible = false;
                    this.groupBody.Visible = false;
                    this.button_delete.Visible = false;
                    this.button_swap.Visible = false;
                    contflg = 0;
                    break;
                //HEADボタン
                case 1:
                    this.groupHead.Visible = true;
                    this.groupBody.Visible = false;
                    this.groupHead.BackColor = Color.FromArgb(128, 128, 255);
                    this.button_delete.Visible = false;
                    this.button_swap.Visible = false;
                    contflg = 0;
                    break;
                //BDOYボタン
                case 2:
                    this.groupHead.Visible = false;
                    this.groupBody.Visible = true;
                    this.groupBody.BackColor = Color.FromArgb(192, 255, 255);
                    this.tableLayoutPanel1.BackColor = Color.FromArgb(192, 255, 255);
                    this.button_delete.Visible = false;
                    this.button_swap.Visible = false;
                    contflg = 0;
                    break;
                //削除ボタン
                case 5:
                    this.groupHead.Visible = false;
                    this.groupBody.Visible = true;
                    this.groupBody.BackColor = Color.FromName("Red");
                    this.tableLayoutPanel1.BackColor = Color.FromName("Red");
                    contflg = 0;
                    break;
                //編集ボタン
                case 6:
                    this.groupHead.Visible = false;
                    this.groupBody.Visible = true;
                    this.groupBody.BackColor = Color.FromArgb(0, 192, 0);
                    this.tableLayoutPanel1.BackColor = Color.FromArgb(0, 192, 0);
                    this.button_delete.Visible = true;
                    this.button_swap.Visible = true;
                    contflg = 0;
                    break;
                //入れ替え
                case 7:
                    this.groupHead.Visible = false;
                    this.groupBody.Visible = true;
                    //this.groupBody.BackColor = Color.FromArgb(0, 192, 0);
                    //this.tableLayoutPanel1.BackColor = Color.FromArgb(0, 192, 0);
                    this.button_delete.Visible = false;
                    break;
                //例外
                default:
                    this.group_tag.Visible = true;
                    this.groupHead.Visible = false;
                    this.groupBody.Visible = false;
                    this.button_delete.Visible = false;
                    this.button_swap.Visible = false;
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

        //タグ一覧ボタン処理
        private void button_tag_Click(object sender, EventArgs e)
        {
            /*if(this.listItem.Visible == false)
            {
                this.listItem.Visible = true;
            }else if(this.listItem.Visible == true)
            {
                this.listItem.Visible = false;
            }*/
            
        }
        //---

        //Formロード時処理
        private void Form1_Load(object sender, EventArgs e)
        {
            //---タグ一覧のリスト処理
            String [] Item = { "見出し","文","表","画像","URL","テキストボックス","ボタン" };

            foreach (String addItem in Item){
                listItem.Items.Add(addItem);
            }
            //---

            //---BODYタグツリーのスクロール
            this.tableLayoutPanel1.VerticalScroll.Visible = true;
            this.tableLayoutPanel1.AutoScroll = true;
            //---
        }
        //---

        //部品一覧の部品選択時の処理
        private void listItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //タブツリーのBODYグループに部品のボタンを追加
            switch (listItem.SelectedIndex)
            {
                //見出し
                case 0:
                    addH1Count++;                                                                   //見出し個数のカウント
                    Button button_h1 = new Button();                                                //新規ボタンのインスタンス
                    button_h1.Location = new Point(0, 20 + addBodyCount * 78);                      //ボタンの配置場所の設定
                    button_h1.Size = new Size(122, 54);                                             //ボタンのサイズ
                    button_h1.ForeColor = Color.FromName("White");                                  //ボタンの文字色の設定
                    button_h1.BackColor = Color.FromName("DodgerBlue");                             //ボタンの背景色の設定
                    button_h1.Text = "<H1>";                                                        //ボタンのテキスト
                    button_h1.Font = new Font("MS UI Gothic", 18,FontStyle.Bold);                   //フォントの設定
                    button_h1.Name = "button_h1_" + addH1Count;                                     //ボタンのNameの設定
                    if (tableLayoutPanel1.GetControlFromPosition(0, addBodyCount) == null)          //tableLayoutPanel1に空きがあればボタンを配置
                    {
                        tableLayoutPanel1.Controls.Add(button_h1);
                    }
                    else
                    {                                                                               //なければ行の追加
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
                        tableLayoutPanel1.Controls.Add(button_h1);
                    }
                    addBodyCount++;                                                                 //BODYの個数のカウント
                    dic.Add(button_h1.Name, addBodyCount);
                    button_h1.Click += btnclick(button_h1.Name,"h1",dic[button_h1.Name], addH1Count);                  //追加したボタンにイベントを追加
                    //this.listItem.Visible = false;                                                //追加完了後、部品リストを非表示
                    break;
                //文
                case 1:
                    addPCount++;
                    Button button_p = new Button();
                    button_p.Location = new Point(0, 20 + addBodyCount * 78);
                    button_p.Size = new Size(122, 54);
                    button_p.ForeColor = Color.FromName("White");
                    button_p.BackColor = Color.FromName("DodgerBlue");
                    button_p.Text = "<P>";
                    button_p.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_p.Name = "button_p_" + addPCount;
                    if (tableLayoutPanel1.GetControlFromPosition(addBodyCount, 0) == null)
                    {
                        tableLayoutPanel1.Controls.Add(button_p);
                    }
                    else
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
                        tableLayoutPanel1.Controls.Add(button_p);
                    }

                    addBodyCount++;
                    dic.Add(button_p.Name, addBodyCount);
                    button_p.Click += btnclick(button_p.Name,"p", dic[button_p.Name], addPCount);
                    
                    //this.listItem.Visible = false;
                    break;
                //表
                case 2:
                    addTableCount++;
                    Button button_table = new Button();
                    button_table.Location = new Point(0, 20 + addBodyCount * 78);
                    button_table.Size = new Size(122, 54);
                    button_table.ForeColor = Color.FromName("White");
                    button_table.BackColor = Color.FromName("DodgerBlue");
                    button_table.Text = "<TABLE>";
                    button_table.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_table.Name = "button_table_" + addTableCount;
                    if (tableLayoutPanel1.GetControlFromPosition(addBodyCount, 0) == null)
                    {
                        tableLayoutPanel1.Controls.Add(button_table);
                    }
                    else
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
                        tableLayoutPanel1.Controls.Add(button_table);
                    }
                    addBodyCount++;
                    dic.Add(button_table.Name, addBodyCount);
                    button_table.Click += btnclick(button_table.Name,"table" , dic[button_table.Name], addTableCount);
                    //this.listItem.Visible = false;
                    break;
                //画像
                case 3:
                    addImgCount++;
                    Button button_img = new Button();
                    button_img.Location = new Point(0, 20 + addBodyCount * 78);
                    button_img.Size = new Size(122, 54);
                    button_img.ForeColor = Color.FromName("White");
                    button_img.BackColor = Color.FromName("DodgerBlue");
                    button_img.Text = "<IMG>";
                    button_img.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_img.Name = "button_img_" + addImgCount;
                    if (tableLayoutPanel1.GetControlFromPosition(addBodyCount, 0) == null)
                    {
                        tableLayoutPanel1.Controls.Add(button_img);
                    }
                    else
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
                        tableLayoutPanel1.Controls.Add(button_img);
                    }
                    addBodyCount++;
                    dic.Add(button_img.Name, addBodyCount);
                    button_img.Click += btnclick(button_img.Name,"img", dic[button_img.Name], addImgCount);
                    //this.listItem.Visible = false;
                    break;
                //URL
                case 4:
                    addUrlCount++;
                    Button button_url = new Button();
                    button_url.Location = new Point(0, 20 + addBodyCount * 78);
                    button_url.Size = new Size(122, 54);
                    button_url.ForeColor = Color.FromName("White");
                    button_url.BackColor = Color.FromName("DodgerBlue");
                    button_url.Text = "<URL>";
                    button_url.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_url.Name = "button_url_" + addUrlCount;
                    if (tableLayoutPanel1.GetControlFromPosition(addBodyCount, 0) == null)
                    {
                        tableLayoutPanel1.Controls.Add(button_url);
                    }
                    else
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
                        tableLayoutPanel1.Controls.Add(button_url);
                    }
                    addBodyCount++;
                    dic.Add(button_url.Name, addBodyCount);
                    button_url.Click += btnclick(button_url.Name,"url", dic[button_url.Name], addUrlCount);
                    //this.listItem.Visible = false;
                    break;
                //テキストボックス
                case 5:
                    addTextboxCount++;
                    Button button_textBox = new Button();
                    button_textBox.Location = new Point(0, 20 + addBodyCount * 78);
                    button_textBox.Size = new Size(122, 54);
                    button_textBox.ForeColor = Color.FromName("White");
                    button_textBox.BackColor = Color.FromName("DodgerBlue");
                    button_textBox.Text = "<TEXTBOX>";
                    button_textBox.Font = new Font("MS UI Gothic", 12, FontStyle.Bold);
                    button_textBox.Name = "button_textbox_" + addTextboxCount;
                    if (tableLayoutPanel1.GetControlFromPosition(addBodyCount, 0) == null)
                    {
                        tableLayoutPanel1.Controls.Add(button_textBox);
                    }
                    else
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
                        tableLayoutPanel1.Controls.Add(button_textBox);
                    }
                    addBodyCount++;
                    dic.Add(button_textBox.Name, addBodyCount);
                    button_textBox.Click += btnclick(button_textBox.Name,"textbox", dic[button_textBox.Name], addTextboxCount);
                    //this.listItem.Visible = false;
                    break;
                //ボタン
                case 6:
                    addButtonCount++;
                    Button button_Button = new Button();
                    button_Button.Location = new Point(0, 20 + addBodyCount * 78);
                    button_Button.Size = new Size(122, 54);
                    button_Button.ForeColor = Color.FromName("White");
                    button_Button.BackColor = Color.FromName("DodgerBlue");
                    button_Button.Text = "<BUTTON>";
                    button_Button.Font = new Font("MS UI Gothic", 12, FontStyle.Bold);
                    button_Button.Name = "button_button_" + addButtonCount;
                    if (tableLayoutPanel1.GetControlFromPosition(addBodyCount, 0) == null)
                    {
                        tableLayoutPanel1.Controls.Add(button_Button);
                    }
                    else
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
                        tableLayoutPanel1.Controls.Add(button_Button);
                    }
                    addBodyCount++;
                    dic.Add(button_Button.Name, addBodyCount);
                    button_Button.Click += btnclick(button_Button.Name,"button_button", dic[button_Button.Name], addButtonCount);
                    //this.listItem.Visible = false;
                    break;
                default:
                    break;
            }
        }



        private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = "index.html";
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = @"C:\Users\s3a2\source\repos\eazyweb\eazyweb\bin\Debug\HTML";
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //1番目の「html」が選択されているようにする
            ofd.FilterIndex = 1;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                //Console.WriteLine(ofd.FileName);
                openFile = ofd.FileName;
            }
            //ファイルを読み込む用
            try
            {
                System.IO.Stream stream;
                stream = ofd.OpenFile();
                if (stream != null)
                {
                    //内容を読み込み、表示する
                    System.IO.StreamReader sr =
                        new System.IO.StreamReader(stream);
                    //this.editBox.Text = sr.ReadToEnd();
                    //閉じる
                    sr.Close();
                    stream.Close();
                }
            }catch(Exception ex)
            {

            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 文字コードを指定
            Encoding enc = Encoding.GetEncoding("UTF-8");

            // テキストを書き込む
            //File.WriteAllText(openFile, this.editBox.Text,enc);


        }

        //---編集ボタンを押したとき
        private void button_edit_Click_1(object sender, EventArgs e)
        {

            flg = 6;
            ButtonVisible();
            //MessageBox.Show();
        }
        //---

        //---動的ボタンのイベント(引数：部品名、部品の種類)
        private EventHandler btnclick(String name,String getkind,int BodyCount, int itemCount)
        {               
            return delegate (object sender2, EventArgs e2)
            {
                String nname = "";
                String cntName = name;
                String kind = getkind;
                int temp = 0;
                

                if (flg != 6 && flg != 5 && flg != 7)
                {   //通常時の処理
                    //選択したボタンのプロパティを表示


                    switch (kind)
                    {
                        case "h1":
                            property_text.Text = "name : " + name;
                            break;
                        case "p":
                            property_text.Text = "name :" + name;
                            break;
                        case "table":

                            break;
                        case "img":

                            break;
                        case "url":

                            break;
                        case "textbox":

                            break;
                        case "button_button":

                            break;
                        default:
                            break;
                    }
                }
                else if (flg == 5)
                {   //押されている

                    Control[] controls = Controls.Find(name, true);
                    foreach (Control control in controls)
                    {   //部品の削除処理
                        this.Controls.Remove(control);
                        control.Dispose();
                        dic.Remove(name);
                        addBodyCount--;
                        switch (kind)
                        {
                            case "h1":
                                addH1Count--;
                                break;
                            case "p":
                                addPCount--;
                                break;
                            case "table":
                                addTableCount--;
                                break;
                            case "img":
                                addImgCount--;
                                break;
                            case "url":
                                addUrlCount--;
                                break;
                            case "textbox":
                                addTextboxCount--;
                                break;
                            case "button_button":
                                addButtonCount--;
                                break;
                            default:
                                break;
                        }
                        


                    }


                }
                else if (flg == 7)
                {

                    //入れ替え処理
                    switch (contflg)
                    {   //選択回数
                        //1回目
                        case 0:
                            dic[name] = BodyCount - 1;
                            name1 = name;
                            //BCount1 = BodyCount;        //一個目の部品の行目を保持
                            //ItemCount1 = itemCount;     //わからないやつ   
                            contflg = 1;                //選択カウントを設定
                            break;
                        //二回目
                        case 1:
                            dic[name] = BodyCount - 1;
                            name2 = name;
                            //BCount2 = BodyCount;        //二個目の部品の行目を保持  
                            //ItemCount2 = itemCount;     //わからないやつ
                            SwapControls(this.tableLayoutPanel1, new TableLayoutPanelCellPosition(0, dic[name1]), new TableLayoutPanelCellPosition(0, dic[name2]));       //入れ替えメソッドの実行                            
                            BCount1 = 0;                //
                            BCount2 = 0;                //初期化
                            contflg = 0;                //
                            SwapCellPosition(name1, name2); //セルポジションの入れ替え関数
                            break;
                        default:
                            break;
                    }
                    /*if (contflg == 0)
                    {
                        BCount1 = BodyCount;
                        contflg = 1;
                    }else if(contflg == 1)
                    {
                        BCount2 = BodyCount;
                        contflg = 2;
                    }else if(contflg == 2)
                    {   contflg = 0;
                        SwapControls(this.tableLayoutPanel1, new TableLayoutPanelCellPosition(0, BCount1), new TableLayoutPanelCellPosition(0, BCount2));
                        
                    }
                    */
                    
                }


            };
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            flg = 5;
            ButtonVisible();
        }

        private void button_swap_Click(object sender, EventArgs e)
        {
            flg = 7;
            ButtonVisible();
            /*for (int i = 0; i < 10; i++) { 
                checkedListBox1.Items.Add(item[i]);
            }
            //並び替えしたい
            /*Control[] controls = Controls.Find(name, true);
            foreach (Control control in controls)
            {
                MessageBox.Show(tableLayoutPanel1.GetCellPosition(control).ToString());
                nname = control.Name;
            }

           Control c1 = this.tableLayoutPanel1.GetControlFromPosition(0,1);
            Control c2 = this.tableLayoutPanel1.GetControlFromPosition(0, 2);

            MessageBox.Show(c1.ToString() + "安堵" + c2.ToString());
            if(c1 != null && c2 != null)
            {
                this.tableLayoutPanel1.SetRow(c1,2);
                this.tableLayoutPanel1.SetRow(c2,1);
            }
            */
            
        }

        //入れ替え処理メソッド
        private void SwapControls(TableLayoutPanel tlp, TableLayoutPanelCellPosition cpos1, TableLayoutPanelCellPosition cpos2)
        {
            var ctl1 = tlp.GetControlFromPosition(0, cpos1.Row);
            var ctl2 = tlp.GetControlFromPosition(0, cpos2.Row);
            if (ctl1 != null) // position1 can be empty
                tlp.SetCellPosition(ctl1, cpos2);
            if (ctl2 != null) // position2 can be empty
                tlp.SetCellPosition(ctl2, cpos1);
        }

       private void SwapCellPosition(String name1,String name2)
        {
            MessageBox.Show(dic[name1].ToString() + dic[name2].ToString());
            var temp = dic[name1];      //
            dic[name1] = dic[name2];    //セルのポジションの入れ替え
            dic[name2] = temp;          //
            MessageBox.Show(dic[name1].ToString() + dic[name2].ToString());
        }
        //---
    }
}
