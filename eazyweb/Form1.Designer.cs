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
            this.groupHead = new System.Windows.Forms.GroupBox();
            this.button_title = new System.Windows.Forms.Button();
            this.flowLayoutPanel_head = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBody = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_body = new System.Windows.Forms.FlowLayoutPanel();
            this.button_swap = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.groupInput = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_input = new System.Windows.Forms.FlowLayoutPanel();
            this.button_Input = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_body1 = new System.Windows.Forms.Button();
            this.button_html = new System.Windows.Forms.Button();
            this.button_head1 = new System.Windows.Forms.Button();
            this.button_body2 = new System.Windows.Forms.Button();
            this.listItem = new System.Windows.Forms.ListBox();
            this.button_save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.button_open = new System.Windows.Forms.Button();
            this.group_tag.SuspendLayout();
            this.groupHead.SuspendLayout();
            this.groupBody.SuspendLayout();
            this.groupInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
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
            this.group_tag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(106)))), ((int)(((byte)(34)))));
            this.group_tag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.group_tag.Controls.Add(this.groupHead);
            this.group_tag.Controls.Add(this.groupBody);
            this.group_tag.Controls.Add(this.button_swap);
            this.group_tag.Controls.Add(this.button_edit);
            this.group_tag.Controls.Add(this.groupInput);
            this.group_tag.Controls.Add(this.label1);
            this.group_tag.Controls.Add(this.button_delete);
            this.group_tag.Controls.Add(this.button_body1);
            this.group_tag.Controls.Add(this.button_html);
            this.group_tag.Controls.Add(this.button_head1);
            this.group_tag.Controls.Add(this.button_body2);
            this.group_tag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.group_tag.Location = new System.Drawing.Point(24, 473);
            this.group_tag.Name = "group_tag";
            this.group_tag.Size = new System.Drawing.Size(355, 546);
            this.group_tag.TabIndex = 3;
            this.group_tag.TabStop = false;
            // 
            // groupHead
            // 
            this.groupHead.BackColor = System.Drawing.Color.White;
            this.groupHead.Controls.Add(this.button_title);
            this.groupHead.Controls.Add(this.flowLayoutPanel_head);
            this.groupHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupHead.Location = new System.Drawing.Point(6, 142);
            this.groupHead.Name = "groupHead";
            this.groupHead.Size = new System.Drawing.Size(343, 398);
            this.groupHead.TabIndex = 2;
            this.groupHead.TabStop = false;
            this.groupHead.Visible = false;
            // 
            // button_title
            // 
            this.button_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(214)))), ((int)(((byte)(195)))));
            this.button_title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_title.FlatAppearance.BorderSize = 0;
            this.button_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_title.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(92)))), ((int)(((byte)(79)))));
            this.button_title.Location = new System.Drawing.Point(3, 10);
            this.button_title.Name = "button_title";
            this.button_title.Size = new System.Drawing.Size(122, 51);
            this.button_title.TabIndex = 1;
            this.button_title.Text = "<TITLE>";
            this.button_title.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel_head
            // 
            this.flowLayoutPanel_head.AutoScroll = true;
            this.flowLayoutPanel_head.Location = new System.Drawing.Point(0, 62);
            this.flowLayoutPanel_head.Name = "flowLayoutPanel_head";
            this.flowLayoutPanel_head.Size = new System.Drawing.Size(158, 327);
            this.flowLayoutPanel_head.TabIndex = 8;
            // 
            // groupBody
            // 
            this.groupBody.BackColor = System.Drawing.Color.White;
            this.groupBody.Controls.Add(this.flowLayoutPanel_body);
            this.groupBody.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBody.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(106)))), ((int)(((byte)(34)))));
            this.groupBody.Location = new System.Drawing.Point(6, 142);
            this.groupBody.Name = "groupBody";
            this.groupBody.Size = new System.Drawing.Size(343, 398);
            this.groupBody.TabIndex = 2;
            this.groupBody.TabStop = false;
            this.groupBody.Visible = false;
            // 
            // flowLayoutPanel_body
            // 
            this.flowLayoutPanel_body.AutoScroll = true;
            this.flowLayoutPanel_body.Location = new System.Drawing.Point(0, 7);
            this.flowLayoutPanel_body.Name = "flowLayoutPanel_body";
            this.flowLayoutPanel_body.Size = new System.Drawing.Size(161, 382);
            this.flowLayoutPanel_body.TabIndex = 6;
            // 
            // button_swap
            // 
            this.button_swap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(214)))), ((int)(((byte)(195)))));
            this.button_swap.FlatAppearance.BorderSize = 0;
            this.button_swap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_swap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(92)))), ((int)(((byte)(79)))));
            this.button_swap.Location = new System.Drawing.Point(193, 9);
            this.button_swap.Name = "button_swap";
            this.button_swap.Size = new System.Drawing.Size(75, 23);
            this.button_swap.TabIndex = 4;
            this.button_swap.Text = "並び替え";
            this.button_swap.UseVisualStyleBackColor = false;
            this.button_swap.Visible = false;
            this.button_swap.Click += new System.EventHandler(this.button_swap_Click);
            // 
            // button_edit
            // 
            this.button_edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(214)))), ((int)(((byte)(195)))));
            this.button_edit.FlatAppearance.BorderSize = 0;
            this.button_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_edit.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(92)))), ((int)(((byte)(79)))));
            this.button_edit.Location = new System.Drawing.Point(274, 9);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(75, 23);
            this.button_edit.TabIndex = 3;
            this.button_edit.Text = "編集";
            this.button_edit.UseVisualStyleBackColor = false;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click_1);
            // 
            // groupInput
            // 
            this.groupInput.BackColor = System.Drawing.Color.White;
            this.groupInput.Controls.Add(this.flowLayoutPanel_input);
            this.groupInput.Controls.Add(this.button_Input);
            this.groupInput.DataBindings.Add(new System.Windows.Forms.Binding("TabIndex", global::eazyweb.Properties.Settings.Default, "GroupInput", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.groupInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupInput.Location = new System.Drawing.Point(6, 142);
            this.groupInput.Name = "groupInput";
            this.groupInput.Size = new System.Drawing.Size(343, 398);
            this.groupInput.TabIndex = global::eazyweb.Properties.Settings.Default.GroupInput;
            this.groupInput.TabStop = false;
            this.groupInput.Visible = false;
            // 
            // flowLayoutPanel_input
            // 
            this.flowLayoutPanel_input.AutoScroll = true;
            this.flowLayoutPanel_input.Location = new System.Drawing.Point(3, 62);
            this.flowLayoutPanel_input.Name = "flowLayoutPanel_input";
            this.flowLayoutPanel_input.Size = new System.Drawing.Size(158, 327);
            this.flowLayoutPanel_input.TabIndex = 8;
            // 
            // button_Input
            // 
            this.button_Input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(214)))), ((int)(((byte)(195)))));
            this.button_Input.FlatAppearance.BorderSize = 0;
            this.button_Input.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Input.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Input.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(92)))), ((int)(((byte)(79)))));
            this.button_Input.Location = new System.Drawing.Point(3, 9);
            this.button_Input.Name = "button_Input";
            this.button_Input.Size = new System.Drawing.Size(122, 52);
            this.button_Input.TabIndex = 7;
            this.button_Input.Text = "<INPUT>";
            this.button_Input.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(106)))), ((int)(((byte)(34)))));
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "タグツリー";
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.White;
            this.button_delete.FlatAppearance.BorderSize = 0;
            this.button_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delete.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(106)))), ((int)(((byte)(34)))));
            this.button_delete.Location = new System.Drawing.Point(274, 38);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 3;
            this.button_delete.Text = "削除";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Visible = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_body1
            // 
            this.button_body1.BackColor = System.Drawing.Color.White;
            this.button_body1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_body1.FlatAppearance.BorderSize = 0;
            this.button_body1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_body1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_body1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(106)))), ((int)(((byte)(34)))));
            this.button_body1.Location = new System.Drawing.Point(6, 148);
            this.button_body1.Name = "button_body1";
            this.button_body1.Size = new System.Drawing.Size(125, 54);
            this.button_body1.TabIndex = 1;
            this.button_body1.Text = "<BODY>";
            this.button_body1.UseVisualStyleBackColor = false;
            this.button_body1.Click += new System.EventHandler(this.button_body1_Click);
            // 
            // button_html
            // 
            this.button_html.BackColor = System.Drawing.Color.White;
            this.button_html.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_html.FlatAppearance.BorderSize = 0;
            this.button_html.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_html.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_html.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(106)))), ((int)(((byte)(34)))));
            this.button_html.Location = new System.Drawing.Point(6, 29);
            this.button_html.Name = "button_html";
            this.button_html.Size = new System.Drawing.Size(125, 55);
            this.button_html.TabIndex = 1;
            this.button_html.Text = "<HTML>";
            this.button_html.UseVisualStyleBackColor = false;
            this.button_html.Click += new System.EventHandler(this.button_html_Click);
            // 
            // button_head1
            // 
            this.button_head1.BackColor = System.Drawing.Color.White;
            this.button_head1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_head1.FlatAppearance.BorderSize = 0;
            this.button_head1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_head1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_head1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(106)))), ((int)(((byte)(34)))));
            this.button_head1.Location = new System.Drawing.Point(6, 90);
            this.button_head1.Name = "button_head1";
            this.button_head1.Size = new System.Drawing.Size(125, 54);
            this.button_head1.TabIndex = 1;
            this.button_head1.Text = "<HEAD>";
            this.button_head1.UseVisualStyleBackColor = false;
            this.button_head1.Click += new System.EventHandler(this.button_head1_Click);
            // 
            // button_body2
            // 
            this.button_body2.BackColor = System.Drawing.Color.White;
            this.button_body2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_body2.FlatAppearance.BorderSize = 0;
            this.button_body2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_body2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_body2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(106)))), ((int)(((byte)(34)))));
            this.button_body2.Location = new System.Drawing.Point(6, 90);
            this.button_body2.Name = "button_body2";
            this.button_body2.Size = new System.Drawing.Size(125, 54);
            this.button_body2.TabIndex = 1;
            this.button_body2.Text = "<BODY>";
            this.button_body2.UseVisualStyleBackColor = false;
            this.button_body2.Visible = false;
            this.button_body2.Click += new System.EventHandler(this.button_body2_Click);
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
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(411, 28);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 7;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // eventLog1
            // 
            this.eventLog1.EnableRaisingEvents = true;
            this.eventLog1.Log = "Application";
            this.eventLog1.SynchronizingObject = this;
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(411, 58);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(75, 23);
            this.button_open.TabIndex = 9;
            this.button_open.Text = "開く";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1684, 1031);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.listItem);
            this.Controls.Add(this.group_tag);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "かんたんウェブ君～HTMLをまなぼう！～";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.group_tag.ResumeLayout(false);
            this.group_tag.PerformLayout();
            this.groupHead.ResumeLayout(false);
            this.groupBody.ResumeLayout(false);
            this.groupInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox group_tag;
        private System.Windows.Forms.Button button_body1;
        private System.Windows.Forms.Button button_title;
        private System.Windows.Forms.Button button_html;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupHead;
        private System.Windows.Forms.Button button_head1;
        private System.Windows.Forms.GroupBox groupBody;
        private System.Windows.Forms.ListBox listItem;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_body2;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_swap;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_body;
        private System.Windows.Forms.GroupBox groupInput;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_input;
        private System.Windows.Forms.Button button_Input;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_head;
    }
}

