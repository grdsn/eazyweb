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

        public int cont1 = 0;
        public int cont2 = 0;

        Control ctrl1;
        Control ctrl2;

        //ボタンイベントの有無
        public Boolean button_event = false;
       
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
                    this.button_delete.Visible = false;
                    this.button_swap.Visible = false;
                    contflg = 0;
                    break;
                //削除ボタン
                case 5:
                    this.groupHead.Visible = false;
                    this.groupBody.Visible = true;
                    this.groupBody.BackColor = Color.FromName("Red");
                    contflg = 0;
                    break;
                //編集ボタン
                case 6:
                    this.groupHead.Visible = false;
                    this.groupBody.Visible = true;
                    this.groupBody.BackColor = Color.FromArgb(0, 192, 0);
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
            this.flowLayoutPanel1.VerticalScroll.Visible = true;
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
                    Button button_h1 = new Button();                                                //新規ボタンのインスタンス                    //ボタンの配置場所の設定
                    button_h1.Size = new Size(122, 54);                                             //ボタンのサイズ
                    button_h1.ForeColor = Color.FromName("White");                                  //ボタンの文字色の設定
                    button_h1.BackColor = Color.FromName("DodgerBlue");                             //ボタンの背景色の設定
                    button_h1.Text = "<H1>";                                                        //ボタンのテキスト
                    button_h1.Font = new Font("MS UI Gothic", 18,FontStyle.Bold);                   //フォントの設定
                    button_h1.Name = "button_h1_" + addH1Count;                                     //ボタンのNameの設定
                    flowLayoutPanel1.Controls.Add(button_h1);
                    addBodyCount++;                                                                 //BODYの個数のカウント
                    dic.Add(button_h1.Name, flowLayoutPanel1.Controls.GetChildIndex(button_h1));
                    button_h1.Click += btnclick(button_h1.Name,"h1",dic[button_h1.Name], addH1Count,button_h1);                  //追加したボタンにイベントを追加
                    break;
                //文
                case 1:
                    addPCount++;
                    Button button_p = new Button();
                    button_p.Size = new Size(122, 54);
                    button_p.ForeColor = Color.FromName("White");
                    button_p.BackColor = Color.FromName("DodgerBlue");
                    button_p.Text = "<P>";
                    button_p.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_p.Name = "button_p_" + addPCount;
                    flowLayoutPanel1.Controls.Add(button_p);
                    addBodyCount++;
                    dic.Add(button_p.Name, flowLayoutPanel1.Controls.GetChildIndex(button_p));
                    button_p.Click += btnclick(button_p.Name,"p", dic[button_p.Name], addPCount, button_p);
                    break;
                //表
                case 2:
                    addTableCount++;
                    Button button_table = new Button();
                    button_table.Size = new Size(122, 54);
                    button_table.ForeColor = Color.FromName("White");
                    button_table.BackColor = Color.FromName("DodgerBlue");
                    button_table.Text = "<TABLE>";
                    button_table.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_table.Name = "button_table_" + addTableCount;
                    flowLayoutPanel1.Controls.Add(button_table);
                    addBodyCount++;
                    dic.Add(button_table.Name, flowLayoutPanel1.Controls.GetChildIndex(button_table));
                    button_table.Click += btnclick(button_table.Name,"table" , dic[button_table.Name], addTableCount, button_table);
                    break;
                //画像
                case 3:
                    addImgCount++;
                    Button button_img = new Button();
                    button_img.Size = new Size(122, 54);
                    button_img.ForeColor = Color.FromName("White");
                    button_img.BackColor = Color.FromName("DodgerBlue");
                    button_img.Text = "<IMG>";
                    button_img.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_img.Name = "button_img_" + addImgCount;
                    flowLayoutPanel1.Controls.Add(button_img);
                    addBodyCount++;
                    dic.Add(button_img.Name, flowLayoutPanel1.Controls.GetChildIndex(button_img));
                    button_img.Click += btnclick(button_img.Name,"img", dic[button_img.Name], addImgCount, button_img);
                    break;
                //URL
                case 4:
                    addUrlCount++;
                    Button button_url = new Button();
                    button_url.Size = new Size(122, 54);
                    button_url.ForeColor = Color.FromName("White");
                    button_url.BackColor = Color.FromName("DodgerBlue");
                    button_url.Text = "<URL>";
                    button_url.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_url.Name = "button_url_" + addUrlCount;
                    flowLayoutPanel1.Controls.Add(button_url);
                    addBodyCount++;
                    dic.Add(button_url.Name, flowLayoutPanel1.Controls.GetChildIndex(button_url));
                    button_url.Click += btnclick(button_url.Name,"url", dic[button_url.Name], addUrlCount, button_url);
                    break;
                //テキストボックス
                case 5:
                    addTextboxCount++;
                    Button button_textBox = new Button();
                    button_textBox.Size = new Size(122, 54);
                    button_textBox.ForeColor = Color.FromName("White");
                    button_textBox.BackColor = Color.FromName("DodgerBlue");
                    button_textBox.Text = "<TEXTBOX>";
                    button_textBox.Font = new Font("MS UI Gothic", 12, FontStyle.Bold);
                    button_textBox.Name = "button_textbox_" + addTextboxCount;
                    flowLayoutPanel1.Controls.Add(button_textBox);
                    addBodyCount++;
                    dic.Add(button_textBox.Name, flowLayoutPanel1.Controls.GetChildIndex(button_textBox));
                    button_textBox.Click += btnclick(button_textBox.Name,"textbox", dic[button_textBox.Name], addTextboxCount,button_textBox);
                    break;
                //ボタン
                case 6:
                    addButtonCount++;
                    Button button_Button = new Button();
                    button_Button.Size = new Size(122, 54);
                    button_Button.ForeColor = Color.FromName("White");
                    button_Button.BackColor = Color.FromName("DodgerBlue");
                    button_Button.Text = "<BUTTON>";
                    button_Button.Font = new Font("MS UI Gothic", 12, FontStyle.Bold);
                    button_Button.Name = "button_button_" + addButtonCount;
                    flowLayoutPanel1.Controls.Add(button_Button);
                    addBodyCount++;
                    dic.Add(button_Button.Name, flowLayoutPanel1.Controls.GetChildIndex(button_Button));
                    button_Button.Click += btnclick(button_Button.Name,"button_button", dic[button_Button.Name], addButtonCount, button_Button);
                    break;
                default:
                    break;
            }
        }
        //---

        //---編集ボタンを押したとき
        private void button_edit_Click_1(object sender, EventArgs e)
        {

            flg = 6;
            ButtonVisible();
        }
        //---

        //---動的ボタンのイベント(引数：部品名、部品の種類、追加カウント、アイテムカウント、部品)
        private EventHandler btnclick(String name,String getkind,int BodyCount, int itemCount, Control cont)
        {               
            return delegate (object sender2, EventArgs e2)
            {

                if (flg != 6 && flg != 5 && flg != 7)
                {   //通常時の処理
                    //選択したボタンのプロパティを表示


                    switch (getkind)
                    {
                        case "h1":
                            property_text.Text = "name : " + name;
                            break;
                        case "p":
                            property_text.Text = "name :" + name;
                            break;
                        case "table":
                            property_text.Text = "name :" + name;
                            break;
                        case "img":
                            property_text.Text = "name :" + name;
                            break;
                        case "url":
                            property_text.Text = "name :" + name;
                            break;
                        case "textbox":
                            property_text.Text = "name :" + name;
                            break;
                        case "button_button":
                            property_text.Text = "name :" + name;
                            break;
                        default:
                            break;
                    }
                }//通常時
                else if (flg == 5)
                {   //押されている

                    Control[] controls = Controls.Find(name, true);
                    foreach (Control control in controls)
                    {   //部品の削除処理
                        this.Controls.Remove(control);
                        control.Dispose();
                        dic.Remove(name);
                        addBodyCount--;
                        switch (getkind)
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


                }//flg==5
                else if (flg == 7)
                {
                    
                    //入れ替え処理
                    switch (contflg)
                    {   //選択回数
                        //1回目
                        case 0:
                            name1 = name;   //一つ目の部品の名前を保持
                            ctrl1 = cont;   //部品のコントロールを保持
                            cont1 = flowLayoutPanel1.Controls.GetChildIndex(cont);  //部品のFlowLayoutPanelのインデックスを保持
                            contflg = 1;    //選択カウントを設定
                            break;
                        //二回目
                        case 1:
                            ctrl2 = cont;   //二つ目の部品の名前を保持
                            cont2 = flowLayoutPanel1.Controls.GetChildIndex(cont);  //部品のFlowLayoutPanelのインデックスを保持
                            SwapControls(cont1,cont2,ctrl1,ctrl2);       //入れ替えメソッドの実行
                            contflg = 0;    //初期化
                            break;
                        default:
                            break;
                    }
                }//flg==7
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
        //---

        //---入れ替え処理メソッド
        private void SwapControls(int x, int y ,Control ctrl1, Control ctrl2)
        {
            flowLayoutPanel1.SuspendLayout();

            //入れ替え処理
            flowLayoutPanel1.Controls.SetChildIndex(ctrl1, y);
            flowLayoutPanel1.Controls.SetChildIndex(ctrl2, x);

            flowLayoutPanel1.ResumeLayout();
        }
        //---
    }
}
