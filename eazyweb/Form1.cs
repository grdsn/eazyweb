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
        //編集フラグ
        public int editflg = 0;
        //入れ替え部品
        public int contflg = 0;
        public int BCount1 = 0;
        public int BCount2 = 0;
        public int ItemCount1 = 0;
        public int ItemCount2 = 0;
        public Dictionary<String,int> dic = new Dictionary<string, int>() { { "", 0 } };
        public Dictionary<String, String> dic2 = new Dictionary<string, string>() { { "", "" } };
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
        public int addNavCount = 0;
        public int addInputCount = 1;
        public int addSmallCount = 0;
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
                    this.groupInput.Visible = false;
                    contflg = 0;
                    break;
                //HEADボタン
                case 1:
                    this.groupHead.Visible = true;
                    this.groupBody.Visible = false;
                    this.groupHead.BackColor = Color.FromArgb(128, 128, 255);
                    this.button_delete.Visible = false;
                    this.button_swap.Visible = false;
                    this.groupInput.Visible = false;
                    contflg = 0;
                    break;
                //BDOYボタン
                case 2:
                    this.groupHead.Visible = false;
                    this.groupBody.Visible = true;
                    this.groupBody.BackColor = Color.FromArgb(192, 255, 255);
                    this.button_delete.Visible = false;
                    this.button_swap.Visible = false;
                    this.groupInput.Visible = false;
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
                        this.groupBody.BackColor = Color.FromName("Red");
                        contflg = 0;
                        break;
                    }
                //編集ボタン
                case 6:
                    this.groupHead.Visible = false;
                    this.groupBody.Visible = true;
                    this.groupBody.BackColor = Color.FromArgb(0, 192, 0);
                    this.button_delete.Visible = true;
                    this.button_swap.Visible = true;
                    this.groupInput.Visible = false;
                    contflg = 0;
                    break;
                //入れ替え
                case 7:
                    this.groupHead.Visible = false;
                    this.groupBody.Visible = true;
                    this.groupInput.Visible = false;
                    //this.groupBody.BackColor = Color.FromArgb(0, 192, 0);
                    //this.tableLayoutPanel1.BackColor = Color.FromArgb(0, 192, 0);
                    //this.button_delete.Visible = false;
                    break;
                //インプット
                case 8:
                    this.groupBody.Visible = false;
                    this.groupHead.Visible = false;
                    this.groupInput.Visible = true;
                    break;
                //例外
                default:
                    this.group_tag.Visible = true;
                    this.groupHead.Visible = false;
                    this.groupBody.Visible = false;
                    this.groupInput.Visible = false;
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
            property_text.Text = "";
            property_text2.Text = "";
        }

        private void button_head2_Click(object sender, EventArgs e)
        {
            flg = 1;
            ButtonVisible();
            property_text.Text = "";
            property_text2.Text = "";
        }
        //---

        //---タグツリーのタグツリーのBODYボタン処理
        private void button_body1_Click(object sender, EventArgs e)
        {
            flg = 2;
            ButtonVisible();
            property_text.Text = "";
            property_text2.Text = "";

        }

        private void button_body2_Click(object sender, EventArgs e)
        {
            flg = 2;
            ButtonVisible();
            property_text.Text = "";
            property_text2.Text = "";

        }
        //---

        //---タグツリーのHTMLボタン処理
        private void button_html_Click(object sender, EventArgs e)
        {
            flg = 0;
            ButtonVisible();
            property_text.Text = "";
            property_text2.Text = "";
        }
        //---

        //Formロード時処理
        private void Form1_Load(object sender, EventArgs e)
        {
            //---タグ一覧のリスト処理
            String [] Item = { "見出し","文","表","画像","URL","テキストボックス","ボタン","ナビ","インプット" ,"スモール"};

            foreach (String addItem in Item){
                listItem.Items.Add(addItem);
            }
            //---

            //---BODYタグツリーのスクロール
            this.flowLayoutPanel_body.VerticalScroll.Visible = true;
            this.flowLayoutPanel_input.VerticalScroll.Visible = true;

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
                    button_h1.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);                   //フォントの設定
                    button_h1.Name = "h1_" + addH1Count;                                            //ボタンのNameの設定
                    flowLayoutPanel_body.Controls.Add(button_h1);
                    addBodyCount++;                                                                 //BODYの個数のカウント
                    dic.Add(button_h1.Name, flowLayoutPanel_body.Controls.GetChildIndex(button_h1));
                    button_h1.Click += btnclick(button_h1.Name, "h1", dic[button_h1.Name], addH1Count, button_h1);                  //追加したボタンにイベントを追加
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
                    button_p.Name = "p_" + addPCount;
                    flowLayoutPanel_body.Controls.Add(button_p);
                    addBodyCount++;
                    dic.Add(button_p.Name, flowLayoutPanel_body.Controls.GetChildIndex(button_p));
                    button_p.Click += btnclick(button_p.Name, "p", dic[button_p.Name], addPCount, button_p);
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
                    button_table.Name = "table_" + addTableCount;
                    flowLayoutPanel_body.Controls.Add(button_table);
                    addBodyCount++;
                    dic.Add(button_table.Name, flowLayoutPanel_body.Controls.GetChildIndex(button_table));
                    button_table.Click += btnclick(button_table.Name, "table", dic[button_table.Name], addTableCount, button_table);
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
                    button_img.Name = "img_" + addImgCount;
                    flowLayoutPanel_body.Controls.Add(button_img);
                    addBodyCount++;
                    dic.Add(button_img.Name, flowLayoutPanel_body.Controls.GetChildIndex(button_img));
                    button_img.Click += btnclick(button_img.Name, "img", dic[button_img.Name], addImgCount, button_img);
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
                    button_url.Name = "url_" + addUrlCount;
                    flowLayoutPanel_body.Controls.Add(button_url);
                    addBodyCount++;
                    dic.Add(button_url.Name, flowLayoutPanel_body.Controls.GetChildIndex(button_url));
                    button_url.Click += btnclick(button_url.Name, "url", dic[button_url.Name], addUrlCount, button_url);
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
                    button_textBox.Name = "textbox_" + addTextboxCount;
                    if (inputflg == 0)
                    {
                        flowLayoutPanel_body.Controls.Add(button_textBox);
                        dic.Add(button_textBox.Name, flowLayoutPanel_body.Controls.GetChildIndex(button_textBox));
                    }
                    else if (inputflg == 1)
                    {
                        flowLayoutPanel_input.Controls.Add(button_textBox);
                        dic.Add(button_textBox.Name, flowLayoutPanel_input.Controls.GetChildIndex(button_textBox));
                    }
                    addBodyCount++;
                    dic2.Add("textbox_" + addTextboxCount, button_textBox.Name);
                    button_textBox.Click += btnclick(button_textBox.Name, "textbox", dic[button_textBox.Name], addTextboxCount, button_textBox);
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
                    button_Button.Name = "button_" + addButtonCount;
                    if (inputflg == 0)
                    {
                        flowLayoutPanel_body.Controls.Add(button_Button);
                        dic.Add(button_Button.Name, flowLayoutPanel_body.Controls.GetChildIndex(button_Button));
                    }
                    else if (inputflg == 1)
                    {
                        flowLayoutPanel_input.Controls.Add(button_Button);
                        dic.Add(button_Button.Name, flowLayoutPanel_input.Controls.GetChildIndex(button_Button));
                    }
                    addBodyCount++;
                    dic2.Add("button_" + addButtonCount, button_Button.Name);
                    button_Button.Click += btnclick(button_Button.Name, "button", dic[button_Button.Name], addButtonCount, button_Button);
                    break;
                //ナビ
                case 7:
                    addNavCount++;
                    Button button_Nav = new Button();
                    button_Nav.Size = new Size(122, 54);
                    button_Nav.ForeColor = Color.FromName("White");
                    button_Nav.BackColor = Color.FromName("DodgerBlue");
                    button_Nav.Text = "<NAV>";
                    button_Nav.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_Nav.Name = "nav_" + addNavCount;
                    flowLayoutPanel_body.Controls.Add(button_Nav);
                    addBodyCount++;
                    dic.Add(button_Nav.Name, flowLayoutPanel_body.Controls.GetChildIndex(button_Nav));
                    button_Nav.Click += btnclick(button_Nav.Name, "nav", dic[button_Nav.Name], addButtonCount, button_Nav);
                    break;

                //インプット
                case 8:
                    Button button_Input = new Button();
                    button_Input.Size = new Size(122, 54);
                    button_Input.ForeColor = Color.FromName("Black");
                    button_Input.BackColor = Color.FromArgb(192, 192, 255);
                    button_Input.Text = "<INPUT>";
                    button_Input.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_Input.Name = "input_" + addInputCount;
                    if (inputedCount == 1)
                    {
                        if (inputedflg != 1)
                        {
                            flowLayoutPanel_body.Controls.Add(button_Input);
                            addBodyCount++;
                            dic.Add(button_Input.Name, flowLayoutPanel_body.Controls.GetChildIndex(button_Input));
                            button_Input.Click += btnclick(button_Input.Name, "input", dic[button_Input.Name], addInputCount, button_Input);
                            GroupingInput(addTextboxCount, addButtonCount);
                            inputedCount++;
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
                    button_Small.ForeColor = Color.FromName("White");
                    button_Small.BackColor = Color.FromName("DodgerBlue");
                    button_Small.Text = "<SMALL>";
                    button_Small.Font = new Font("MS UI Gothic", 18, FontStyle.Bold);
                    button_Small.Name = "small_" + addSmallCount;
                    flowLayoutPanel_body.Controls.Add(button_Small);
                    addBodyCount++;
                    dic.Add(button_Small.Name, flowLayoutPanel_body.Controls.GetChildIndex(button_Small));
                    button_Small.Click += btnclick(button_Small.Name, "small", dic[button_Small.Name], addButtonCount, button_Small);
                    break;
                default:
                    break;
            }
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
                    //選択したボタンのプロパティを表示

                    if (inputedflg == 0)
                    {
                        switch (getkind)
                        {
                            case "h1":
                                property_text.Text = "class :" + name;
                                break;
                            case "p":
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
                                break;
                            case "input":
                                flg = 8;
                                ButtonVisible();
                                break;
                            case "small":
                                property_text.Text = "class :" + name;
                                break;
                            default:
                                break;
                        }
                    }else if(inputedflg == 1)
                    {
                        switch (getkind)
                        {
                            case "h1":
                                property_text.Text = "class :" + name;
                                break;
                            case "p":
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
                                property_text2.Text = "class :" + name;
                                break;
                            case "button":
                                property_text2.Text = "class :" + name;
                                break;
                            case "input":
                                flg = 8;
                                ButtonVisible();
                                break;
                            case "nav":
                                property_text.Text = "class :" + name;
                                break;
                            case "small":
                                property_text.Text = "class :" + name;
                                break;
                            default:
                                break;
                        }
                    }
                }//通常時
                else if(flg == 6)
                {
                    switch (getkind)
                    {
                        case "input":
                            flg = 8;
                            ButtonVisible();
                            flg = 6;
                            break;
                    }
                }
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
                                        this.Controls.Remove(control2);
                                        control2.Dispose();
                                    }
                                    Control[] controls3 = Controls.Find("button_" + i, true);
                                    foreach (Control control3 in controls3)
                                    {
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
                                
                        }
                        this.Controls.Remove(control);
                        control.Dispose();
                        dic.Remove(name);
                        addBodyCount--;
                    }
                        
                            
                        

                }//flg==5削除
                else if (flg == 7)
                {
                    
                    //入れ替え処理
                    switch (contflg)
                    {   //選択回数
                        //1回目
                        case 0:
                            name1 = name;   //一つ目の部品の名前を保持
                            ctrl1 = cont;   //部品のコントロールを保持
                            cont1 = flowLayoutPanel_body.Controls.GetChildIndex(cont);  //部品のFlowLayoutPanelのインデックスを保持
                            contflg = 1;    //選択カウントを設定
                            break;
                        //二回目
                        case 1:
                            ctrl2 = cont;   //二つ目の部品の名前を保持
                            cont2 = flowLayoutPanel_body.Controls.GetChildIndex(cont);  //部品のFlowLayoutPanelのインデックスを保持
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
            
        }
        //---

        //---入れ替え処理メソッド
        private void SwapControls(int x, int y ,Control ctrl1, Control ctrl2)
        {
            flowLayoutPanel_body.SuspendLayout();

            //入れ替え処理
            flowLayoutPanel_body.Controls.SetChildIndex(ctrl1, y);
            flowLayoutPanel_body.Controls.SetChildIndex(ctrl2, x);

            flowLayoutPanel_body.ResumeLayout();
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
    }
}
