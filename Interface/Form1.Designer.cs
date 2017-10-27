namespace Interface
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.book_data_grid = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.author_data_grid = new System.Windows.Forms.DataGridView();
            this.author_name_text_box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.save_author_to_db_button = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.delete_author_btn = new System.Windows.Forms.Button();
            this.open_file_btn = new System.Windows.Forms.Button();
            this.editauthor = new System.Windows.Forms.Button();
            this.Edit_Book = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.book_data_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.author_data_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save to DB";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.createNewBookInDb);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(129, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Author";
            // 
            // book_data_grid
            // 
            this.book_data_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.book_data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.book_data_grid.Location = new System.Drawing.Point(57, 167);
            this.book_data_grid.Name = "book_data_grid";
            this.book_data_grid.Size = new System.Drawing.Size(436, 150);
            this.book_data_grid.TabIndex = 5;
            this.book_data_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.showImage);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(388, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Delete selected";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.deleteFromDb);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 18.215F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(234, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "Books";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 18.215F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(688, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Authors";
            // 
            // author_data_grid
            // 
            this.author_data_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.author_data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.author_data_grid.Location = new System.Drawing.Point(542, 167);
            this.author_data_grid.Name = "author_data_grid";
            this.author_data_grid.Size = new System.Drawing.Size(436, 150);
            this.author_data_grid.TabIndex = 9;
            // 
            // author_name_text_box
            // 
            this.author_name_text_box.Location = new System.Drawing.Point(663, 57);
            this.author_name_text_box.Name = "author_name_text_box";
            this.author_name_text_box.Size = new System.Drawing.Size(100, 20);
            this.author_name_text_box.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(581, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Author name";
            // 
            // save_author_to_db_button
            // 
            this.save_author_to_db_button.Location = new System.Drawing.Point(789, 57);
            this.save_author_to_db_button.Name = "save_author_to_db_button";
            this.save_author_to_db_button.Size = new System.Drawing.Size(75, 23);
            this.save_author_to_db_button.TabIndex = 13;
            this.save_author_to_db_button.Text = "Save to DB";
            this.save_author_to_db_button.UseVisualStyleBackColor = true;
            this.save_author_to_db_button.Click += new System.EventHandler(this.saveAuthorToDB);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(307, 51);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 14;
            // 
            // delete_author_btn
            // 
            this.delete_author_btn.Location = new System.Drawing.Point(870, 57);
            this.delete_author_btn.Name = "delete_author_btn";
            this.delete_author_btn.Size = new System.Drawing.Size(94, 23);
            this.delete_author_btn.TabIndex = 15;
            this.delete_author_btn.Text = "Delete Selected";
            this.delete_author_btn.UseVisualStyleBackColor = true;
            this.delete_author_btn.Click += new System.EventHandler(this.delete_author_btn_Click);
            // 
            // open_file_btn
            // 
            this.open_file_btn.Location = new System.Drawing.Point(870, 86);
            this.open_file_btn.Name = "open_file_btn";
            this.open_file_btn.Size = new System.Drawing.Size(94, 23);
            this.open_file_btn.TabIndex = 16;
            this.open_file_btn.Text = "Openfile";
            this.open_file_btn.UseVisualStyleBackColor = true;
            this.open_file_btn.Click += new System.EventHandler(this.open_file_btn_Click);
            // 
            // editauthor
            // 
            this.editauthor.Location = new System.Drawing.Point(789, 86);
            this.editauthor.Name = "editauthor";
            this.editauthor.Size = new System.Drawing.Size(75, 23);
            this.editauthor.TabIndex = 17;
            this.editauthor.Text = "Edit";
            this.editauthor.UseVisualStyleBackColor = true;
            this.editauthor.Click += new System.EventHandler(this.editauthor_Click);
            // 
            // Edit_Book
            // 
            this.Edit_Book.Location = new System.Drawing.Point(203, 340);
            this.Edit_Book.Name = "Edit_Book";
            this.Edit_Book.Size = new System.Drawing.Size(75, 23);
            this.Edit_Book.TabIndex = 18;
            this.Edit_Book.Text = "Edit Book";
            this.Edit_Book.UseVisualStyleBackColor = true;
            this.Edit_Book.Click += new System.EventHandler(this.Edit_Book_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 451);
            this.Controls.Add(this.Edit_Book);
            this.Controls.Add(this.editauthor);
            this.Controls.Add(this.open_file_btn);
            this.Controls.Add(this.delete_author_btn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.save_author_to_db_button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.author_name_text_box);
            this.Controls.Add(this.author_data_grid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.book_data_grid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.book_data_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.author_data_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.DataGridView book_data_grid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView author_data_grid;
        private System.Windows.Forms.TextBox author_name_text_box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button save_author_to_db_button;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button delete_author_btn;
        private System.Windows.Forms.Button open_file_btn;
        private System.Windows.Forms.Button editauthor;
        private System.Windows.Forms.Button Edit_Book;
    }
}

