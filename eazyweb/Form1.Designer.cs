namespace eazyweb
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.group_tag = new System.Windows.Forms.GroupBox();
            this.button_swap = new System.Windows.Forms.Button();
            this.groupHead = new System.Windows.Forms.GroupBox();
            this.button_head2 = new System.Windows.Forms.Button();
            this.button_title = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_head1 = new System.Windows.Forms.Button();
            this.button_body1 = new System.Windows.Forms.Button();
            this.button_html = new System.Windows.Forms.Button();
            this.groupBody = new System.Windows.Forms.GroupBox();
            this.button_body2 = new System.Windows.Forms.Button();
            this.property_text = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel_body = new System.Windows.Forms.FlowLayoutPanel();
            this.button_edit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listItem = new System.Windows.Forms.ListBox();
            this.groupInput = new System.Windows.Forms.GroupBox();
            this.button_body3 = new System.Windows.Forms.Button();
            this.property_text2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel_input = new System.Windows.Forms.FlowLayoutPanel();
            this.button_Input = new System.Windows.Forms.Button();
            this.group_tag.SuspendLayout();
            this.groupHead.SuspendLayout();
            this.groupBody.SuspendLayout();
            this.groupInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // group_tag
            // 
            this.group_tag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.group_tag.Controls.Add(this.button_swap);
            this.group_tag.Controls.Add(this.groupHead);
            this.group_tag.Controls.Add(this.button_delete);
            this.group_tag.Controls.Add(this.button_head1);
            this.group_tag.Controls.Add(this.button_body1);
            this.group_tag.Controls.Add(this.button_html);
            this.group_tag.Location = new System.Drawing.Point(24, 473);
            this.group_tag.Name = "group_tag";
            this.group_tag.Size = new System.Drawing.Size(355, 507);
            this.group_tag.TabIndex = 3;
            this.group_tag.TabStop = false;
            // 
            // button_swap
            // 
            this.button_swap.Location = new System.Drawing.Point(162, 10);
            this.button_swap.Name = "button_swap";
            this.button_swap.Size = new System.Drawing.Size(75, 23);
            this.button_swap.TabIndex = 4;
            this.button_swap.Text = "並び替え";
            this.button_swap.UseVisualStyleBackColor = true;
            this.button_swap.Visible = false;
            this.button_swap.Click += new System.EventHandler(this.button_swap_Click);
            // 
            // groupHead
            // 
            this.groupHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupHead.Controls.Add(this.button_head2);
            this.groupHead.Controls.Add(this.button_title);
            this.groupHead.Location = new System.Drawing.Point(0, 58);
            this.groupHead.Name = "groupHead";
            this.groupHead.Size = new System.Drawing.Size(349, 443);
            this.groupHead.TabIndex = 2;
            this.groupHead.TabStop = false;
            this.groupHead.Visible = false;
            // 
            // button_head2
            // 
            this.button_head2.BackColor = System.Drawing.Color.Blue;
            this.button_head2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_head2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_head2.ForeColor = System.Drawing.Color.White;
            this.button_head2.Location = new System.Drawing.Point(0, 20);
            this.button_head2.Name = "button_head2";
            this.button_head2.Size = new System.Drawing.Size(122, 54);
            this.button_head2.TabIndex = 1;
            this.button_head2.Text = "<HEAD>";
            this.button_head2.UseVisualStyleBackColor = false;
            this.button_head2.Click += new System.EventHandler(this.button_head2_Click);
            // 
            // button_title
            // 
            this.button_title.BackColor = System.Drawing.Color.Blue;
            this.button_title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_title.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_title.ForeColor = System.Drawing.Color.White;
            this.button_title.Location = new System.Drawing.Point(0, 96);
            this.button_title.Name = "button_title";
            this.button_title.Size = new System.Drawing.Size(122, 54);
            this.button_title.TabIndex = 1;
            this.button_title.Text = "<TITLE>";
            this.button_title.UseVisualStyleBackColor = false;
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Red;
            this.button_delete.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button_delete.FlatAppearance.BorderSize = 0;
            this.button_delete.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_delete.Location = new System.Drawing.Point(243, 10);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 3;
            this.button_delete.Text = "削除";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Visible = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_head1
            // 
            this.button_head1.BackColor = System.Drawing.Color.Blue;
            this.button_head1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_head1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_head1.ForeColor = System.Drawing.Color.White;
            this.button_head1.Location = new System.Drawing.Point(0, 76);
            this.button_head1.Name = "button_head1";
            this.button_head1.Size = new System.Drawing.Size(122, 54);
            this.button_head1.TabIndex = 1;
            this.button_head1.Text = "<HEAD>";
            this.button_head1.UseVisualStyleBackColor = false;
            this.button_head1.Click += new System.EventHandler(this.button_head1_Click);
            // 
            // button_body1
            // 
            this.button_body1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_body1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_body1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_body1.ForeColor = System.Drawing.Color.White;
            this.button_body1.Location = new System.Drawing.Point(0, 152);
            this.button_body1.Name = "button_body1";
            this.button_body1.Size = new System.Drawing.Size(122, 54);
            this.button_body1.TabIndex = 1;
            this.button_body1.Text = "<BODY>";
            this.button_body1.UseVisualStyleBackColor = false;
            this.button_body1.Click += new System.EventHandler(this.button_body1_Click);
            // 
            // button_html
            // 
            this.button_html.BackColor = System.Drawing.Color.Yellow;
            this.button_html.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_html.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_html.Location = new System.Drawing.Point(3, 10);
            this.button_html.Name = "button_html";
            this.button_html.Size = new System.Drawing.Size(122, 41);
            this.button_html.TabIndex = 1;
            this.button_html.Text = "<HTML>";
            this.button_html.UseVisualStyleBackColor = false;
            this.button_html.Click += new System.EventHandler(this.button_html_Click);
            // 
            // groupBody
            // 
            this.groupBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBody.Controls.Add(this.button_body2);
            this.groupBody.Controls.Add(this.property_text);
            this.groupBody.Controls.Add(this.label2);
            this.groupBody.Controls.Add(this.flowLayoutPanel_body);
            this.groupBody.Location = new System.Drawing.Point(24, 530);
            this.groupBody.Name = "groupBody";
            this.groupBody.Size = new System.Drawing.Size(349, 445);
            this.groupBody.TabIndex = 2;
            this.groupBody.TabStop = false;
            this.groupBody.Visible = false;
            // 
            // button_body2
            // 
            this.button_body2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_body2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_body2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_body2.ForeColor = System.Drawing.Color.White;
            this.button_body2.Location = new System.Drawing.Point(3, 21);
            this.button_body2.Name = "button_body2";
            this.button_body2.Size = new System.Drawing.Size(122, 54);
            this.button_body2.TabIndex = 1;
            this.button_body2.Text = "<BODY>";
            this.button_body2.UseVisualStyleBackColor = false;
            this.button_body2.Click += new System.EventHandler(this.button_body2_Click);
            // 
            // property_text
            // 
            this.property_text.BackColor = System.Drawing.SystemColors.Info;
            this.property_text.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.property_text.ForeColor = System.Drawing.SystemColors.InfoText;
            this.property_text.Location = new System.Drawing.Point(162, 34);
            this.property_text.Multiline = true;
            this.property_text.Name = "property_text";
            this.property_text.Size = new System.Drawing.Size(181, 401);
            this.property_text.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(166, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "プロパティ";
            // 
            // flowLayoutPanel_body
            // 
            this.flowLayoutPanel_body.AutoScroll = true;
            this.flowLayoutPanel_body.Location = new System.Drawing.Point(0, 81);
            this.flowLayoutPanel_body.Name = "flowLayoutPanel_body";
            this.flowLayoutPanel_body.Size = new System.Drawing.Size(161, 354);
            this.flowLayoutPanel_body.TabIndex = 6;
            // 
            // button_edit
            // 
            this.button_edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button_edit.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button_edit.FlatAppearance.BorderSize = 0;
            this.button_edit.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_edit.Location = new System.Drawing.Point(267, 457);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(75, 23);
            this.button_edit.TabIndex = 3;
            this.button_edit.Text = "編集";
            this.button_edit.UseVisualStyleBackColor = false;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(24, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "タグツリー";
            // 
            // listItem
            // 
            this.listItem.BackColor = System.Drawing.SystemColors.Menu;
            this.listItem.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listItem.FormattingEnabled = true;
            this.listItem.ItemHeight = 16;
            this.listItem.Location = new System.Drawing.Point(24, 28);
            this.listItem.Name = "listItem";
            this.listItem.ScrollAlwaysVisible = true;
            this.listItem.Size = new System.Drawing.Size(240, 388);
            this.listItem.TabIndex = 5;
            this.listItem.SelectedIndexChanged += new System.EventHandler(this.listItem_SelectedIndexChanged);
            // 
            // groupInput
            // 
            this.groupInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupInput.Controls.Add(this.button_body3);
            this.groupInput.Controls.Add(this.property_text2);
            this.groupInput.Controls.Add(this.label3);
            this.groupInput.Controls.Add(this.flowLayoutPanel_input);
            this.groupInput.Controls.Add(this.button_Input);
            this.groupInput.Location = new System.Drawing.Point(24, 529);
            this.groupInput.Name = "groupInput";
            this.groupInput.Size = new System.Drawing.Size(349, 445);
            this.groupInput.TabIndex = 6;
            this.groupInput.TabStop = false;
            this.groupInput.Visible = false;
            // 
            // button_body3
            // 
            this.button_body3.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_body3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_body3.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_body3.ForeColor = System.Drawing.Color.White;
            this.button_body3.Location = new System.Drawing.Point(6, 20);
            this.button_body3.Name = "button_body3";
            this.button_body3.Size = new System.Drawing.Size(122, 54);
            this.button_body3.TabIndex = 1;
            this.button_body3.Text = "<BODY>";
            this.button_body3.UseVisualStyleBackColor = false;
            this.button_body3.Click += new System.EventHandler(this.button_body2_Click);
            // 
            // property_text2
            // 
            this.property_text2.BackColor = System.Drawing.SystemColors.Info;
            this.property_text2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.property_text2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.property_text2.Location = new System.Drawing.Point(170, 33);
            this.property_text2.Multiline = true;
            this.property_text2.Name = "property_text2";
            this.property_text2.Size = new System.Drawing.Size(173, 401);
            this.property_text2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(174, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "プロパティ";
            // 
            // flowLayoutPanel_input
            // 
            this.flowLayoutPanel_input.AutoScroll = true;
            this.flowLayoutPanel_input.Location = new System.Drawing.Point(3, 152);
            this.flowLayoutPanel_input.Name = "flowLayoutPanel_input";
            this.flowLayoutPanel_input.Size = new System.Drawing.Size(158, 272);
            this.flowLayoutPanel_input.TabIndex = 8;
            // 
            // button_Input
            // 
            this.button_Input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button_Input.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Input.Location = new System.Drawing.Point(6, 94);
            this.button_Input.Name = "button_Input";
            this.button_Input.Size = new System.Drawing.Size(122, 52);
            this.button_Input.TabIndex = 7;
            this.button_Input.Text = "<INPUT>";
            this.button_Input.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1684, 1031);
            this.Controls.Add(this.groupInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBody);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.listItem);
            this.Controls.Add(this.group_tag);
            this.Name = "Form1";
            this.Text = "かんたんウェブ君～HTMLをまなぼう！～";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.group_tag.ResumeLayout(false);
            this.groupHead.ResumeLayout(false);
            this.groupBody.ResumeLayout(false);
            this.groupBody.PerformLayout();
            this.groupInput.ResumeLayout(false);
            this.groupInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox group_tag;
        private System.Windows.Forms.Button button_body1;
        private System.Windows.Forms.Button button_title;
        private System.Windows.Forms.Button button_head2;
        private System.Windows.Forms.Button button_html;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupHead;
        private System.Windows.Forms.Button button_head1;
        private System.Windows.Forms.GroupBox groupBody;
        private System.Windows.Forms.ListBox listItem;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_body2;
        private System.Windows.Forms.TextBox property_text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_swap;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_body;
        private System.Windows.Forms.GroupBox groupInput;
        private System.Windows.Forms.TextBox property_text2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_input;
        private System.Windows.Forms.Button button_Input;
        private System.Windows.Forms.Button button_body3;
    }
}

